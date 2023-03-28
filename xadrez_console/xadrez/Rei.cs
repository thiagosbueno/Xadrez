using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    public class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(Posicao.linha, Posicao.coluna);

            //acima
            Posicao.definirValores(Posicao.linha - 1, Posicao.coluna);
            if(Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;


            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //nordeste
            Posicao.definirValores(Posicao.linha - 1, Posicao.coluna + 1);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //leste
            Posicao.definirValores(Posicao.linha, Posicao.coluna + 1);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //sudeste
            Posicao.definirValores(Posicao.linha + 1, Posicao.coluna + 1);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //sul
            Posicao.definirValores(Posicao.linha + 1, Posicao.coluna);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //sudoeste
            Posicao.definirValores(Posicao.linha + 1, Posicao.coluna -1);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //oeste
            Posicao.definirValores(Posicao.linha, Posicao.coluna - 1);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //noroeste
            Posicao.definirValores(Posicao.linha - 1, Posicao.coluna - 1);
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
            return "R";
        }
    }
}
