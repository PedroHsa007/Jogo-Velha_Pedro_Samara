using Jogo_Velha;
using System;
namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro();
            while (!tabuleiro.VerificarVitoria() && !tabuleiro.VerificarEmpate())
            {
                char jogadorAtual = tabuleiro.ObterJogadorAtual();
                char[,] board = tabuleiro.ObterTabuleiro();
                ExibirTabuleiro(board);
                Console.WriteLine($"Vez do jogador {jogadorAtual}");
                Console.Write("Digite a linha: ");
                int linha = int.Parse(Console.ReadLine());
                Console.Write("Digite a coluna: ");
                int coluna = int.Parse(Console.ReadLine());
                if (!tabuleiro.FazerJogada(linha, coluna))
                {
                    Console.WriteLine("Jogada inválida! Tente novamente.");
                }
            }
            ExibirTabuleiro(tabuleiro.ObterTabuleiro());
            if (tabuleiro.VerificarVitoria())
            {
                Console.WriteLine($"Jogador {tabuleiro.ObterJogadorAtual()} venceu!");
            }
            else
            {
                Console.WriteLine("Empate!");
            }
        }
        static void ExibirTabuleiro(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
                if (i < 2)
                {
                    Console.WriteLine("---------");
                }
            }
            Console.WriteLine();
        }
    }
}