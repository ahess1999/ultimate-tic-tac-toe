/* GameTreeNode.cs
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
    /// Stores the play that leads to this node to simulate a game from the current board position
    /// </summary>
    class GameTreeNode
    {
        /// <summary>
        /// Used to simulate a game from the current node
        /// </summary>
        public (int, int, int, int) Play { get; }
        /// <summary>
        /// Stores the node's children
        /// </summary>
        private GameTreeNode[] _gameTree = null;
        /// <summary>
        /// Keeps track of the number of simulations that have included this node
        /// </summary>
        private int _simulations = 0;
        /// <summary>
        /// Keeps track of the number of children that have been included in at least one simulation
        /// </summary>
        private int _childrenSimulated = 0;
        /// <summary>
        /// Keeps track of the total score of all simulations that have included this node
        /// </summary>
        private float _score = 0;
        /// <summary>
        /// Used as a no-parameter constructor
        /// </summary>
        public GameTreeNode()
        {

        }
        /// <summary>
        /// Gives the play leading to the node being constructed
        /// </summary>
        /// <param name="i">The node location</param>
        public GameTreeNode((int, int, int, int) i)
        {

        }// AddChildren GetBestChild GetChild GetChildForSimulation Simulate UpdateScore
        /// <summary>
        /// Updates the score of the game
        /// </summary>
        /// <param name="f">The score that is being updated</param>
        /// <returns>The updated score</returns>
        private float UpdateScore(float f)
        {

        }
        /// <summary>
        /// Gets the specific child needed for the simulation
        /// </summary>
        /// <returns>The node that was simulated</returns>
        private GameTreeNode GetChildForSimulation()
        {

        }
        /// <summary>
        /// Adds children to a node for each available play
        /// </summary>
        /// <param name="b">Board position at this node</param>
        public void AddChildren(UltimateBoard b)
        {

        }
        /// <summary>
        /// Simulates through and updates the score of the game
        /// </summary>
        /// <param name="b">Board position at this node</param>
        /// <returns>The updated score of the game</returns>
        public float Simulate(UltimateBoard b)
        {

        }
        /// <summary>
        /// Returns the node of the best possible play
        /// </summary>
        /// <returns>The node of the best play</returns>
        public GameTreeNode GetBestChild()
        {

        }
        /// <summary>
        /// Gives the node corresponding to the play
        /// </summary>
        /// <param name="i">Describes a play</param>
        /// <returns>Returns a GameTreeNode that refers to the child corresponding to that play</returns>
        public GameTreeNode GetChild((int, int, int, int) i)
        {

        }
    }
}
