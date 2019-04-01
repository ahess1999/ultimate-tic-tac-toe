/* UltimateBoard.cs
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
    /// Represents an ultimate tictactoeboard, or a 9x9 board
    /// </summary>
    class UltimateBoard
    {
        /// <summary>
        /// Contains the smaller boards
        /// </summary>
        private TicTacToeBoard[,] _smallBoard = new TicTacToeBoard[3, 3];
        /// <summary>
        /// Represents the larger board
        /// </summary>
        private TicTacToeBoard _largeBoard = new TicTacToeBoard();
        /// <summary>
        /// Indicates whether the board represents a new game
        /// </summary>
        private bool _isNewGame = true;
        /// <summary>
        /// Gives the last play made
        /// </summary>
        private (int, int, int, int) _lastPlay;
        /// <summary>
        /// The player whose turn it is to play
        /// </summary>
        private Player _turn = Player.First;
        /// <summary>
        /// Tells whether a player has won the game based on the large board
        /// </summary>
        public bool IsWon
        {
            get
            {
                return _largeBoard.IsWon;
            }
        }
        /// <summary>
        /// Tells whether the game is over based on the large board
        /// </summary>
        public bool IsOver
        {
            get
            {
                return _largeBoard.IsOver;
            }
        }
        /// <summary>
        /// Constructs a board for a new game
        /// </summary>
        public UltimateBoard()
        {

        }
        /// <summary>
        /// Constructs a copy of the board
        /// </summary>
        /// <param name="b">The board being copied</param>
        public UltimateBoard(UltimateBoard b)
        {

        }
        /// <summary>
        /// Gets the available plays based on either the large board, or the smaller board and adds to a list
        /// </summary>
        /// <returns>The list of available plays</returns>
        public List<(int, int, int, int)> GetAvailablePlays()
        {
            
        }
        /// <summary>
        /// Makes the appropriate play for the current player to the smaller board
        /// </summary>
        /// <param name="loc">Location of the play to be made</param>
        public void Play((int, int, int, int) loc)
        {

        }
    }
}
