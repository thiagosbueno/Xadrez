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

            if(Cor == Cor.Branca)
            {
                Posicao.definirValores(Posicao.linha - 1, Posicao.coluna);
                if(Tabuleiro.posicaoValida(Posicao) && livre(Posicao))
                    matriz[Posicao.linha, Posicao.coluna] = true;

                Posicao = new Posicao(posicao.linha, posicao.coluna);

                Posicao.definirValores(Posicao.linha - 2, Posicao.coluna);
                if (Tabuleiro.posicaoValida(Posicao) && livre(Posicao) && QteMovimentos == 0)
                    matriz[Posicao.linha, Posicao.coluna] = true;

                Posicao = new Posicao(posicao.linha, posicao.coluna);

                Posicao.definirValores(Posicao.linha - 1, Posicao.coluna - 1);
                if (Tabuleiro.posicaoValida(Posicao) && existeInimigo(Posicao))
                    matriz[Posicao.linha, Posicao.coluna] = true;

                Posicao = new Posicao(posicao.linha, posicao.coluna);

                Posicao.definirValores(Posicao.linha - 1, Posicao.coluna + 1);
                if (Tabuleiro.posicaoValida(Posicao) && existeInimigo(Posicao))
                    matriz[Posicao.linha, Posicao.coluna] = true;                        
            }
            else
            {
                Posicao.definirValores(Posicao.linha + 1, Posicao.coluna);
                if (Tabuleiro.posicaoValida(Posicao) && livre(Posicao))
                    matriz[Posicao.linha, Posicao.coluna] = true;

                Posicao = new Posicao(posicao.linha, posicao.coluna);

                Posicao.definirValores(Posicao.linha + 2, Posicao.coluna);
                if (Tabuleiro.posicaoValida(Posicao) && livre(Posicao) && QteMovimentos == 0)
                    matriz[Posicao.linha, Posicao.coluna] = true;

                Posicao = new Posicao(posicao.linha, posicao.coluna);

                Posicao.definirValores(Posicao.linha + 1, Posicao.coluna - 1);
                if (Tabuleiro.posicaoValida(Posicao) && existeInimigo(Posicao))
                    matriz[Posicao.linha, Posicao.coluna] = true;

                Posicao = new Posicao(posicao.linha, posicao.coluna);

                Posicao.definirValores(Posicao.linha + 1, Posicao.coluna + 1);
                if (Tabuleiro.posicaoValida(Posicao) && existeInimigo(Posicao))
                    matriz[Posicao.linha, Posicao.coluna] = true;
            }

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            return matriz;
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        private bool existeInimigo(Posicao posicao)
        {
            Peca peca = Tabuleiro.peca(Posicao);
            return peca != null && peca.Cor != Cor;
        }

        public bool livre(Posicao posicao)
        {
            return Tabuleiro.peca(posicao) == null;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}