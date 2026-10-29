using System;

namespace sei_la
{
    // A regra do jogo fica separada da tela: fica fácil explicar e conferir a contagem.
    public sealed class EstadoPartida
    {
        public const int Meta = 50;
        public const int PontosPorAcerto = 100;
        public int Acertos { get; private set; }
        public int Pontos { get { return Acertos * PontosPorAcerto; } }
        public int Restantes { get { return Meta - Acertos; } }
        public bool Venceu { get { return Acertos == Meta; } }

        public EstadoPartida(int acertosIniciais)
        {
            // Um salvamento ou o modo de demonstração nunca deve começar já na vitória.
            Acertos = Math.Max(0, Math.Min(Meta - 1, acertosIniciais));
        }

        public bool Acertar()
        {
            // Cliques recebidos depois da vitória não acrescentam pontos extras.
            if (Venceu) return false;
            Acertos++;
            return true;
        }

        public void Reiniciar()
        {
            Acertos = 0;
        }
    }
}
