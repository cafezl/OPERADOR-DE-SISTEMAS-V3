# Ilha da Toupeira — Café

Uma aventura retrô em **C# e Windows Forms**: proteja o jardim da ilha acertando **50 toupeiras**. Cada acerto vale 100 pontos; a vitória chega com **5.000 pontos**.

## Abrir e jogar

Abra [sei la.sln](./sei%20la.sln) no **Visual Studio 2022**, com a carga **Desenvolvimento para desktop com .NET** e o **Developer Pack do .NET Framework 4.8**, e pressione **F5**. O jogo funciona sem internet e sem pacotes NuGet. Os arquivos da pasta `midia` são copiados automaticamente ao compilar.

## Menu

O cenário de ilha e templo foi desenhado para este jogo, inspirado nos menus de aventura do PlayStation 1.

- **START:** começa uma nova partida.
- **A LENDA DA ILHA:** mostra a história e permite continuar uma partida salva.
- **VER VÍDEO • O GOSTO DA FELICIDADE:** abre o vídeo de reflexão incluído na história.
- **PASSWORD:** cadastra ou acessa um perfil com nome e senha. O cadastro tem CPF com máscara `000.000.000-00` e validação; o CPF não é armazenado.
- **OPTIONS:** ajusta música e efeitos separadamente, testa a pancada e abre a demonstração do final.

São **dois Forms**: o menu troca de painéis na mesma janela, e o segundo Form contém a partida. O botão VOLTAR ou Esc retorna ao menu.

## Controles

| Ação | Controle |
| --- | --- |
| Acertar a toupeira | Botão esquerdo; mire a cabeça do martelo |
| Pausar/continuar | Esc durante a partida |
| Som ligado/desligado | M ou botão SOM |
| Tela cheia | F11 no menu e na partida |
| Recomeçar após vencer | JOGAR DE NOVO ou R |
| Mostrar o final rapidamente | OPTIONS → VER FINAL • DEMO: começa em 47/50 |

A demonstração não altera acertos salvos nem recordes. Frases curtas acompanham a evolução do jogador; a vitória apresenta a animação retrô, o troféu e as mensagens finais.

## Áudio, vídeo e progresso

A partida usa o áudio enviado pelo Café, com repetição automática. A pancada usa um efeito curto de *Super Mario Bros.*; a música do menu e os sinais da interface são gerados pelo código. Música e efeitos podem tocar juntos, com volumes independentes. [Origens dos áudios](./midia/ORIGENS-AUDIO.md).

A animação da vitória roda dentro do jogo. **ABRIR VÍDEO** abre a [versão MP4 da vitória](./midia/vitoria-retro.mp4) no player do Windows. A história também inclui o [vídeo sobre o gosto da felicidade](./midia/video-felicidade.mp4), fornecido pelo Café.

Perfis, recordes, volumes e progresso ficam **somente neste computador**, em `%LOCALAPPDATA%\Cafe\IlhaDaToupeira`. Cada jogador tem seu próprio salvamento; o visitante mantém o arquivo antigo. As senhas são guardadas como hash com salt. Não há servidor nem sincronização entre computadores.

## Organização do código

| Arquivo | Responsabilidade |
| --- | --- |
| `Form1.cs`, `CenarioMenu.cs` | Menu, história, cadastro, opções e cenário proporcional |
| `Form2.cs`, `EstadoPartida.cs` | Partida, pontuação, alvo, pausa e vitória |
| `PerfisJogador.cs`, `ProgressoJogo.cs` | Validação, contas locais e salvamento |
| `AudioRetro.cs` | Mistura de música e efeitos, pausa e volumes |
| `CenaVitoria.cs`, `MarteloCursor.cs`, `TemaIlha.cs` | Animação, martelo e ícones |

Os comentários explicam os blocos principais. Os arquivos `.Designer.cs` e `Properties` mantêm a estrutura do Visual Studio.
