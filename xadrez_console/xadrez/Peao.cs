using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    public class Peao : Peca
    {
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(Posicao.linha, Posicao.coluna);

            //acima
            Posicao.definirValores(Posicao.linha - 1, Posicao.coluna);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao.definirValores(Posicao.linha - 1, Posicao.coluna);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            return matriz;
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }


        public override string ToString()
        {
            return "P";
        }
    }
}