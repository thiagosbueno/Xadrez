using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    public class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(Posicao.linha, Posicao.coluna);

            //acima
            Posicao.definirValores(Posicao.linha - 1, Posicao.coluna);
            while (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
            {
                matriz[Posicao.linha, Posicao.coluna] = true;
                if (Tabuleiro.peca(Posicao) != null && Tabuleiro.peca(Posicao).Cor != Cor)
                    break;

                Posicao.linha = Posicao.linha - 1;
            }

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //abaixo
            Posicao.definirValores(Posicao.linha + 1, Posicao.coluna);
            while (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
            {
                matriz[Posicao.linha, Posicao.coluna] = true;
                if (Tabuleiro.peca(Posicao) != null && Tabuleiro.peca(Posicao).Cor != Cor)
                    break;

                Posicao.linha = Posicao.linha + 1;
            }

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //direita
            Posicao.definirValores(Posicao.linha, Posicao.coluna + 1);
            while (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
            {
                matriz[Posicao.linha, Posicao.coluna] = true;
                if (Tabuleiro.peca(Posicao) != null && Tabuleiro.peca(Posicao).Cor != Cor)
                    break;

                Posicao.coluna = Posicao.coluna + 1;
            }

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //esquerda
            Posicao.definirValores(Posicao.linha, Posicao.coluna - 1);
            while (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
            {
                matriz[Posicao.linha, Posicao.coluna] = true;
                if (Tabuleiro.peca(Posicao) != null && Tabuleiro.peca(Posicao).Cor != Cor)
                    break;

                Posicao.coluna = Posicao.coluna - 1;
            }

            return matriz;
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
