# Xadrez
<p align="center">
  <img width="700" height="200" src="https://user-images.githubusercontent.com/66191563/88411134-ca94b100-cdad-11ea-9cd9-b6ef821dbf45.png">
</p>

# Sobre o projeto
Este foi um projeto desenvolvido durante o curso de C#. A proposta principal dele é aplicar nossos conhecimentos na linguagem C# para criar um jogo de Xadrez que rodasse via console.

# Sobre o tabuleiro
  ### Impressão do tabuleiro no console

##### Código do método imprimirTabuleiro:
```cs
public static void imprimirTabuleiro(Tabuleiro tab)
{
            for (int i = 0; i < tab.linhas; i++)
            {
                ConsoleColor aux1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux1;
                for (int j = 0; j < tab.colunas; j++)
                { 
                        imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = aux;
}
```
##### Resultado:
<p align="center">
   <img width="142" height="165" src="https://user-images.githubusercontent.com/66191563/88415065-3e39bc80-cdb4-11ea-9c31-ece24c2dda8d.PNG">
</p>
    
  ### A exceção tabuleiroException
  ##### Alguns exemplos de exceções:
  ```cs
  throw new TabuleiroException("Não existe peça na posição de origem escolhida!"); 
  ```
  ```cs
  throw new TabuleiroException("A peça na posição de origem escolhida não é sua!");          
  ```
  ```cs
  throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida!");          
  ```
  ```cs
  throw new TabuleiroException("Posição de destino invalida!");
  ```        

# Sobre as peças
 ### Peças presentes no tabuleiro:
 - Rei `(x1 Branco & x1 Preto)`, representado pela letra `R`;
 - Dama `(x1 Branco & x1 Preto)`, representado pela letra `D`;
 - Bispo `(x2 Branco & x2 Preto)`, representado pela letra `B`;
 - Cavalo `(x1 Branco & x1 Preto)`, representado pela letra `C`;
 - Torre `(x1 Branco & x1 Preto)`, representado pela letra `T`;
 - Peão `(x8 Branco & x8 Preto)`, representado pela letra `P`.
 
 ##### Imagem do tabuleiro com as peças:
 <p align="center">
   <img width="141" height="164" src="https://user-images.githubusercontent.com/66191563/88418677-53b1e500-cdba-11ea-981f-723ef7543664.PNG">
</p>
 
 ### Método para colocar as peças no tabuleiro
 ##### Código:
 ```cs
 public override string ToString()
 {
            return "R";
 }
 ```
 > *Neste caso a letra R é retornada, pois, este pedaço do código é do Rei.*
  
 ##### Método colocarNovaPeca:
 ```cs
 public void colocarNovaPeca(char coluna, int linha, Peca peca)
 {
            tab.colocarPeca(new PosicaoXadrez(coluna, linha).toPosicao(), peca);
            pecas.Add(peca);
 }
 ```
 
 > Este método recebe uma coluna em char e um número, e o método *toPosicao()* converte esses dados em uma posição valida na matriz.
 
 ##### Método colocarPecas:
 
 ```cs
 colocarNovaPeca('a', 1, new Torre(tab, Cor.Branco));
 ```

# Como foi criada a restrição de movimento para cada peça
Na classe *PartidaXadrez* foram criados dois métodos, o método *validarPosicaoDeOrigem* e o método *validarPosicaoDeDestino*.

## Validar posição de origem:
Este método recebe uma posição informada pelo usuário (a coordenada de peça que ele quer mover). Ele foi dividido em tês *if's*.

#### 1. Posição nula
   Para testar se uma posição é nula eu utilizei a posição informada pelo usuário e a testei com o seguinte código:

   ```cs
if ( tab.peca(pos) == null)
{
       throw new TabuleiroException(" Não existe peça na posição de origem escolhida!");
}
   
   ```

#### 2. Se a peça escolhida é do jogador

   ```cs
 if (jogadorAtual != tab.peca(pos).cor)
 {
        throw new TabuleiroException("Uma peça de origem escolhida não é sua!");
 }
   ```
   
#### 3. Se não existem movimentos possíveis

 ```cs
 if ( !tab.peca(pos).existeMovimentosPossiveis())
 {
          throw new TabuleiroException("Não há movimentos possíveis para uma peça de origem escolhida!");
 }
 ```

## Validando posição de destino
Este método recebe uma posição informada pelo usuário (a coordenada para onde ele quer ir). Para este método foi utilizado apenas um *if*.

```cs
if ( !tab.peca(origem).podeMoverPara(destino))
{
           throw new TabuleiroException ("Posição de destino invalida!");
}
```

# Jogadas especiais
 Neste tópico eu mencionarei as jogadas especiais implementadas no jogo.

 #### 1. Roque Pequeno
 O roque pequeno ocorre quando o rei e uma torre não se moveram, e entre eles possuem duas casas vazias.

 ```cs
 // #jogadaespecial roque pequeno
 if (p is Rei && destino.Coluna == origem.Coluna + 2)
 {
        Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
        Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
        Peca T = tab.retirarPeca(origemT);
        T.incrementarMovimentos();
        tab.colocarPeca(destinoT, T);
 }
 ```
 
 #### 2. Roque Grande
 O roque pequeno ocorre quando o rei e uma torre não se moveram, e entre eles têm que possuir quatro casas vazias.

 ```cs
// #jogadaespecial roque grande
if (p is Rei && destino.Coluna == origem.Coluna - 2)
{
        Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
        Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
        Peca T = tab.retirarPeca(origemT);
        T.incrementarMovimentos();
        tab.colocarPeca(destinoT, T);
}
