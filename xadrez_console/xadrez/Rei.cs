using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    public class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
        {
            this.partida = partida;
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

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            // #jogadaespecial roque
            if(QteMovimentos == 0 && !partida.isXeque)
            {
                // #jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(Posicao.linha, Posicao.coluna + 3);
                if(testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.linha, Posicao.coluna + 1);
                    Posicao p2 = new Posicao(Posicao.linha, Posicao.coluna + 2);

                    if(Tabuleiro.peca(p1) == null && Tabuleiro.peca(p2) == null)
                    {
                        matriz[Posicao.linha, Posicao.coluna + 2] = true;
                    }
                }

                // #jogadaespecial roque grande
                Posicao posT2 = new Posicao(Posicao.linha, Posicao.coluna - 4);
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.linha, Posicao.coluna - 1);
                    Posicao p2 = new Posicao(Posicao.linha, Posicao.coluna - 2);
                    Posicao p3 = new Posicao(Posicao.linha, Posicao.coluna - 3);

                    if (Tabuleiro.peca(p1) == null && Tabuleiro.peca(p2) == null && Tabuleiro.peca(p3) == null)
                    {
                        matriz[Posicao.linha, Posicao.coluna - 2] = true;
                    }
                }
            }

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            return matriz;
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        private bool testeTorreParaRoque(Posicao posicao)
        {
            Peca peca = Tabuleiro.peca(posicao);
            return peca != null && peca is Torre && peca.Cor == Cor && QteMovimentos == 0;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
