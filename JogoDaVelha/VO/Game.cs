// Jorge Luiz Andrade

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

        public Game()
        {
            board = new char[,] {   { ' ', ' ', ' '},
                                    { ' ', ' ', ' '},
                                    { ' ', ' ', ' '} };

            currentPlayer = 'X';
        }

		//Mark a cell at a given index with the current player symbol
		// Returns:
		// 0 if has no winner
		// 1 if winner is player 1 (X)
		// 2 if winner is player 2 (O)
		// 3 if draw
		public int MarkCell(int index)
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

            return CheckBoard();
        }

		public char GetCurrentPlayer()
		{
			return currentPlayer;
		}

		//Check if the board has a winner or reached a draw
		// Returns:
		// 0 if has no winner
		// 1 if winner is player 1 (X)
		// 2 if winner is player 2 (O)
		// 3 if draw
        public int CheckBoard()
        {
			char winner = ' ';

            // Check if some column or line has a winner
            for (int i = 0; i < 3; i++)
            {
				//Column check
                if(board[i, 0] != ' ' 
                    && board[i, 0] == board[i,1]
                    && board[i, 0] == board[i, 2])
                {
                    winner = board[i, 0];
					break;
                }


				//Line check
				if (board[0, i] != ' '
					&& board[0, i] == board[1, i]
					&& board[0, i] == board[2, i])
				{
					winner =  board[0, i];
					break;
				}
			}

			if (winner == 'X')
				return 1;
			else if (winner == 'O')
				return 2;

            //Check diagonals
            if( board[0, 0] != ' '
                && board[0,0] == board[1,1] 
                && board[0,0] == board[2,2])
            {
                winner = board[0, 0];
            }

            if (board[0, 2] != ' '
                && board[0, 2] == board[1, 1]
                && board[0, 2] == board[2, 0])
            {
                winner = board[0, 2];
            }

			if (winner == 'X')
				return 1;
			else if (winner == 'O')
				return 2;

			//Check draw
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (board[i, j] == ' ')
						return 0;
				}
			}

			return 3;
            
        }

		public void Restart()
		{
			board = new char[,] {   { ' ', ' ', ' '},
									{ ' ', ' ', ' '},
									{ ' ', ' ', ' '} };

			currentPlayer = 'X';
		}
    }
}
