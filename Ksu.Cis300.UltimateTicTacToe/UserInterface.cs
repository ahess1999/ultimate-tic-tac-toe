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
            InitializeBoard();
        }
        /// <summary>
        /// Stores the current game position
        /// </summary>
        private UltimateBoard _board = new UltimateBoard();
        /// <summary>
        /// Stores a portion of the game tree
        /// </summary>
        private GameTreeNode _gameTree = new GameTreeNode();
        /// <summary>
        /// Stores the symbol "O" for computer use
        /// </summary>
        private string _computerPiece = "O";
        /// <summary>
        /// Stores the symbol "X" for human use
        /// </summary>
        private string _humanPiece = "X";
        /// <summary>
        /// Adds control to the FlowLayoutPanel
        /// </summary>
        /// <param name="c">The control for the panel</param>
        /// <param name="fp">The panel being modified</param>
        /// <param name="width">Width of the panel</param>
        /// <param name="height">Height of the panel</param>
        /// <param name="margin">Margin of the panel</param>
        private void AddControl(Control c, FlowLayoutPanel fp, int width, int height, int margin)
        {
            c.Size = new Size(width, height);
            c.Margin = new Padding(margin);
            fp.Controls.Add(c);
        }
        /// <summary>
        /// Initializes the board for gameplay
        /// </summary>
        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                FlowLayoutPanel f = new FlowLayoutPanel();
                f.FlowDirection = FlowDirection.TopDown;
                AddControl(f, uxBoard, uxBoard.Width, uxBoard.Height / 3, 0);
                for (int j = 0; j < 3; j++)
                {
                    FlowLayoutPanel f1 = new FlowLayoutPanel();
                    f1.FlowDirection = FlowDirection.LeftToRight;
                    AddControl(f1, f, (f.Width / 3) - 4, f.Height - 4, 2);
                    for (int z = 0; z < 3; z++)
                    {
                        FlowLayoutPanel f2 = new FlowLayoutPanel();
                        f2.FlowDirection = FlowDirection.TopDown;
                        AddControl(f2, f1, f1.Width, f1.Height / 3, 0);
                        for (int k = 0; k < 3; k++)
                        {
                            Button b = new Button();
                            b.Tag = (i, j, z, k);
                            b.Click += ButtonClick;
                            AddControl(b, f2, f2.Width / 3, f2.Height, 0);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Disables buttons based on the plays made
        /// </summary>
        private void DisableAllButton()
        {
            foreach(Control i in uxBoard.Controls)
            {
                foreach (Control j in i.Controls)
                {
                    foreach (Control z in j.Controls)
                    {
                        foreach (Control k in z.Controls)
                        {
                            k.Enabled = false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Checks whether the game is over and if someone has won, or the game was a draw
        /// </summary>
        /// <param name="s">The string containing the player that won</param>
        /// <returns></returns>
        private bool GameIsOver(string s)
        {
            if (_board.IsOver)
            {
                DisableAllButton();
                if (_board.IsWon)
                {
                    uxStatus.Text = s + " won!";
                }
                else
                {
                    uxStatus.Text = "The game is a draw.";
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Finds and makes plays for the computer
        /// </summary>
        private void ComputerPlay()
        {
            DisableAllButton();
            uxStatus.Text = "My Turn";
            Update();
            for(int i = 0; i < 25000; i++)
            {
                UltimateBoard copy = new UltimateBoard(_board);
                _gameTree.Simulate(copy);
            }
            GameTreeNode best = _gameTree.GetBestChild();
            (int, int, int, int) x = best.Play;
            _board.Play(x);
            uxBoard.Controls[x.Item1].Controls[x.Item2].Controls[x.Item3].Controls[x.Item4].Text = _computerPiece;
            if (!GameIsOver(_computerPiece))
            {
                _gameTree = best;
                List<(int, int, int, int)> t = _board.GetAvailablePlays();
                foreach((int, int, int, int)i in t)
                {
                    uxBoard.Controls[i.Item1].Controls[i.Item2].Controls[i.Item3].Controls[i.Item4].Enabled = true;
                }
                uxStatus.Text = "Your Turn";
            }
        }
        /// <summary>
        /// Loads the message box to ask the user if they would like to play first or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_Load(object sender, EventArgs e)
        {
            if(MessageBox.Show("Would you like to play first?", "First Play", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _computerPiece = "O";
                _humanPiece = "X";
                _gameTree.AddChildren(_board);
                uxStatus.Text = "Your Turn";
            }
            else
            {
                _computerPiece = "X";
                _humanPiece = "O";
                ComputerPlay();
            }
        }
        /// <summary>
        /// Event handler for all buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Text = _humanPiece;
            (int, int, int, int) loc = ((int, int, int, int))b.Tag;
            _board.Play(loc);
            if (!GameIsOver("You"))
            {
                _gameTree = _gameTree.GetChild(loc);
                ComputerPlay();
            }
        }
    }
}
