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
    class TicTacToeBoard
    {
        /// <summary>
        /// Establishes a small 3x3 tictactoe board
        /// </summary>
        private Player[,] _board = new Player[3, 3];
        /// <summary>
        /// Keeps track of the number of plays to the board
        /// </summary>
        private int _numOfPlays;
        /// <summary>
        /// Keeps track of how many times each of the two players has played on each of the three rows
        /// </summary>
        private int[][] _numberOnRow = new int[3][];
        /// <summary>
        /// Keeps track of how many times each of the two players have played on each of the three columns
        /// </summary>
        private int[][] _numberOnColumn;
        /// <summary>
        /// Keeps track of how many times each of the two players has played to the major diagonal
        /// </summary>
        private int[,] _numOnMajorDiagonal;
        /// <summary>
        /// Keeps track of how many times each of the two players has played to the minor diagonal
        /// </summary>
        private int[,] _numOnMinorDiagonal;
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
            
        }
        /// <summary>
        /// Second constructor, used to construct a copy of the board
        /// </summary>
        /// <param name="t">The board that is being copied</param>
        public TicTacToeBoard(TicTacToeBoard t)
        {

        }
        /// <summary>
        /// Finds and adds empty locations on the board to a list, essentially getting available plays for the players
        /// </summary>
        /// <param name="x">Where the empty locations are being added</param>
        /// <param name="row">The row number of the empty location</param>
        /// <param name="column">The column number of the empty location</param>
        public void GetAvailablePlays(List<(int, int, int, int)> x, int row, int column)
        {

        }
        /// <summary>
        /// Updates the properties to indicate that the game is over and won
        /// </summary>
        /// <param name="numOfPlays">Number of plays each player has made to some path</param>
        private void PlayTo(int[,] numOfPlays)
        {

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

        }
    }
}
