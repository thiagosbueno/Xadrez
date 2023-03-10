using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        private int turno;
        private Cor jogadorAtual { get; set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQteMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
        }

        private void colocarPecas()
        {
            #region Adicionar Peças Pretas
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('a', 8).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.Preta), new PosicaoXadrez('b', 8).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());
            tabuleiro.colocarPeca(new Dama(tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.Preta), new PosicaoXadrez('f', 8).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.Preta), new PosicaoXadrez('g', 8).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('h', 8).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('a', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('b', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('f', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('g', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('h', 7).toPosicao());
            #endregion

            #region Adicionar Peças Brancas
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('a', 1).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.Branca), new PosicaoXadrez('b', 1).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());
            tabuleiro.colocarPeca(new Dama(tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.Branca), new PosicaoXadrez('f', 1).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.Branca), new PosicaoXadrez('g', 1).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('h', 1).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('a', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('b', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('f', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('g', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('h', 2).toPosicao());
            #endregion
        }
    }
}