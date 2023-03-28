using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();                

                while(!partida.terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tabuleiro);
                    Console.WriteLine();

                    Console.Write("Turno: " + partida.turno);
                    Console.WriteLine();
                    Console.Write("Aguardando jogada: " + partida.jogadorAtual);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.realizaJogada(origem, destino);
                }

                Tela.ImprimirTabuleiro(partida.tabuleiro);

                Console.ReadLine();
            }
            catch(TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}