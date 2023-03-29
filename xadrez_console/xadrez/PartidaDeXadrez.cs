using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool isXeque { get; private set; }

        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            isXeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQteMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
            if(pecaCapturada != null)
                capturadas.Add(pecaCapturada);

            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = tabuleiro.retirarPeca(destino);
            peca.decrementarQteMovimentos();

            if (pecaCapturada != null)
            {
                tabuleiro.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }

            tabuleiro.colocarPeca(peca, origem);
                
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if(Xeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em Xeque!");
            }

            if (Xeque(Adversario(jogadorAtual)))
                isXeque = true;
            else
                isXeque = false;

            if (XequeMate(Adversario(jogadorAtual)))
                terminada = true;
            else
            {
                turno++;
                mudaJogador();
            }           
        }

        public void validarPosicaoDeOrigem(Posicao posicao)
        {
            if (tabuleiro.peca(posicao) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");

            if(jogadorAtual != tabuleiro.peca(posicao).Cor)
                throw new TabuleiroException("A peça de oriegem escolhida não é sua!");

            if(!tabuleiro.peca(posicao).existeMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if(!tabuleiro.peca(origem).podeMoverPara(destino))
                throw new TabuleiroException("Posição de destino inválida!");
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
                jogadorAtual = Cor.Preta;
            else
                jogadorAtual = Cor.Branca;
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca peca in capturadas)
                if(peca.Cor == cor)
                    aux.Add(peca);

            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in pecas)
                if (peca.Cor == cor)
                    aux.Add(peca);

            aux.ExceptWith(pecasCapturadas(cor));

            return aux;
        }

        private Cor Adversario(Cor cor)
        {
            if (cor == Cor.Branca)
                return Cor.Preta;
            else
                return Cor.Branca;
        }

        private Peca Rei(Cor cor)
        {
            foreach(Peca peca in pecasEmJogo(cor))
                if(peca is Rei)
                    return peca;

            return null;
        }

        public bool Xeque(Cor cor)
        {
            Peca rei = Rei(cor);
            if (rei == null)
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");

            foreach(Peca peca in pecasEmJogo(Adversario(cor)))
            {
                bool[,] mat = peca.movimentosPossiveis();
                if (mat[rei.Posicao.linha, rei.Posicao.coluna])
                    return true;
            }

            return false;
        }

        public bool XequeMate(Cor cor)
        {
            if (!Xeque(cor))
                return false;

            foreach(Peca peca in pecasEmJogo(cor))
            {
                bool[,] mat = peca.movimentosPossiveis();
                for(int i = 0; i < tabuleiro.Linhas; i++)
                {
                    for(int j = 0; j < tabuleiro.Colunas; j++)
                    {
                        if (mat[i,j])
                        {
                            Posicao origem = new Posicao(peca.Posicao.linha, peca.Posicao.coluna);
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = Xeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                                return false;
                        }
                    }
                }
            }

            return true;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas()
        {
            #region Adicionar Peças Pretas
            colocarNovaPeca('a', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 8, new Dama(tabuleiro, Cor.Preta));
            colocarNovaPeca('f', 8, new Bispo(tabuleiro, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tabuleiro, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('a', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('f', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('g', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('h', 7, new Peao(tabuleiro, Cor.Preta));
            #endregion

            #region Adicionar Peças Brancas
            colocarNovaPeca('a', 1, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 1, new Dama(tabuleiro, Cor.Branca));
            colocarNovaPeca('f', 1, new Bispo(tabuleiro, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('a', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('b', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('f', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('g', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 2, new Peao(tabuleiro, Cor.Branca));
            #endregion
        }
    }
}