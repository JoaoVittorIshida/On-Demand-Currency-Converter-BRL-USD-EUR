using System.Globalization;
using Newtonsoft.Json.Linq;

namespace Conversor_Monetário
{
    public partial class ConversorMonetario : Form
    {
        public ConversorMonetario()
        {
            InitializeComponent();

            // Configura o modo de desenho das ComboBoxes e associa o evento de desenho
            MoedaEntrada.DrawMode = DrawMode.OwnerDrawFixed;
            MoedaSaida.DrawMode = DrawMode.OwnerDrawFixed;
            MoedaEntrada.DrawItem += Moeda_DrawItem;
            MoedaSaida.DrawItem += Moeda_DrawItem;

            // Adiciona os itens a ambas as ComboBoxes
            string[] moedas = { "BRL (Real)", "USD (Dólar)", "EUR (Euro)" };
            MoedaEntrada.Items.AddRange(moedas);
            MoedaSaida.Items.AddRange(moedas);

        }

        decimal entradac, saidac, cotacaocalc;
        decimal USDEUR, USDBRL;
        string caminhoCotacao = "cotacoes.json";
        string dataHora = "";
        bool cotpadrao;

        private void Moeda_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            ComboBox comboBox = sender as ComboBox;
            string text = comboBox.Items[e.Index].ToString();
            Image icon = null;
            switch (e.Index)
            {
                case 0:
                    icon = Properties.Resources.IconBRL;
                    break;
                case 1:
                    icon = Properties.Resources.IconUSD;
                    break;
                case 2:
                    icon = Properties.Resources.IconEUR;
                    break;
            }
            if (icon != null)
            {
                e.Graphics.DrawImage(icon, e.Bounds.Left, e.Bounds.Top, 38, 28);
            }
            e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds.Left + 35, e.Bounds.Top);
            e.DrawFocusRectangle();
        }

        void AtualizarTexto()
        {
            //Atualiza o texto acima do botão de Atualizar cotações, mostrando data e hora da ultima atualização, ou se a cotação padrão está aplicada.
            if (cotpadrao == false)
            {
                ExibirCotacao.Text = $"[Última atualização: {dataHora}]";
            }
            else
            {
                ExibirCotacao.Text = "[Cotação padrão aplicada.]";
            }
        }
        void SalvarJSON()
        {
            //Salva JSON com informações das variáveis para leituras posteriores.
            var cotacoes = new JObject
            { ["EUR"] = USDEUR, ["BRL"] = USDBRL, ["DataHora"] = (DateTime.Now).ToString(), ["Cotação padrão"] = cotpadrao};
            string jsonString = cotacoes.ToString();
            File.WriteAllText(caminhoCotacao, jsonString);
        }

        bool LerJSON()
        {
            //Lê o JSON e registra os valores nas variáveis, em caso de erro na leitura, declara cotações padrões.
            try
            {
                if (File.Exists(caminhoCotacao))
                {
                    string jsonString = File.ReadAllText(caminhoCotacao);
                    var cotacoes = JObject.Parse(jsonString);

                    USDBRL = (decimal)(cotacoes["BRL"] ?? 0);
                    USDEUR = (decimal)(cotacoes["EUR"] ?? 0);
                    dataHora = cotacoes["DataHora"]?.ToString() ?? string.Empty; ;
                    cotpadrao = (bool)(cotacoes["Cotação padrão"] ?? false);
                    return true;
                }
                else
                {
                    cotpadrao = true;
                    USDEUR = 0.92M;
                    USDBRL = 5.70M;
                    return false;
                }
            }
            catch
            {
                cotpadrao = true;
                USDEUR = 0.92M;
                USDBRL = 5.70M;
                return false;
            }
            
        }

        async void AtualizarCotacaoWeb()
        {
            //Captura dos dados via API e escrita nas variaveis.
            string urlAPI = "https://economia.awesomeapi.com.br/last/USD-BRL,USD-EUR";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(urlAPI);
                    response.EnsureSuccessStatusCode();
                    string resultadoWeb = await response.Content.ReadAsStringAsync();
                    JObject dadosWeb = JObject.Parse(resultadoWeb);
                    USDEUR = (decimal)(dadosWeb["USDEUR"]?["bid"] ?? 0);
                    USDBRL = (decimal)(dadosWeb["USDBRL"]?["bid"] ?? 0);
                }
                cotpadrao = false;
            }
            //Em caso de erro na captura da API, cotação padrão é aplicada.
            catch 
            {
                MessageBox.Show($"Ocorreu um erro ao atualizar as cotações via Web.\nAs cotações padrões serão carregadas.", "Erro ao atualizar cotações", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                USDEUR = 0.92M;
                USDBRL = 5.70M;
                cotpadrao = true;
            }
            //Sequência de funções para salvar e atualizar todas as informações necessárias.
            SalvarJSON();
            LerJSON();
            AtualizarTexto();
            AtualizarConversao();
        }


        private decimal TaxaDeCambio()
        {
            //Executa as operações para a definição do câmbio para o cálculo
            //Câmbio originalmente obtido em dolar, e convertido para as demais
            if (MoedaEntrada.Text == "BRL (Real)" && MoedaSaida.Text == "USD (Dólar)")
                return (1 / USDBRL);
            if (MoedaEntrada.Text == "BRL (Real)" && MoedaSaida.Text == "EUR (Euro)")
                return ((USDEUR / USDBRL));
            if (MoedaEntrada.Text == "USD (Dólar)" && MoedaSaida.Text == "BRL (Real)")
                return USDBRL;
            if (MoedaEntrada.Text == "USD (Dólar)" && MoedaSaida.Text == "EUR (Euro)")
                return USDEUR;
            if (MoedaEntrada.Text == "EUR (Euro)" && MoedaSaida.Text == "USD (Dólar)")
                return (1 / USDEUR);
            if (MoedaEntrada.Text == "EUR (Euro)" && MoedaSaida.Text == "BRL (Real)")
                return (USDBRL / USDEUR);
            else
                return 1;
        }

        private void AtualizarConversao()
        {
            //Captura a taxa de câmbio e altera os textos em tela
            cotacaocalc = TaxaDeCambio();
            //Executa a operação e escreve em tela
            if (Entrada.Text != "")
            {
                entradac = decimal.Parse(Entrada.Text, new CultureInfo("pt-BR"));
                saidac = entradac * cotacaocalc;
                switch (MoedaSaida.Text)
                {
                    case "BRL (Real)":
                        SaidaLabel.Text = saidac.ToString("F3") + " BRL";
                        break;

                    case "USD (Dólar)":
                        SaidaLabel.Text = saidac.ToString("F3") + " USD";
                        break;

                    case "EUR (Euro)":
                        SaidaLabel.Text = saidac.ToString("F3") + " EUR";
                        break;

                    default:
                        SaidaLabel.Text = "";
                        break;
                }
            }
            else
                SaidaLabel.Text = "";
        }

        private void MoedaEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarConversao();
        }

        private void AtualizarCotacao_Click(object sender, EventArgs e)
        {
            AtualizarCotacaoWeb();
        }

        private void ConversorMonetario_Load(object sender, EventArgs e)
        {
            //Ao iniciar, tenta ler o JSON com informações e atualiza o texto na tela, caso não exista, cotação padrão é aplicada e texto exibido de acordo
            if (LerJSON() == true)
            {
                AtualizarTexto();
            }
            else
            {
                MessageBox.Show($"Não há cotações registradas no sistema.\nAs cotações padrões serão carregadas.\n(Para obter as cotações mais recentes, clique no botão [Atualizar Cotações])", "Erro ao atualizar cotações", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AtualizarTexto();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botão de informações sobre a captura de dados.
            MessageBox.Show("As cotações são capturadas através da API gratuita https://economia.awesomeapi.com.br/", "Como funciona?");
        }

        private void MoedaSaida_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarConversao();
        }

        private void Entrada_TextChanged(object sender, EventArgs e)
        {
            AtualizarConversao();
        }

        private void Entrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false; // Permite números e teclas de controle (como Backspace)
            }
            else if (e.KeyChar == ',')
            {
                // Verifica se já existe uma vírgula e se já existe algum número antes de permitir a nova vírgula
                if (Entrada.Text.Contains(",") || Entrada.Text.Length == 0)
                {
                    e.Handled = true; // Bloqueia a entrada de uma nova vírgula se já houver uma ou se o campo estiver vazio
                }
                else
                {
                    e.Handled = false; // Permite a vírgula se for a primeira e houver número antes
                }
            }
            else
            {
                e.Handled = true; // Bloqueia qualquer outra entrada
            }
        }
    }

}


