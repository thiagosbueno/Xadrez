using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
