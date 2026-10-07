namespace CalculadoraCafe
{
    // A palavra 'partial' quer dizer que essa classe é só a "metade da laranja".
    // A outra metade é aquele código que a gente comentou antes (onde faz as contas).
    // O C# junta os dois arquivos na hora de rodar o bagulho.
    partial class frm_calculadora
    {
        /// <summary>
        /// Isso aqui é tipo uma sacola onde o Windows guarda as coisas visuais da tela
        /// pra não deixar memória vazando depois.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// O método Dispose é o "caminhão de lixo" do C#.
        /// Quando vc fecha a janela no 'X', ele roda isso aqui pra liberar a memória do PC.
        /// </summary>
        /// <param name="disposing">true se for pra jogar tudo fora; false se não.</param>
        protected override void Dispose(bool disposing)
        {
            // Se tiver descartando as coisas e a "sacola" de componentes não tiver vazia...
            if (disposing && (components != null))
            {
                // ...ele joga a sacola no lixo (libera a memória de verdade).
                components.Dispose();
            }
            // Manda a classe pai (Form) fazer a parte dela da faxina.
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Mano, ESSE É O LUGAR PROIBIDO! kkkk
        /// O Visual Studio escreve isso sozinho. Se vc tentar mudar um número aqui na mão
        /// e errar, sua tela pode sumir ou bugar toda.
        /// Ele roda isso aqui pra dar "spawn" nos botões quando o app abre.
        /// </summary>
        private void InitializeComponent()
        {
            // Aqui o PC tá literalmente criando (dando 'new') cada pecinha da sua tela.
            // Label é texto, TextBox é onde digita, Button é botão, Panel é tipo um quadrado pra enfeitar.
            this.lbl_Calculador = new System.Windows.Forms.Label();
            this.lbl_Primeiro = new System.Windows.Forms.Label();
            this.lbl_Segundo = new System.Windows.Forms.Label();
            this.txt_primeiro = new System.Windows.Forms.TextBox();
            this.txt_segundo = new System.Windows.Forms.TextBox();
            this.btn_soma = new System.Windows.Forms.Button();
            this.btn_subtracao = new System.Windows.Forms.Button();
            this.btn_divisao = new System.Windows.Forms.Button();
            this.btn_multiplicacao = new System.Windows.Forms.Button();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();

            // Saca só: SuspendLayout "congela" a tela.
            // Ele faz isso pra poder jogar os botões nela sem o usuário ver a tela piscando enquanto monta.
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            //
            // Configurando o Titulão lá de cima (lbl_Calculador)
            //
            this.lbl_Calculador.AutoSize = true; // Deixa o tamanho da caixinha crescer junto com o texto.
            this.lbl_Calculador.Font = new System.Drawing.Font("Baskerville Old Face", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Fonte chique que vc escolheu.
            this.lbl_Calculador.Location = new System.Drawing.Point(222, 29); // Posição X e Y (onde ele fica na tela).
            this.lbl_Calculador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0); // Espaço em volta dele.
            this.lbl_Calculador.Name = "lbl_Calculador"; // O nome dele no código (o RG dele).
            this.lbl_Calculador.Size = new System.Drawing.Size(220, 31); // Tamanho em pixels (Largura, Altura).
            this.lbl_Calculador.TabIndex = 0; // Ordem de quem ganha o foco quando vc aperta a tecla 'Tab'.
            this.lbl_Calculador.Text = "CALCULADORA DO CAFÉ"; // O texto que aparece de fato pra galera ler.

            //
            // Configurando o texto "PRIMEIRO N° :"
            //
            this.lbl_Primeiro.AutoSize = true;
            this.lbl_Primeiro.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Primeiro.Location = new System.Drawing.Point(204, 100);
            this.lbl_Primeiro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Primeiro.Name = "lbl_Primeiro";
            this.lbl_Primeiro.Size = new System.Drawing.Size(137, 22);
            this.lbl_Primeiro.TabIndex = 3;
            this.lbl_Primeiro.Text = "PRIMEIRO N° :";

            //
            // Configurando o texto "SEGUNDO N° :"
            //
            this.lbl_Segundo.AutoSize = true;
            this.lbl_Segundo.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Segundo.Location = new System.Drawing.Point(208, 183);
            this.lbl_Segundo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Segundo.Name = "lbl_Segundo";
            this.lbl_Segundo.Size = new System.Drawing.Size(138, 22);
            this.lbl_Segundo.TabIndex = 4;
            this.lbl_Segundo.Text = "SEGUNDO N° :";

            //
            // Configurando a caixinha de digitar o primeiro número
            //
            this.txt_primeiro.Location = new System.Drawing.Point(349, 100);
            this.txt_primeiro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_primeiro.Name = "txt_primeiro";
            this.txt_primeiro.Size = new System.Drawing.Size(116, 22);
            this.txt_primeiro.TabIndex = 5;

            //
            // Configurando a caixinha de digitar o segundo número
            //
            this.txt_segundo.Location = new System.Drawing.Point(349, 183);
            this.txt_segundo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_segundo.Name = "txt_segundo";
            this.txt_segundo.Size = new System.Drawing.Size(116, 22);
            this.txt_segundo.TabIndex = 6;

            //
            // Arrumando o botão de SOMA
            //
            this.btn_soma.Location = new System.Drawing.Point(235, 273);
            this.btn_soma.Name = "btn_soma";
            this.btn_soma.Size = new System.Drawing.Size(75, 23);
            this.btn_soma.TabIndex = 7;
            this.btn_soma.Text = "SOMA";
            this.btn_soma.UseVisualStyleBackColor = true; // Deixa o botão com a cara padrão do Windows.

            // OLHA A MÁGICA AQUI: Lembra daquele código que a gente fez pro botão no outro arquivo?
            // É essa linha aqui embaixo que avisa o botão: "Quando o cara clicar (Click), roda o método btn_soma_Click!"
            this.btn_soma.Click += new System.EventHandler(this.btn_soma_Click);

            //
            // Arrumando o botão de SUBTRAÇÃO
            //
            this.btn_subtracao.Font = new System.Drawing.Font("Baskerville Old Face", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_subtracao.Location = new System.Drawing.Point(349, 273);
            this.btn_subtracao.Name = "btn_subtracao";
            this.btn_subtracao.Size = new System.Drawing.Size(96, 23);
            this.btn_subtracao.TabIndex = 8;
            this.btn_subtracao.Text = "SUBTRAÇÃO";
            this.btn_subtracao.UseVisualStyleBackColor = true;
            this.btn_subtracao.Click += new System.EventHandler(this.btn_subtracao_Click); // Lincando o clique tmb!

            //
            // Arrumando o botão de DIVISÃO
            //
            this.btn_divisao.Location = new System.Drawing.Point(212, 325);
            this.btn_divisao.Name = "btn_divisao";
            this.btn_divisao.Size = new System.Drawing.Size(75, 23);
            this.btn_divisao.TabIndex = 9;
            this.btn_divisao.Text = "DIVISÃO";
            this.btn_divisao.UseVisualStyleBackColor = true;
            this.btn_divisao.Click += new System.EventHandler(this.btn_divisao_Click);

            //
            // Arrumando o botão de MULTIPLICAÇÃO
            //
            this.btn_multiplicacao.Location = new System.Drawing.Point(327, 325);
            this.btn_multiplicacao.Name = "btn_multiplicacao";
            this.btn_multiplicacao.Size = new System.Drawing.Size(128, 23);
            this.btn_multiplicacao.TabIndex = 10;
            this.btn_multiplicacao.Text = "MULTIPLICAÇÃO";
            this.btn_multiplicacao.UseVisualStyleBackColor = true;
            this.btn_multiplicacao.Click += new System.EventHandler(this.btn_multiplicacao_Click);

            //
            // Arrumando o botão de LIMPAR
            //
            this.btn_limpar.Location = new System.Drawing.Point(342, 409);
            this.btn_limpar.Name = "btn_limpar";
            this.btn_limpar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpar.TabIndex = 11;
            this.btn_limpar.Text = "Limpar";
            this.btn_limpar.UseVisualStyleBackColor = true;
            this.btn_limpar.Click += new System.EventHandler(this.btn_limpar_Click);

            //
            // Configurando as imagens decorativas (pnl2)
            //
            // Aqui ele tá puxando uma imagem que vc botou lá nas Resources (arquivos do projeto)
            this.pnl2.BackgroundImage = global::CalculadoraCafe.Properties.Resources.CafeBarragan;
            // E o Stretch faz a imagem esticar pra caber certinho no quadrado, tipo papel de parede.
            this.pnl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnl2.Location = new System.Drawing.Point(462, 296);
            this.pnl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(175, 256);
            this.pnl2.TabIndex = 2;

            //
            // Configurando a outra imagem (pnl1)
            //
            this.pnl1.BackgroundImage = global::CalculadoraCafe.Properties.Resources.CafeRukia;
            this.pnl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnl1.Location = new System.Drawing.Point(13, 103);
            this.pnl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(175, 279);
            this.pnl1.TabIndex = 1;

            //
            // Panel de cima (A barra onde vai ficar o título)
            //
            // Olha que doido: ele pega o texto do título (lbl_Calculador) e joga PRA DENTRO do painel.
            this.panel1.Controls.Add(this.lbl_Calculador);
            this.panel1.Location = new System.Drawing.Point(5, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 72);
            this.panel1.TabIndex = 12;

            //
            // Configurações GERAIS da Janela (O Form inteiro)
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F); // Pra tela não bugar em monitor estranho.
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 564); // Tamanho exato da sua janela da calculadora.

            // Não adianta só criar os botões, vc tem que colar eles na janela!
            // O "this.Controls.Add" é literalmente "Janela, adiciona esse bagulho na tela".
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_limpar);
            this.Controls.Add(this.btn_multiplicacao);
            this.Controls.Add(this.btn_divisao);
            this.Controls.Add(this.btn_subtracao);
            this.Controls.Add(this.btn_soma);
            this.Controls.Add(this.txt_segundo);
            this.Controls.Add(this.txt_primeiro);
            this.Controls.Add(this.lbl_Segundo);
            this.Controls.Add(this.lbl_Primeiro);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.pnl1);

            // Deixando a janela bonitona com a fonte padrão e o título que vai lá na aba.
            this.Font = new System.Drawing.Font("Baskerville Old Face", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frm_calculadora";
            this.Text = "CALCULADORA DO CAFÉ";

            // Descongela o painel do título
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();

            // Lembra do SuspendLayout lá em cima? Aqui ele DESCONGELA a janela principal.
            // É nesse momento que a tela aparece desenhada pro usuário de uma vez só!
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Aqui embaixo é tipo o seu inventário do jogo.
        // Ele só tá listando todas as peças que existem na tela pra poder usar elas ali em cima.
        // É privado (private) pq nenhuma outra janela do seu programa precisa bisbilhotar os botões dessa aqui.
        private System.Windows.Forms.Label lbl_Calculador;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Label lbl_Primeiro;
        private System.Windows.Forms.Label lbl_Segundo;
        private System.Windows.Forms.TextBox txt_primeiro;
        private System.Windows.Forms.TextBox txt_segundo;
        private System.Windows.Forms.Button btn_soma;
        private System.Windows.Forms.Button btn_subtracao;
        private System.Windows.Forms.Button btn_divisao;
        private System.Windows.Forms.Button btn_multiplicacao;
        private System.Windows.Forms.Button btn_limpar;
        private System.Windows.Forms.Panel panel1;
    }
}
