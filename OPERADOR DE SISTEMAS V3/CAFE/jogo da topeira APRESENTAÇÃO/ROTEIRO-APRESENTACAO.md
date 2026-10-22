# Apresentação — Jogo da Toupeira

## Fala curta (cerca de 1 minuto)

“Este projeto é um jogo de reflexo desenvolvido em C# com Windows Forms. O objetivo é acertar 30 toupeiras, somando 100 pontos por acerto.

O programa funciona por eventos. Quando o usuário clica na toupeira, o código registra o acerto, atualiza o placar, reproduz um som e sorteia outra posição.

Usei variáveis para guardar o progresso, condições para verificar a vitória e métodos para organizar as ações. Os temporizadores controlam as animações sem interromper os cliques. A lógica da partida fica separada da interface, facilitando a manutenção.

O usuário pode pausar, continuar uma partida salva e escolher se quer som. Ao completar o objetivo, recebe uma animação de vitória e pode jogar novamente. O resultado é um jogo com regras claras e retorno visual e sonoro para cada ação.”

## Demonstração rápida

1. **START:** mostre dois acertos e os pontos aumentando.
2. **Esc → Voltar ao menu → LOAD GAME:** mostre que o progresso continua.
3. **Esc → Voltar ao menu → PASSWORD:** digite **TOUPEIRA30** e acerte três vezes para mostrar o final. Explique: “Este é o modo de demonstração; ele não altera a partida salva.”

## Se o professor pedir o código

- **EstadoPartida.cs → Acertar():** variável, condição, incremento e pontuação.
- **Form2.cs → AcertarToupeira():** evento do clique e chamada dos métodos.
- **Form2.cs → MoverToupeira():** sorteio da posição e limites da tela.

**Para lembrar:** objetivo → clique → regra → resultado.

Antes da aula: abra **sei la.sln** no Visual Studio 2022, execute com **F5** e confira o volume. **F11** alterna a tela cheia durante a partida; **M** liga/desliga o som.
