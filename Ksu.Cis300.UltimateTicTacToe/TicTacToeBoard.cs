/* TicTacToeBoard.cs
 * Author: Austin Hess
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.UltimateTicTacToe
{
    /// <summary>
    /// Represents smaller tictactoe boards
    /// </summary>
    public class TicTacToeBoard
    {
        /// <summary>
        /// Establishes a small 3x3 tictactoe board
        /// </summary>
        private Player[,] _board = new Player[3, 3];
        /// <summary>
        /// Keeps track of the number of plays to the board
        /// </summary>
        private int _numberOfPlays = 0;
        /// <summary>
        /// Keeps track of how many times each of the two players has played on each of the three rows
        /// </summary>
        private int[][] _numberOnRow = new int[3][];
        /// <summary>
        /// Keeps track of how many times each of the two players have played on each of the three columns
        /// </summary>
        private int[][] _numberOnColumn = new int[3][];
        /// <summary>
        /// Keeps track of how many times each of the two players has played to the major diagonal
        /// </summary>
        private int[] _numOnMajorDiagonal = new int[2];
        /// <summary>
        /// Keeps track of how many times each of the two players has played to the minor diagonal
        /// </summary>
        private int[] _numOnMinorDiagonal = new int[2];
        /// <summary>
        /// Tells whether one of the players has won
        /// </summary>
        public bool IsWon { get; private set; }
        /// <summary>
        /// Tells whether the game is over
        /// </summary>
        public bool IsOver { get; private set; }
        /// <summary>
        /// First constructor, used to construct an empty board
        /// </summary>
        public TicTacToeBoard()
        {
            for(int i = 0; i < _board.GetLength(0); i++)
            {
                for(int j = 0; j < _board.GetLength(1); j++)
                {
                    _board[i, j] = Player.None;
                    
                }
                _numberOnColumn[i] = new int[2];
                _numberOnRow[i] = new int[2];
            }
            
        }
        /// <summary>
        /// Second constructor, used to construct a copy of the board
        /// </summary>
        /// <param name="t">The board that is being copied</param>
        public TicTacToeBoard(TicTacToeBoard t)
        {
            _numberOfPlays = t._numberOfPlays;
            Array.Copy(t._board, _board, _board.Length);
            for(int i = 0; i < 3; i++)
            {
                _numberOnColumn[i] = (int[])(t._numberOnColumn[i].Clone());
                _numberOnRow[i] = (int[])(t._numberOnRow[i].Clone());
            }
            t._numOnMajorDiagonal.CopyTo(_numOnMajorDiagonal, 0);
            t._numOnMinorDiagonal.CopyTo(_numOnMinorDiagonal, 0);
            IsWon = t.IsWon;
            IsOver = t.IsOver;
        }
        /// <summary>
        /// Finds and adds empty locations on the board to a list, essentially getting available plays for the players
        /// </summary>
        /// <param name="x">Where the empty locations are being added</param>
        /// <param name="row">The row number of the empty location</param>
        /// <param name="column">The column number of the empty location</param>
        public void GetAvailablePlays(List<(int, int, int, int)> x, int row, int column)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(_board[i,j] == Player.None)
                    {
                        x.Add((row, column, i, j));
                    }
                }
            }
        }
        /// <summary>
        /// Updates the properties to indicate that the game is over and won
        /// </summary>
        /// <param name="numOfPlays">Number of plays each player has made to some path</param>
        /// <param name="p">Player who is playing to the path</param>
        private void PlayTo(int[] numOfPlays, Player p)
        {
            numOfPlays[(int)(p)]++;
            if(numOfPlays[(int)(p)] == 3)
            {
                IsOver = true;
                IsWon = true;
            }
        }
        /// <summary>
        /// Updates the 2D array by placing the player at the row and column and increments number of plays
        /// If the number of plays is 9, it should update the properties to establish that the game is finished.
        /// </summary>
        /// <param name="p">The player who is trying to play on their turn</param>
        /// <param name="row">The row the player is attempting to play on</param>
        /// <param name="column">The column the player is attempting to play on</param>
        public void Play(Player p, int row, int column)
        {
            _board[row, column] = p;
            _numberOfPlays++;
            if (_numberOfPlays == 9)
            {
                IsOver = true;
            }
            if (p < Player.Draw) {
                PlayTo(_numberOnRow[row], p);
                PlayTo(_numberOnColumn[column], p);
                if (row == column)
                {
                    PlayTo(_numOnMajorDiagonal, p);
                }
                if ((row + column) == 2)
                {
                    PlayTo(_numOnMinorDiagonal, p);
                }
            }
        }
    }
}
