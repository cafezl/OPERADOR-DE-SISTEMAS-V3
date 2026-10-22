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
        private Label lblHistoria;
        private Label lblMissao;
        private PictureBox iconeMissao;
        private Label lblAssinatura;
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
            string[] icones = { "jogar", "continuar", "chave", "opcoes" };
            string[] nomes = { "JOGAR", "CONTINUAR", "DEMONSTRAÇÃO", "OPÇÕES" };
            for (int i = 0; i < botoesMenu.Length; i++)
            {
                botoesMenu[i].Text = nomes[i];
                TemaIlha.Aplicar(botoesMenu[i], icones[i], i == 0);
            }
            foreach (Button botao in botoesMenu)
            {
                botao.Enter += Menu_MouseEnter; // A seta também acompanha Tab/teclado.
                botao.Cursor = Cursors.Hand;
            }

            Text = "Ilha da Toupeira • Café";
            lblTitulo.Text = ""; // O título é desenhado com contorno grosso, como a tela de um jogo de plataforma.
            lblTitulo.AccessibleName = "ILHA DA TOUPEIRA";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            lblTitulo.ForeColor = Color.FromArgb(255, 211, 96);
            lblTitulo.Paint += PintarTituloRetro;
            lblAssinatura = new Label
            {
                Text = "UMA AVENTURA DE REFLEXOS  /  CAFÉ", AutoSize = false,
                BackColor = Color.Transparent, ForeColor = Color.FromArgb(155, 218, 191),
                Font = new Font("Consolas", 10, FontStyle.Bold)
            };
            lblMissao = new Label
            {
                Text = "PROTEJA O JARDIM", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(52, 0, 0, 0),
                BackColor = Color.FromArgb(22, 48, 40), ForeColor = Color.FromArgb(255, 211, 96),
                Font = new Font("Consolas", 13, FontStyle.Bold)
            };
            iconeMissao = new PictureBox
            {
                Image = TemaIlha.CriarIcone("alvo", Color.FromArgb(255, 211, 96)),
                BackColor = Color.FromArgb(22, 48, 40), SizeMode = PictureBoxSizeMode.CenterImage
            };
            lblHistoria = new Label
            {
                Text = "A tranquilidade da ilha foi interrompida por toupeiras que tomaram o jardim.\n\nPegue o martelo, mande cada uma de volta à toca e complete 30 acertos para devolver a paz à ilha.\n\n30 ACERTOS  •  3.000 PONTOS",
                AutoSize = false, Padding = new Padding(18, 12, 18, 10),
                BackColor = Color.FromArgb(22, 48, 40), ForeColor = Color.FromArgb(224, 234, 224),
                Font = new Font("Consolas", 10)
            };
            Controls.AddRange(new Control[] { lblAssinatura, lblMissao, lblHistoria, iconeMissao });
            iconeMissao.BringToFront();
            lblResumo = new Label
            {
                AutoSize = false, ForeColor = Color.FromArgb(186, 210, 194), BackColor = Color.FromArgb(13, 29, 25),
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
            AudioRetro.EstiloAcerto = ProgressoJogo.EstiloSom;
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
                fonteMenu = new Font("Consolas", 18f * escala, FontStyle.Bold, GraphicsUnit.Pixel);
                fonteTitulo = new Font("Consolas", 54f * escala, FontStyle.Bold, GraphicsUnit.Pixel);
                foreach (Button botao in botoesMenu) botao.Font = fonteMenu;
                lblTitulo.Font = fonteTitulo;
                lblSombra.Font = fonteTitulo;
                if (antigaMenu != null) antigaMenu.Dispose();
                if (antigaTitulo != null) antigaTitulo.Dispose();
                escalaAnterior = escala;
            }

            int margem = (int)(62 * escala), altura = (int)(56 * escala), passo = altura + 10;
            int topo = Math.Max((int)(240 * escala), ClientSize.Height - passo * 4 - 66);
            for (int i = 0; i < botoesMenu.Length; i++)
                botoesMenu[i].SetBounds(margem, topo + i * passo, (int)(355 * escala), altura);
            lblAssinatura.SetBounds(margem + 4, (int)(40 * escala), 420, 30);
            lblTitulo.SetBounds(margem - 4, (int)(80 * escala), (int)(480 * escala), (int)(145 * escala));
            int larguraHistoria = Math.Min(335, ClientSize.Width - margem * 2 - (int)(395 * escala));
            int xHistoria = ClientSize.Width - margem - larguraHistoria;
            int yHistoria = Math.Max(154, (int)(225 * escala));
            lblMissao.SetBounds(xHistoria, yHistoria, larguraHistoria, 52);
            iconeMissao.SetBounds(xHistoria + 18, yHistoria + 14, 24, 24);
            lblHistoria.SetBounds(xHistoria, yHistoria + 52, larguraHistoria,
                Math.Min(245, ClientSize.Height - yHistoria - 106));
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

        private void PintarTituloRetro(object sender, PaintEventArgs e)
        {
            if (fonteTitulo == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.None;
            using (GraphicsPath caminho = new GraphicsPath())
            using (StringFormat formato = new StringFormat())
            using (Pen contorno = new Pen(Color.FromArgb(53, 36, 24), 8))
            using (Pen brilho = new Pen(Color.FromArgb(255, 240, 166), 2))
            using (Brush sombra = new SolidBrush(Color.FromArgb(170, 17, 29, 24)))
            using (Brush letra = new SolidBrush(Color.FromArgb(255, 211, 96)))
            {
                formato.Alignment = StringAlignment.Near;
                formato.LineAlignment = StringAlignment.Center;
                caminho.AddString("ILHA DA\nTOUPEIRA", fonteTitulo.FontFamily, (int)FontStyle.Bold,
                    fonteTitulo.Size, new RectangleF(0, 0, lblTitulo.ClientSize.Width - 8,
                    lblTitulo.ClientSize.Height - 8), formato);
                using (Matrix deslocamento = new Matrix())
                {
                    deslocamento.Translate(6, 6);
                    caminho.Transform(deslocamento);
                    e.Graphics.FillPath(sombra, caminho);
                    deslocamento.Translate(-6, -6);
                    caminho.Transform(deslocamento);
                }
                e.Graphics.DrawPath(contorno, caminho);
                e.Graphics.FillPath(letra, caminho);
                e.Graphics.DrawPath(brilho, caminho);
            }
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
            lblResumo.Text = "ILHA DA TOUPEIRA     •     Recorde: " + ProgressoJogo.Recorde +
                " pontos     •     " + (ProgressoJogo.AcertosSalvos > 0
                ? "Salvo: " + ProgressoJogo.AcertosSalvos + "/30" : "Pronto para jogar") +
                (String.IsNullOrEmpty(ProgressoJogo.UltimoErro) ? "" : "     •     Salvamento indisponível");
        }

        private void AbrirJogo(Form2 jogo)
        {
            AudioRetro.Inicio();
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
                MessageBox.Show(this, "Sua aventura ainda não começou.\nEscolha JOGAR; cada acerto será salvo automaticamente.",
                    "Continuar aventura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AbrirJogo(new Form2(ProgressoJogo.AcertosSalvos));
        }

        // Atalho explícito para demonstrar o final na apresentação, sem alterar a partida salva.
        private void btnPassword_Click(object sender, EventArgs e)
        {
            using (Form janela = CriarDialogo("Demonstração — mostrar o final", 470, 225))
            {
                Label ajuda = new Label { Text = "Código: TOUPEIRA30\nComeça em 27/30: faltam 3 acertos para a vitória.\nEsse modo não altera seu progresso nem o recorde.",
                    AutoSize = false, Bounds = new Rectangle(20, 18, 430, 70) };
                TextBox entrada = new TextBox { Bounds = new Rectangle(20, 100, 430, 28), CharacterCasing = CharacterCasing.Upper, MaxLength = 24 };
                Button entrar = new Button { Text = "Entrar", Bounds = new Rectangle(220, 155, 110, 36) };
                Button cancelar = new Button { Text = "Cancelar", Bounds = new Rectangle(340, 155, 110, 36), DialogResult = DialogResult.Cancel };
                TemaIlha.Aplicar(entrar, "chave", true);
                TemaIlha.Aplicar(cancelar, "menu");
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
            bool somAnterior = AudioRetro.Ativo;
            int estiloAnterior = AudioRetro.EstiloAcerto;
            using (Form janela = CriarDialogo("Opções — sua aventura", 540, 390))
            {
                var instrucoes = new Label { Bounds = new Rectangle(20, 18, 500, 150), Text =
                    "Proteja o jardim: acerte 30 toupeiras com o mouse.\nCada acerto vale 100 pontos. Jogue no seu ritmo.\n\nMire a cabeça do martelo na toupeira. Complete 30/30 para vencer.\nEsc: pausar  •  F11: tela cheia  •  M: som\nCONTINUAR retoma sua aventura. DEMONSTRAÇÃO mostra o final." };
                var som = new CheckBox { Text = "Sons retrô ativados", Checked = ProgressoJogo.SomAtivo, Bounds = new Rectangle(20, 177, 420, 30) };
                var estiloRotulo = new Label { Text = "ESTILO DO EFEITO DE ACERTO", Bounds = new Rectangle(20, 218, 290, 25),
                    ForeColor = Color.FromArgb(255, 211, 96), Font = new Font("Consolas", 10, FontStyle.Bold) };
                var estilo = new ComboBox { Bounds = new Rectangle(20, 246, 310, 34), DropDownStyle = ComboBoxStyle.DropDownList,
                    BackColor = Color.FromArgb(13, 29, 25), ForeColor = Color.FromArgb(241, 245, 231),
                    Font = new Font("Consolas", 10, FontStyle.Bold) };
                estilo.Items.AddRange(new object[] { "MOEDA • 8 BITS", "ANEL • 16 BITS", "CAIXA • AVENTURA" });
                estilo.SelectedIndex = Math.Max(0, Math.Min(2, ProgressoJogo.EstiloSom));
                var testar = new Button { Text = "TESTAR SOM", Bounds = new Rectangle(350, 244, 165, 38) };
                testar.Enabled = som.Checked;
                som.CheckedChanged += delegate { testar.Enabled = som.Checked; };
                testar.Click += delegate
                {
                    AudioRetro.EstiloAcerto = estilo.SelectedIndex;
                    AudioRetro.Ativo = som.Checked;
                    AudioRetro.Acerto();
                };
                var salvar = new Button { Text = "SALVAR", Bounds = new Rectangle(285, 326, 110, 38), DialogResult = DialogResult.OK };
                var cancelar = new Button { Text = "VOLTAR", Bounds = new Rectangle(405, 326, 110, 38), DialogResult = DialogResult.Cancel };
                TemaIlha.Aplicar(salvar, "continuar", true);
                TemaIlha.Aplicar(cancelar, "menu");
                TemaIlha.Aplicar(testar, "som");
                janela.Controls.AddRange(new Control[] { instrucoes, som, estiloRotulo, estilo, testar, salvar, cancelar });
                janela.AcceptButton = salvar;
                janela.CancelButton = cancelar;
                if (janela.ShowDialog(this) == DialogResult.OK)
                {
                    ProgressoJogo.SalvarAudio(som.Checked, estilo.SelectedIndex);
                    AudioRetro.EstiloAcerto = estilo.SelectedIndex;
                    AudioRetro.Ativo = som.Checked;
                    if (som.Checked) AudioRetro.Menu(); else AudioRetro.Parar();
                    AtualizarResumo();
                }
                else
                {
                    AudioRetro.EstiloAcerto = estiloAnterior;
                    AudioRetro.Ativo = somAnterior;
                    if (!somAnterior) AudioRetro.Parar();
                }
            }
        }

        private static Form CriarDialogo(string titulo, int largura, int altura)
        {
            return new Form { Text = titulo, ClientSize = new Size(largura, altura),
                FormBorderStyle = FormBorderStyle.FixedDialog, StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false, MinimizeBox = false, ShowInTaskbar = false,
                BackColor = Color.FromArgb(20, 43, 35), ForeColor = Color.FromArgb(231, 236, 221),
                Font = new Font("Consolas", 10f), AutoScaleMode = AutoScaleMode.Font };
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
            if (iconeMissao != null && iconeMissao.Image != null) iconeMissao.Image.Dispose();
        }
    }
}
