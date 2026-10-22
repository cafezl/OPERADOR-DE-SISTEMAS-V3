# Jogo da Toupeira — Café

Jogo em **C# e Windows Forms**, preparado para apresentar eventos, variáveis, condições, métodos e temporizadores na prática.

**Objetivo:** acertar 30 toupeiras. Cada uma vale 100 pontos; a vitória acontece com 3.000 pontos.

## Executar

Abra [sei la.sln](./sei%20la.sln) no **Visual Studio 2022**, com **Desenvolvimento para desktop com .NET** e o **Developer Pack do .NET Framework 4.8**, e pressione **F5**. O jogo, o som e a animação funcionam sem internet e não exigem pacotes NuGet.

## Controles

| Ação | Controle |
| --- | --- |
| Acertar a toupeira | Botão esquerdo do mouse; mire a cabeça do martelo |
| Pausar/continuar | Esc |
| Som ligado/desligado | M ou botão SOM |
| Tela cheia | F11 durante a partida |
| Recomeçar após vencer | JOGAR DE NOVO ou R |

**JOGAR** começa uma rodada; **CONTINUAR** retoma os acertos salvos; **OPÇÕES** liga o som e escolhe entre efeitos originais de moeda 8-bit, anel 16-bit ou caixa de aventura. Os sons são sintetizados para este projeto, sem gravações dos jogos citados como inspiração. O progresso e a preferência de áudio ficam no computador, em `%LOCALAPPDATA%\Cafe\IlhaDaToupeira\progresso.xml`.

**Para apresentar o final:** escolha **DEMONSTRAÇÃO** e use **TOUPEIRA30**. A demonstração começa em 27/30 e não altera os acertos salvos nem o recorde.

## Apresentação e vídeo

- [Roteiro curto para a apresentação](./ROTEIRO-APRESENTACAO.md).
- [Vídeo da vitória em MP4](./midia/vitoria-retro.mp4), com 8 segundos.

A mesma cena é animada dentro do jogo. O botão **ABRIR VÍDEO**, na vitória, abre o MP4 no player padrão do Windows. Os sons e a animação de vitória foram criados para o projeto; o menu e a imagem da toupeira foram aproveitados do trabalho existente.

## Onde estão os conceitos

| Arquivo | Responsabilidade |
| --- | --- |
| `Form1.cs` | Menu e eventos dos botões |
| `EstadoPartida.cs` | Contagem, pontuação e condição de vitória |
| `Form2.cs` | Eventos da partida, posição aleatória, pausa e timers |
| `ProgressoJogo.cs` | Leitura e gravação do progresso |
| `AudioRetro.cs`, `CenaVitoria.cs`, `MarteloCursor.cs`, `TemaIlha.cs` | Efeitos retrô originais, animação, cursor e identidade visual pixelada |

Os comentários explicam cada bloco de lógica. Os arquivos `.Designer.cs` e `Properties` contêm a estrutura gerada pelo Visual Studio.
