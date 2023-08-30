using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_Velha
{
    public class Tabuleiro
    {
        private char[,] board = new char[3, 3];
        private char jogadorAtual = 'X';
        public Tabuleiro()
        {
            IniciarTabuleiro();
        }
        private void IniciarTabuleiro()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }
        public bool FazerJogada(int linha, int coluna)
        {
            if (linha < 0 || linha > 2 || coluna < 0 || coluna > 2 || board[linha, coluna] != ' ')
            {
                return false;
            }
            board[linha, coluna] = jogadorAtual;
            jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
            return true;
        }
        public bool VerificarVitoria()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true; // Linha i venceu
                }
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return true; // Coluna i venceu
                }
            }
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true; // Diagonal principal venceu
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true; // Diagonal secundária venceu
            }
            return false; // Nenhum jogador venceu ainda
        }
        public bool VerificarEmpate()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false; // Ainda há espaços vazios no tabuleiro
                    }
                }
            }
            return true; // Tabuleiro está cheio, é empate
        }
        public char[,] ObterTabuleiro()
        {
            return board;
        }
        public char ObterJogadorAtual()
        {
            return jogadorAtual;
        }
    }
}
