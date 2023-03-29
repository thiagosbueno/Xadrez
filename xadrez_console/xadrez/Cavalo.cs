using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(Posicao.linha, Posicao.coluna);

            //acima
            Posicao.definirValores(Posicao.linha - 2, Posicao.coluna);
            Posicao posicaoAcima = new Posicao(Posicao.linha, Posicao.coluna);

            //direita
            Posicao.definirValores(Posicao.linha, Posicao.coluna + 1);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicaoAcima.linha, posicaoAcima.coluna);

            //esquerda
            Posicao.definirValores(Posicao.linha, Posicao.coluna - 1);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //abaixo
            Posicao.definirValores(Posicao.linha + 2, Posicao.coluna);
            Posicao posicaoAbaixo = new Posicao(Posicao.linha, Posicao.coluna);

            //direita
            Posicao.definirValores(Posicao.linha, Posicao.coluna + 1);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicaoAbaixo.linha, posicaoAbaixo.coluna);

            //esquerda
            Posicao.definirValores(Posicao.linha, Posicao.coluna - 1);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //direta
            Posicao.definirValores(Posicao.linha, Posicao.coluna + 2);
            Posicao posicaoDireita = new Posicao(Posicao.linha, Posicao.coluna);

            //acima
            Posicao.definirValores(Posicao.linha + 1, Posicao.coluna);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicaoDireita.linha, posicaoDireita.coluna);

            //abaixo
            Posicao.definirValores(Posicao.linha - 1, Posicao.coluna);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            //esqueda
            Posicao.definirValores(Posicao.linha, Posicao.coluna -2);
            Posicao posicaoEsquerda = new Posicao(Posicao.linha, Posicao.coluna);

            //acima
            Posicao.definirValores(Posicao.linha + 1, Posicao.coluna);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicaoEsquerda.linha, posicaoEsquerda.coluna);

            //abaixo
            Posicao.definirValores(Posicao.linha - 1, Posicao.coluna);
            if (Tabuleiro.posicaoValida(Posicao) && podeMover(Posicao))
                matriz[Posicao.linha, Posicao.coluna] = true;

            Posicao = new Posicao(posicao.linha, posicao.coluna);

            return matriz;
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
