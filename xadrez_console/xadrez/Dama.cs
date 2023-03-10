using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    public class Dama : Peca
    {
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "D";
        }
    }
}