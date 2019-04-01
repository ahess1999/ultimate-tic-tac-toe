/* UserInterface.cs
 * Author: Austin Hess
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.UltimateTicTacToe
{
    /// <summary>
    /// The GUI that diplays the board
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructor for the board.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Stores the current game position
        /// </summary>
        private UltimateBoard uxBoard = new UltimateBoard();
        /// <summary>
        /// Stores a portion of the game tree
        /// </summary>
        private GameTreeNode uxStatus = new GameTreeNode();
        /// <summary>
        /// Stores the symbol "X" for computer use
        /// </summary>
        private string _computerPiece = "X";
        /// <summary>
        /// Stores the symbol "O" for human use
        /// </summary>
        private string _humanPiece = "O";
    }
}
