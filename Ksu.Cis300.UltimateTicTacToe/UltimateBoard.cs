﻿/* UltimateBoard.cs
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
    public class UltimateBoard
    {
        /// <summary>
        /// Contains the smaller boards
        /// </summary>
        private TicTacToeBoard[,] _boards = new TicTacToeBoard[3, 3];
        /// <summary>
        /// Represents the larger board
        /// </summary>
        private TicTacToeBoard _summaryBoard = new TicTacToeBoard();
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
                return _summaryBoard.IsWon;
            }
        }
        /// <summary>
        /// Tells whether the game is over based on the large board
        /// </summary>
        public bool IsOver
        {
            get
            {
                return _summaryBoard.IsOver;
            }
        }
        /// <summary>
        /// Constructs a board for a new game
        /// </summary>
        public UltimateBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    _boards[i, j] = new TicTacToeBoard();
                }
            }
        }
        /// <summary>
        /// Constructs a copy of the board
        /// </summary>
        /// <param name="b">The board being copied</param>
        public UltimateBoard(UltimateBoard b)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _boards[i, j] = new TicTacToeBoard(b._boards[i, j]);
                }
            }
            _summaryBoard = new TicTacToeBoard(b._summaryBoard);
            _lastPlay = b._lastPlay;
            _turn = b._turn;
            _isNewGame = b._isNewGame;
        }
        /// <summary>
        /// Gets the available plays based on either the large board, or the smaller board and adds to a list
        /// </summary>
        /// <returns>The list of available plays</returns>
        public List<(int, int, int, int)> GetAvailablePlays()
        {
            if(_isNewGame || _boards[_lastPlay.Item3, _lastPlay.Item4].IsOver)
            {
                List<(int, int, int, int)> x = new List<(int, int, int, int)>();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!_boards[i, j].IsOver)
                        {
                            _boards[i, j].GetAvailablePlays(x, i, j);
                        }
                    }
                }
                return x;
            }
            else
            {
                List<(int, int, int, int)> x = new List<(int, int, int, int)>();
                _boards[_lastPlay.Item3, _lastPlay.Item4].GetAvailablePlays(x, _lastPlay.Item3, _lastPlay.Item4);
                return x;
            }
        }
        /// <summary>
        /// Makes the appropriate play for the current player to the smaller board
        /// </summary>
        /// <param name="loc">Location of the play to be made</param>
        public void Play((int, int, int, int) loc)
        {
            TicTacToeBoard temp = _boards[loc.Item1, loc.Item2];
            temp.Play(_turn, loc.Item3, loc.Item4);
            if (temp.IsOver)
            {
                if (temp.IsWon)
                {
                    _summaryBoard.Play(_turn, loc.Item1, loc.Item2);
                }
                else
                {
                    _summaryBoard.Play(Player.Draw, loc.Item1, loc.Item2);
                }
            }
            _isNewGame = false;
            _lastPlay = loc;
            _turn = 1 - _turn;
        }
    }
}
