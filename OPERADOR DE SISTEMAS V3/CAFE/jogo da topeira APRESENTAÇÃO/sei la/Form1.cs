using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace sei_la
{
    // MENU: mantém a ilha animada e as cores do projeto, com ações que funcionam.
    public partial class Form1 : Form
    {
        private Image gifMenu;
        private bool animandoMenu;
        private int quadroPendente;
        private System.Windows.Forms.Timer timerFundo;
        private Button botaoSetaAtual;
        private Button[] botoesMenu;
        private Label lblResumo;
        private Font fonteMenu;
        private Font fonteTitulo;
        private float escalaAnterior;
        private bool recursosLiberados;

        public Form1()
        {
            InitializeComponent();
            if (components == null) components = new System.ComponentModel.Container();
            DoubleBuffered = true; // Desenha o quadro inteiro antes de mostrá-lo, evitando piscar.
            AutoSize = false;
            MinimumSize = new Size(820, 560);
            KeyPreview = true;
            BackgroundImage = null; // O GIF será desenhado uma única vez em OnPaintBackground.

            Rectangle area = Screen.PrimaryScreen.WorkingArea;
            ClientSize = new Size(Math.Min(1100, area.Width - 48), Math.Min(690, area.Height - 90));
            botoesMenu = new[] { btnStart, btnLoadGame, btnPassword, btnOptions };
            foreach (Button botao in botoesMenu)
            {
                botao.Enter += Menu_MouseEnter; // A seta também acompanha Tab/teclado.
                botao.Cursor = Cursors.Hand;
                botao.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 32, 18);
                botao.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 29, 22);
            }

            lblResumo = new Label
            {
                AutoSize = false, ForeColor = Color.Wheat, BackColor = Color.FromArgb(27, 24, 20),
                TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(12, 0, 0, 0)
            };
            Controls.Add(lblResumo);
            Resize += Form1_Resize;
            MoverSeta(btnStart);
            AjustarLayout();
        }

        // Carrega preferências somente ao abrir; as partidas atualizam a mesma classe de progresso.
        private void Form1_Load(object sender, EventArgs e)
        {
            ProgressoJogo.Carregar();
            AudioRetro.Ativo = ProgressoJogo.SomAtivo;
            AtualizarResumo();
            gifMenu = (Image)Properties.Resources.FUNDO_gif.Clone();
            timerFundo = new System.Windows.Forms.Timer(components) { Interval = 40 };
            timerFundo.Tick += AtualizarFundo;
            ControlarAnimacao();
        }

        // ImageAnimator usa outra thread: ela apenas sinaliza o próximo quadro, sem tocar na tela.
        private void OnFrameChanged(object sender, EventArgs e)
        {
            Interlocked.Exchange(ref quadroPendente, 1);
        }

        // O timer executa na thread da interface; há no máximo 25 repinturas por segundo.
        private void AtualizarFundo(object sender, EventArgs e)
        {
            if (Interlocked.Exchange(ref quadroPendente, 0) != 0)
                Invalidate(true);
        }

        private void ControlarAnimacao()
        {
            if (gifMenu == null || timerFundo == null || recursosLiberados) return;
            bool deveAnimar = Visible && WindowState != FormWindowState.Minimized;
            if (deveAnimar && !animandoMenu && ImageAnimator.CanAnimate(gifMenu))
            {
                ImageAnimator.Animate(gifMenu, OnFrameChanged);
                animandoMenu = true;
                timerFundo.Start();
            }
            else if (!deveAnimar && animandoMenu)
            {
                timerFundo.Stop();
                ImageAnimator.StopAnimate(gifMenu, OnFrameChanged);
                animandoMenu = false;
            }
            Invalidate(true);
        }

        // Pausa o fundo enquanto o jogo está aberto, poupando processamento no laboratório.
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            ControlarAnimacao();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (gifMenu == null)
            {
                base.OnPaintBackground(e);
                return;
            }
            if (animandoMenu) ImageAnimator.UpdateFrames(gifMenu);
            e.Graphics.DrawImage(gifMenu, ClientRectangle);
            if (ClientSize.Width <= 0 || ClientSize.Height <= 0) return;
            // Sombra leve atrás das opções: preserva a ilha e melhora a leitura no projetor.
            using (var sombra = new LinearGradientBrush(ClientRectangle,
                Color.FromArgb(185, 14, 17, 20), Color.FromArgb(18, 14, 17, 20), 0f))
                e.Graphics.FillRectangle(sombra, ClientRectangle);
        }

        // Escala o menu inteiro conforme a área útil; as quatro opções permanecem visíveis.
        private void AjustarLayout()
        {
            if (botoesMenu == null) return;
            float escala = Math.Max(0.70f, Math.Min(1.55f,
                Math.Min(ClientSize.Width / 1100f, ClientSize.Height / 690f)));
            if (Math.Abs(escala - escalaAnterior) > 0.01f)
            {
                Font antigaMenu = fonteMenu, antigaTitulo = fonteTitulo;
                fonteMenu = new Font("Stencil", 43f * escala, FontStyle.Bold, GraphicsUnit.Pixel);
                fonteTitulo = new Font("Stencil", 60f * escala, FontStyle.Bold, GraphicsUnit.Pixel);
                foreach (Button botao in botoesMenu) botao.Font = fonteMenu;
                lblTitulo.Font = fonteTitulo;
                lblSombra.Font = fonteTitulo;
                if (antigaMenu != null) antigaMenu.Dispose();
                if (antigaTitulo != null) antigaTitulo.Dispose();
                escalaAnterior = escala;
            }

            int margem = (int)(62 * escala), altura = (int)(66 * escala), passo = altura + 7;
            int topo = Math.Max((int)(140 * escala), ClientSize.Height - passo * 4 - 58);
            for (int i = 0; i < botoesMenu.Length; i++)
                botoesMenu[i].SetBounds(margem, topo + i * passo, (int)(440 * escala), altura);
            lblTitulo.SetBounds(20, 24, ClientSize.Width - 40, (int)(90 * escala));
            lblSombra.SetBounds(23, 27, ClientSize.Width - 40, (int)(90 * escala));
            // WinForms não compõe a transparência de labels irmãos; o título usa o mesmo fundo.
            lblSombra.Visible = false;
            lblResumo.SetBounds(0, ClientSize.Height - 36, ClientSize.Width, 36);
            MoverSeta(botaoSetaAtual ?? btnStart);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AjustarLayout();
            ControlarAnimacao();
        }

        private void MoverSeta(Button botao)
        {
            botaoSetaAtual = botao;
            lblSeta.Location = new Point(botao.Left - lblSeta.Width - 8,
                botao.Top + (botao.Height - lblSeta.Height) / 2);
            lblSeta.BringToFront();
        }

        private void Menu_MouseEnter(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            if (botaoSetaAtual != botao) AudioRetro.Menu();
            MoverSeta(botao);
        }

        // Setas navegam no menu, Enter executa; Tab continua funcionando normalmente.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (botoesMenu == null) return base.ProcessCmdKey(ref msg, keyData);
            int indice = Array.IndexOf(botoesMenu, botaoSetaAtual);
            if (keyData == Keys.Up || keyData == Keys.Down)
            {
                indice = (indice + (keyData == Keys.Up ? 3 : 1)) % botoesMenu.Length;
                botoesMenu[indice].Focus();
                MoverSeta(botoesMenu[indice]);
                return true;
            }
            if (keyData == Keys.Enter && botaoSetaAtual != null)
            {
                botaoSetaAtual.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AtualizarResumo()
        {
            lblResumo.Text = "CAFÉ  /  ILHA DA TOUPEIRA     •     Recorde: " + ProgressoJogo.Recorde +
                " pontos     •     " + (ProgressoJogo.AcertosSalvos > 0
                ? "Salvo: " + ProgressoJogo.AcertosSalvos + "/30" : "Pronto para jogar") +
                (String.IsNullOrEmpty(ProgressoJogo.UltimoErro) ? "" : "     •     Salvamento indisponível");
        }

        private void AbrirJogo(Form2 jogo)
        {
            AudioRetro.Menu();
            // O menu é a janela principal. Ocultá-lo mantém o aplicativo aberto durante a partida.
            jogo.FormClosed += (s, args) =>
            {
                if (IsDisposed || Disposing) return;
                AtualizarResumo();
                Show();
                Activate();
                btnStart.Focus();
            };
            Hide();
            jogo.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ProgressoJogo.SalvarAcertos(0);
            AbrirJogo(new Form2(0));
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            if (ProgressoJogo.AcertosSalvos == 0)
            {
                MessageBox.Show(this, "Nenhuma partida em andamento.\nUse START para começar; cada acerto é salvo automaticamente.",
                    "LOAD GAME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AbrirJogo(new Form2(ProgressoJogo.AcertosSalvos));
        }

        // Atalho explícito para demonstrar o final na apresentação, sem alterar a partida salva.
        private void btnPassword_Click(object sender, EventArgs e)
        {
            using (Form janela = CriarDialogo("PASSWORD — modo apresentação", 470, 225))
            {
                Label ajuda = new Label { Text = "Código: TOUPEIRA30\nComeça em 27/30: faltam 3 acertos para a vitória.\nEsse modo não altera seu progresso nem o recorde.",
                    AutoSize = false, Bounds = new Rectangle(20, 18, 430, 70) };
                TextBox entrada = new TextBox { Bounds = new Rectangle(20, 100, 430, 28), CharacterCasing = CharacterCasing.Upper, MaxLength = 24 };
                Button entrar = new Button { Text = "Entrar", Bounds = new Rectangle(220, 155, 110, 36) };
                Button cancelar = new Button { Text = "Cancelar", Bounds = new Rectangle(340, 155, 110, 36), DialogResult = DialogResult.Cancel };
                entrar.Click += (s, args) =>
                {
                    if (entrada.Text.Trim().Equals("TOUPEIRA30", StringComparison.OrdinalIgnoreCase))
                        janela.DialogResult = DialogResult.OK;
                    else
                    {
                        MessageBox.Show(janela, "Digite TOUPEIRA30 para abrir a demonstração.", "Código inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        entrada.Focus();
                        entrada.SelectAll();
                    }
                };
                janela.Controls.AddRange(new Control[] { ajuda, entrada, entrar, cancelar });
                janela.AcceptButton = entrar;
                janela.CancelButton = cancelar;
                janela.Shown += (s, args) => entrada.Focus();
                if (janela.ShowDialog(this) == DialogResult.OK) AbrirJogo(new Form2(27, true));
            }
        }

        // Preferência de áudio persiste para a próxima abertura do programa.
        private void btnOptions_Click(object sender, EventArgs e)
        {
            using (Form janela = CriarDialogo("OPTIONS — como jogar", 540, 340))
            {
                var instrucoes = new Label { Bounds = new Rectangle(20, 18, 500, 195), Text =
                    "Acerte 30 toupeiras com o botão esquerdo do mouse.\nCada acerto vale 100 pontos. Não há limite de tempo.\n\nO martelo gira pela ponta do cabo ao acertar a toupeira.\n30/30 libera a animação de vitória da ilha.\nEsc: pausar  •  F11: tela cheia  •  M: ligar/desligar o som\n\nLOAD GAME retoma a partida salva automaticamente.\nPASSWORD demonstra o final em apenas três acertos." };
                var som = new CheckBox { Text = "Sons retrô ativados", Checked = ProgressoJogo.SomAtivo, Bounds = new Rectangle(20, 220, 420, 30) };
                var salvar = new Button { Text = "Salvar", Bounds = new Rectangle(285, 285, 110, 36), DialogResult = DialogResult.OK };
                var cancelar = new Button { Text = "Cancelar", Bounds = new Rectangle(405, 285, 110, 36), DialogResult = DialogResult.Cancel };
                janela.Controls.AddRange(new Control[] { instrucoes, som, salvar, cancelar });
                janela.AcceptButton = salvar;
                janela.CancelButton = cancelar;
                if (janela.ShowDialog(this) == DialogResult.OK)
                {
                    ProgressoJogo.SalvarOpcoes(som.Checked);
                    AudioRetro.Ativo = som.Checked;
                    if (som.Checked) AudioRetro.Menu(); else AudioRetro.Parar();
                    AtualizarResumo();
                }
            }
        }

        private static Form CriarDialogo(string titulo, int largura, int altura)
        {
            return new Form { Text = titulo, ClientSize = new Size(largura, altura),
                FormBorderStyle = FormBorderStyle.FixedDialog, StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false, MinimizeBox = false, ShowInTaskbar = false,
                Font = new Font("Segoe UI", 10f), AutoScaleMode = AutoScaleMode.Font };
        }

        // Chamado pelo Dispose do formulário, inclusive se ele for descartado sem ser mostrado.
        private void LiberarRecursosMenu()
        {
            if (recursosLiberados) return;
            recursosLiberados = true;
            if (timerFundo != null) timerFundo.Stop();
            if (animandoMenu && gifMenu != null) ImageAnimator.StopAnimate(gifMenu, OnFrameChanged);
            if (gifMenu != null) gifMenu.Dispose();
            if (fonteMenu != null) fonteMenu.Dispose();
            if (fonteTitulo != null) fonteTitulo.Dispose();
        }
    }
}
