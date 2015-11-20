using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    class Game
    {
        private char[,] board;
        private char currentPlayer;
        private bool hasWinner;
        private char winner;

        public Game()
        {
            board = new char[,] {   { ' ', ' ', ' '},
                                    { ' ', ' ', ' '},
                                    { ' ', ' ', ' '} };

            currentPlayer = 'X';
            hasWinner = false;
        }

        public char markCell(int index)
        {
            int x = index % 3;
            int y = index / 3;

			//Check if cell is already marked
			if (board[x, y] != ' ')
				return ' ';

            board[x, y] = currentPlayer;

            if (currentPlayer == 'X')
                currentPlayer = 'O';
            else
                currentPlayer = 'X';

            return checkBoard();
        }

        public char getCurrentPlayer()
        {
            return currentPlayer;
        }

        public char checkBoard()
        {

            // Check if some column or line has a winner
            for (int i = 0; i < 3; i++)
            {
				//Column check
                if(board[i, 0] != ' ' 
                    && board[i, 0] == board[i,1]
                    && board[i, 0] == board[i, 2])
                {
                    return board[i, 0];
                }


				//Line check
				if (board[0, i] != ' '
					&& board[0, i] == board[1, i]
					&& board[0, i] == board[2, i])
				{
					return board[0, i];
				}
			}


            //Check diagonals
            if( board[0, 0] != ' '
                && board[0,0] == board[1,1] 
                && board[0,0] == board[2,2])
            {
                return board[0, 0];
            }

            if (board[0, 2] != ' '
                && board[0, 2] == board[1, 1]
                && board[0, 2] == board[2, 0])
            {
                return board[0, 2];
            }

            return ' ';
        }

		public void Restart()
		{
			board = new char[,] {   { ' ', ' ', ' '},
									{ ' ', ' ', ' '},
									{ ' ', ' ', ' '} };

			currentPlayer = 'X';
			hasWinner = false;
		}
    }
}
