﻿namespace xadrez_console.tabuleiro
{
    public abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.Posicao = null;
            this.Tabuleiro = tabuleiro;
            this.Cor = cor;
            this.QteMovimentos = 0;
        }

        public void incrementarQteMovimentos()
        {
            QteMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            QteMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i, j])
                        return true;
                }
            }

            return false;
        }

        public bool podeMoverPara(Posicao posicao)
        {
            return movimentosPossiveis()[posicao.linha, posicao.coluna];
        }

        public abstract bool[,] movimentosPossiveis();
    }
}