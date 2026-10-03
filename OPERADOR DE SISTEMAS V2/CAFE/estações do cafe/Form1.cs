using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primavera
{
    public partial class Form1: Form
    {
        private ComboBox seletorEstacao;
        private Panel painelPrevia;
        private Label descricaoEstacao;

        public Form1()
        {
            InitializeComponent();
            MontarTelaDeEstacoes();
        }

        private void MontarTelaDeEstacoes()
        {
            Text = "Estações do ano";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(640, 360);
            MinimumSize = new Size(656, 399);

            Label titulo = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(24, 24),
                Text = "Estações do ano"
            };

            Label instrucao = new Label
            {
                AutoSize = true,
                Location = new Point(26, 88),
                Text = "Escolha uma estação:"
            };

            seletorEstacao = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(24, 114),
                Size = new Size(270, 28)
            };
            seletorEstacao.Items.AddRange(new object[] { "Primavera", "Verão", "Outono", "Inverno" });
            seletorEstacao.SelectedIndexChanged += AtualizarPrevia;

            painelPrevia = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(340, 64),
                Size = new Size(260, 210)
            };

            descricaoEstacao = new Label
            {
                AutoSize = false,
                Location = new Point(340, 286),
                Size = new Size(260, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(titulo);
            Controls.Add(instrucao);
            Controls.Add(seletorEstacao);
            Controls.Add(painelPrevia);
            Controls.Add(descricaoEstacao);

            seletorEstacao.SelectedIndex = 0;
        }

        private void AtualizarPrevia(object sender, EventArgs e)
        {
            switch (seletorEstacao.SelectedIndex)
            {
                case 0:
                    painelPrevia.BackColor = Color.PaleGreen;
                    // [Deus da Guerra -> CAFE: fotografia importada para a primavera]
                    painelPrevia.BackgroundImage = ObterImagemDaEstacao("estacao_primavera");
                    descricaoEstacao.Text = "Primavera — flores e renovação";
                    break;
                case 1:
                    painelPrevia.BackColor = Color.Gold;
                    // [Deus da Guerra -> CAFE: fotografia importada para o verão]
                    painelPrevia.BackgroundImage = ObterImagemDaEstacao("estacao_verao");
                    descricaoEstacao.Text = "Verão — dias quentes e ensolarados";
                    break;
                case 2:
                    painelPrevia.BackColor = Color.Peru;
                    // [Deus da Guerra -> CAFE: fotografia importada para o outono]
                    painelPrevia.BackgroundImage = ObterImagemDaEstacao("estacao_outono");
                    descricaoEstacao.Text = "Outono — folhas em tons quentes";
                    break;
                case 3:
                    painelPrevia.BackColor = Color.LightSkyBlue;
                    // [Deus da Guerra -> CAFE: fotografia importada para o inverno]
                    painelPrevia.BackgroundImage = ObterImagemDaEstacao("estacao_inverno");
                    descricaoEstacao.Text = "Inverno — clima frio";
                    break;
            }
        }

        // [Deus da Guerra -> CAFE: busca compartilhada das fotos das estações no arquivo de recursos]
        private Image ObterImagemDaEstacao(string nomeRecurso)
        {
            return Properties.Resources.ResourceManager.GetObject(nomeRecurso) as Image;
        }
    }
}
