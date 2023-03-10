﻿using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            #region Peças Pretas
            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
            tab.colocarPeca(new Cavalo(tab, Cor.Preta), new Posicao(0, 1));
            tab.colocarPeca(new Bispo(tab, Cor.Preta), new Posicao(0, 2));
            tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 3));
            tab.colocarPeca(new Dama(tab, Cor.Preta), new Posicao(0, 4));
            tab.colocarPeca(new Bispo(tab, Cor.Preta), new Posicao(0, 5));
            tab.colocarPeca(new Cavalo(tab, Cor.Preta), new Posicao(0, 6));
            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 7));
            tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, 0));
            tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, 1));
            tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, 2));
            tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, 3));
            tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, 4));
            tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, 5));
            tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, 6));
            tab.colocarPeca(new Peao(tab, Cor.Preta), new Posicao(1, 7));
            #endregion

            #region Peças Brancas
            tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(7, 0));
            tab.colocarPeca(new Cavalo(tab, Cor.Branca), new Posicao(7, 1));
            tab.colocarPeca(new Bispo(tab, Cor.Branca), new Posicao(7, 2));
            tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(7, 3));
            tab.colocarPeca(new Dama(tab, Cor.Branca), new Posicao(7, 4));
            tab.colocarPeca(new Bispo(tab, Cor.Branca), new Posicao(7, 5));
            tab.colocarPeca(new Cavalo(tab, Cor.Branca), new Posicao(7, 6));
            tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(7, 7));
            tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, 0));
            tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, 1));
            tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, 2));
            tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, 3));
            tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, 4));
            tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, 5));
            tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, 6));
            tab.colocarPeca(new Peao(tab, Cor.Branca), new Posicao(6, 7));
            #endregion

            Tela.ImprimirTabuleiro(tab);

            Console.ReadLine();
        }
    }
}