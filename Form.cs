using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace VoteCalculator
{
    public partial class Form : System.Windows.Forms.Form
    {
        int totalAprovacoes = 0;
        int totalReprovacoes = 0;
        int numRodadas = 0;
        List<string> rodadas = new() { "Rodada1", "Rodada2" };

        private readonly Label lblCabecalho = new();
        private Label lblResultado = new();
        private Label lblTotalAprovacoes = new();
        private Label lblTotalReprovacoes = new();
        private Label lblNumRodadas = new();
        private Label lblTituloRodadas = new();
        private Label lblExplicacao = new();

        private TextBox txtA = new();
        private TextBox txtB = new();
        private TextBox txtC = new();
        private Button btnCalcular = new();
        private Button btnReiniciar = new();
        private Button btnSalvar = new();
        private ListBox lstRodadas = new();

        public Form()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            lblCabecalho.Text = "Calculador de Votos";
            lblCabecalho.Location = new System.Drawing.Point(20, 10);
            lblCabecalho.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            lblCabecalho.Width = 400;

            lblExplicacao.Text = "A = Peso principal. B e C são pesos secundários que influenciam o resultado.";
            lblExplicacao.Location = new System.Drawing.Point(20, 40);
            lblExplicacao.Width = 400;
            lblExplicacao.AutoSize = true;

            lblTituloRodadas.Text = "Histórico das Rodadas";
            lblTituloRodadas.Location = new System.Drawing.Point(340, 200);
            lblTituloRodadas.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            lblTituloRodadas.Width = 200;

            lblResultado.Text = "Resultado";
            lblResultado.Location = new System.Drawing.Point(20, 70);
            lblResultado.Width = 300;
            lblResultado.AutoSize = false;

            lblTotalAprovacoes.Text = "Total de Aprovações: 0";
            lblTotalAprovacoes.Location = new System.Drawing.Point(20, 100);
            lblTotalAprovacoes.Width = 300;
            lblTotalAprovacoes.AutoSize = false;

            lblTotalReprovacoes.Text = "Total de Reprovações: 0";
            lblTotalReprovacoes.Location = new System.Drawing.Point(20, 130);
            lblTotalReprovacoes.Width = 300;
            lblTotalReprovacoes.AutoSize = false;

            lblNumRodadas.Text = "Número de Rodadas: 0";
            lblNumRodadas.Location = new System.Drawing.Point(20, 160);
            lblNumRodadas.Width = 300;
            lblNumRodadas.AutoSize = false;

            txtA.Location = new System.Drawing.Point(20, 190);
            txtA.Width = 100;
            txtA.KeyPress += Txt_KeyPress;

            txtB.Location = new System.Drawing.Point(20, 220);
            txtB.Width = 100;
            txtB.KeyPress += Txt_KeyPress;

            txtC.Location = new System.Drawing.Point(20, 250);
            txtC.Width = 100;
            txtC.KeyPress += Txt_KeyPress;

            btnCalcular.Text = "Calcular";
            btnCalcular.Location = new System.Drawing.Point(20, 280);
            btnCalcular.Click += BtnCalcular_Click;

            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.Location = new System.Drawing.Point(120, 280);
            btnReiniciar.Click += BtnReiniciar_Click;

            btnSalvar.Text = "Salvar";
            btnSalvar.Location = new System.Drawing.Point(220, 280);
            btnSalvar.Click += BtnSalvar_Click;

            lstRodadas.Location = new System.Drawing.Point(340, 220);
            lstRodadas.Width = 300;
            lstRodadas.Height = 150;
            lstRodadas.ScrollAlwaysVisible = true;

            Controls.Add(lblCabecalho);
            Controls.Add(lblExplicacao);
            Controls.Add(lblResultado);
            Controls.Add(lblTotalAprovacoes);
            Controls.Add(lblTotalReprovacoes);
            Controls.Add(lblNumRodadas);
            Controls.Add(txtA);
            Controls.Add(txtB);
            Controls.Add(txtC);
            Controls.Add(btnCalcular);
            Controls.Add(btnReiniciar);
            Controls.Add(btnSalvar);
            Controls.Add(lstRodadas);
            Controls.Add(lblTituloRodadas);
        }

        private void Txt_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Verifica se o caractere digitado é 0, 1 ou Backspace
            if (e.KeyChar != '0' && e.KeyChar != '1' && e.KeyChar != (char)Keys.Back)
            {
                // Cancela a tecla, impedindo que qualquer outro caractere seja digitado
                e.Handled = true;

                // Exibe uma mensagem de aviso ao usuário
                MessageBox.Show("Digite apenas 0 ou 1.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnSalvar_Click(object? sender, EventArgs e)
        {
            var dados = new
            {
                Rodadas = rodadas,
                TotalAprovacoes = totalAprovacoes,
                TotalReprovacoes = totalReprovacoes
            };

            string json = JsonConvert.SerializeObject(dados, Formatting.Indented);
            File.WriteAllText("rodadas.json", json);
            MessageBox.Show("Dados salvos com sucesso!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCalcular_Click(object? sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtA.Text);
                int b = int.Parse(txtB.Text);
                int c = int.Parse(txtC.Text);

                string explicacao = "A = Peso principal. B e C são pesos secundários que influenciam o resultado.";

                if (a == 1)
                {
                    if (b == 1 || c == 1)
                    {
                        lblResultado.Text = $"Aprovado: A={a}, B={b}, C={c} ({explicacao})";
                        totalAprovacoes++;
                    }
                    else
                    {
                        lblResultado.Text = $"Reprovado: A={a}, B={b}, C={c} ({explicacao})";
                        totalReprovacoes++;
                    }
                }
                else
                {
                    lblResultado.Text = $"Reprovado: A={a}, B={b}, C={c} ({explicacao})";
                    totalReprovacoes++;
                }

                lblTotalAprovacoes.Text = "Total de Aprovações: " + totalAprovacoes;
                lblTotalReprovacoes.Text = "Total de Reprovações: " + totalReprovacoes;

                numRodadas++;
                lblNumRodadas.Text = "Número de Rodadas: " + numRodadas;

                string rodadaInfo = $"Rodada {numRodadas} - {DateTime.Now}: {lblResultado.Text}";
                rodadas.Add(rodadaInfo);
                lstRodadas.Items.Add(rodadaInfo);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, digite apenas números 0 ou 1 em cada campo.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnReiniciar_Click(object? sender, EventArgs e)
        {
            txtA.Text = "0";
            txtB.Text = "0";
            txtC.Text = "0";
            lblResultado.Text = "Resultado";
            numRodadas = 0;
            totalAprovacoes = 0;
            totalReprovacoes = 0;
            lblNumRodadas.Text = "Número de Rodadas: 0";
            lblTotalAprovacoes.Text = "Total de Aprovações: 0";
            lblTotalReprovacoes.Text = "Total de Reprovações: 0";
            lstRodadas.Items.Clear();
            rodadas.Clear();
        }
    }
}
