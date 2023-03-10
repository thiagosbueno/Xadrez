﻿namespace xadrez_console.tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas { get; set; }

        public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao posicao)
        {
            return pecas[posicao.linha, posicao.coluna];
        }

        public bool existePeca(Posicao posicao)
        {
            validarPosicao(posicao);
            return peca(posicao) != null;
        }

        public void colocarPeca(Peca peca, Posicao posicao)
        {
            if(existePeca(posicao))
                throw new TabuleiroException("Já existe uma peça nessa posição!");

            pecas[posicao.linha, posicao.coluna] = peca;
            peca.Posicao = posicao;
        }

        public Peca retirarPeca(Posicao posicao)
        {
            if (peca(posicao) == null)
                return null;
            else
            {
                Peca aux = peca(posicao);
                aux.Posicao = null;
                pecas[posicao.linha, posicao.coluna] = null;
                return aux;
            }
        }

        public bool posicaoValida(Posicao posicao)
        {
            if(posicao.linha < 0 || posicao.linha >= Linhas || posicao.coluna < 0 || posicao.coluna >= Colunas)
                return false;

            return true;
        }

        public void validarPosicao(Posicao posicao)
        {
            if (!posicaoValida(posicao))
                throw new TabuleiroException("Posição inválida!");
        }
    }
}