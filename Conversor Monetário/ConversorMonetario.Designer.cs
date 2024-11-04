namespace Conversor_Monetário
{
    partial class ConversorMonetario
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MoedaEntrada = new ComboBox();
            MoedaSaida = new ComboBox();
            EntradaLabel = new Label();
            SaidaLabel = new Label();
            Entrada = new TextBox();
            AtualizarCotacao = new Button();
            button1 = new Button();
            ExibirCotacao = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // MoedaEntrada
            // 
            MoedaEntrada.Anchor = AnchorStyles.None;
            MoedaEntrada.BackColor = SystemColors.Window;
            MoedaEntrada.DropDownStyle = ComboBoxStyle.DropDownList;
            MoedaEntrada.FlatStyle = FlatStyle.System;
            MoedaEntrada.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MoedaEntrada.ForeColor = SystemColors.Desktop;
            MoedaEntrada.Location = new Point(330, 267);
            MoedaEntrada.MaximumSize = new Size(280, 0);
            MoedaEntrada.MinimumSize = new Size(190, 0);
            MoedaEntrada.Name = "MoedaEntrada";
            MoedaEntrada.Size = new Size(190, 33);
            MoedaEntrada.TabIndex = 0;
            MoedaEntrada.TabStop = false;
            MoedaEntrada.SelectedIndexChanged += MoedaEntrada_SelectedIndexChanged;
            // 
            // MoedaSaida
            // 
            MoedaSaida.Anchor = AnchorStyles.None;
            MoedaSaida.BackColor = SystemColors.Window;
            MoedaSaida.DropDownStyle = ComboBoxStyle.DropDownList;
            MoedaSaida.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MoedaSaida.ForeColor = SystemColors.MenuText;
            MoedaSaida.Location = new Point(756, 267);
            MoedaSaida.MaximumSize = new Size(280, 0);
            MoedaSaida.MinimumSize = new Size(190, 0);
            MoedaSaida.Name = "MoedaSaida";
            MoedaSaida.Size = new Size(190, 33);
            MoedaSaida.TabIndex = 1;
            MoedaSaida.TabStop = false;
            MoedaSaida.SelectedIndexChanged += MoedaSaida_SelectedIndexChanged;
            // 
            // EntradaLabel
            // 
            EntradaLabel.Anchor = AnchorStyles.None;
            EntradaLabel.AutoSize = true;
            EntradaLabel.BackColor = Color.Transparent;
            EntradaLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EntradaLabel.ForeColor = SystemColors.ActiveCaptionText;
            EntradaLabel.Location = new Point(345, 319);
            EntradaLabel.Name = "EntradaLabel";
            EntradaLabel.Size = new Size(134, 25);
            EntradaLabel.TabIndex = 2;
            EntradaLabel.Text = "Insira o valor:";
            // 
            // SaidaLabel
            // 
            SaidaLabel.Anchor = AnchorStyles.None;
            SaidaLabel.AutoSize = true;
            SaidaLabel.BackColor = Color.Transparent;
            SaidaLabel.Font = new Font("Segoe UI", 15.25F, FontStyle.Bold);
            SaidaLabel.ForeColor = SystemColors.Desktop;
            SaidaLabel.Location = new Point(776, 346);
            SaidaLabel.Name = "SaidaLabel";
            SaidaLabel.Size = new Size(31, 30);
            SaidaLabel.TabIndex = 3;
            SaidaLabel.Text = "...";
            SaidaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Entrada
            // 
            Entrada.Anchor = AnchorStyles.None;
            Entrada.BackColor = SystemColors.Control;
            Entrada.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Entrada.ForeColor = SystemColors.MenuText;
            Entrada.Location = new Point(343, 346);
            Entrada.Name = "Entrada";
            Entrada.ShortcutsEnabled = false;
            Entrada.Size = new Size(154, 35);
            Entrada.TabIndex = 4;
            Entrada.TextAlign = HorizontalAlignment.Center;
            Entrada.TextChanged += Entrada_TextChanged;
            Entrada.KeyPress += Entrada_KeyPress;
            // 
            // AtualizarCotacao
            // 
            AtualizarCotacao.Anchor = AnchorStyles.Bottom;
            AtualizarCotacao.BackColor = Color.Transparent;
            AtualizarCotacao.BackgroundImage = Properties.Resources.BotaoAtualizar;
            AtualizarCotacao.BackgroundImageLayout = ImageLayout.Stretch;
            AtualizarCotacao.FlatAppearance.BorderSize = 0;
            AtualizarCotacao.FlatAppearance.MouseDownBackColor = Color.Transparent;
            AtualizarCotacao.FlatStyle = FlatStyle.Flat;
            AtualizarCotacao.ForeColor = SystemColors.ControlText;
            AtualizarCotacao.Location = new Point(555, 651);
            AtualizarCotacao.Margin = new Padding(5);
            AtualizarCotacao.MaximumSize = new Size(152, 25);
            AtualizarCotacao.MinimumSize = new Size(152, 25);
            AtualizarCotacao.Name = "AtualizarCotacao";
            AtualizarCotacao.Size = new Size(152, 25);
            AtualizarCotacao.TabIndex = 5;
            AtualizarCotacao.UseVisualStyleBackColor = false;
            AtualizarCotacao.Click += AtualizarCotacao_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = Properties.Resources.BotaoInterrogacao;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(712, 651);
            button1.Margin = new Padding(0);
            button1.MaximumSize = new Size(25, 25);
            button1.MinimumSize = new Size(25, 25);
            button1.Name = "button1";
            button1.Size = new Size(25, 25);
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ExibirCotacao
            // 
            ExibirCotacao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ExibirCotacao.BackColor = Color.Transparent;
            ExibirCotacao.Location = new Point(502, 631);
            ExibirCotacao.Name = "ExibirCotacao";
            ExibirCotacao.Size = new Size(269, 15);
            ExibirCotacao.TabIndex = 7;
            ExibirCotacao.Text = "...";
            ExibirCotacao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(330, 240);
            label1.Name = "label1";
            label1.Size = new Size(163, 25);
            label1.TabIndex = 8;
            label1.Text = "Escolha a moeda:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(756, 240);
            label2.Name = "label2";
            label2.Size = new Size(163, 25);
            label2.TabIndex = 9;
            label2.Text = "Escolha a moeda:";
            // 
            // ConversorMonetario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.foto_fundo_moeda;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ExibirCotacao);
            Controls.Add(button1);
            Controls.Add(AtualizarCotacao);
            Controls.Add(Entrada);
            Controls.Add(SaidaLabel);
            Controls.Add(EntradaLabel);
            Controls.Add(MoedaSaida);
            Controls.Add(MoedaEntrada);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "ConversorMonetario";
            Text = "Conversor monetário";
            Load += ConversorMonetario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox MoedaEntrada;
        private ComboBox MoedaSaida;
        private Label EntradaLabel;
        private Label SaidaLabel;
        private TextBox Entrada;
        private Button AtualizarCotacao;
        private Button button1;
        private Label ExibirCotacao;
        private Label label1;
        private Label label2;
    }
}
