/* Player.cs
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
    /// Establishes whos turn it is throughout the game
    /// </summary>
    public enum Player
    {
        /// <summary>
        /// First player, establishes who goes first
        /// </summary>
        First = 0,
        /// <summary>
        /// Second player, establishes who goes second
        /// </summary>
        Second = 1,
        /// <summary>
        /// Deteremines if the game is a draw after each turn
        /// </summary>
        Draw,
        /// <summary>
        /// Determines if there are any available moves after each turn
        /// </summary>
        None
    }
}
