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
    public class GameTreeNode
    {
        /// <summary>
        /// Used to simulate a game from the current node
        /// </summary>
        public (int, int, int, int) Play { get; }
        /// <summary>
        /// Stores the node's children
        /// </summary>
        private GameTreeNode[] _children = null;
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
            Play = i;
        }
        /// <summary>
        /// Updates the score of the game
        /// </summary>
        /// <param name="f">The score that is being updated</param>
        /// <returns>The updated score</returns>
        private float UpdateScore(float f)
        {
            _score += f;
            _simulations++;
            return f;
        }
        /// <summary>
        /// Gets the specific child needed for the simulation
        /// </summary>
        /// <returns>The node that was simulated</returns>
        private GameTreeNode GetChildForSimulation()
        {
            if (_childrenSimulated < _children.Length)
            {
                GameTreeNode temp = _children[_childrenSimulated];
                _childrenSimulated++;
                return temp;
            }
            else
            {
                double log = 2 * Math.Log(_simulations);
                float max = -1;
                GameTreeNode temp = null;
                for (int i = 0; i < _children.Length; i++)
                {
                    float score = (float)(_children[i]._score / _children[i]._simulations + Math.Sqrt(log / _children[i]._simulations));
                    if (score > max)
                    {
                        max = score;
                        temp = _children[i];
                    }
                }
                return temp;
            }    
        }
        /// <summary>
        /// Adds children to a node for each available play
        /// </summary>
        /// <param name="b">Board position at this node</param>
        public void AddChildren(UltimateBoard b)
        {
            List<(int, int, int, int)> x = b.GetAvailablePlays();
            _children = new GameTreeNode[x.Count];
            for(int i = 0; i < x.Count; i++)
            {
                _children[i] = new GameTreeNode(x[i]);
            }
        }
        /// <summary>
        /// Simulates through and updates the score of the game
        /// </summary>
        /// <param name="b">Board position at this node</param>
        /// <returns>The updated score of the game</returns>
        public float Simulate(UltimateBoard b)
        {
            if(_simulations == 0)
            {
                return UpdateScore(RandomSimulator.Simulate(b));
            }
            else if (b.IsOver)
            {
                if (b.IsWon)
                {
                    return UpdateScore(1);
                }
                else
                {
                    return UpdateScore(0.5f);
                }
            }
            else
            {
                if(_children == null)
                {
                    AddChildren(b);
                }
                GameTreeNode temp = GetChildForSimulation();
                b.Play(temp.Play);
                return UpdateScore(1 - temp.Simulate(b));
            }
        }
        /// <summary>
        /// Returns the node of the best possible play
        /// </summary>
        /// <returns>The node of the best play</returns>
        public GameTreeNode GetBestChild()
        {
            GameTreeNode temp = null;
            int max = -1;
            for(int i = 0; i < _children.Length; i++)
            {
                if(_children[i]._simulations > max)
                {
                    max = _children[i]._simulations;
                    temp = _children[i];
                }
            }
            return temp;
        }
        /// <summary>
        /// Gives the node corresponding to the play
        /// </summary>
        /// <param name="x">Describes a play</param>
        /// <returns>Returns a GameTreeNode that refers to the child corresponding to that play</returns>
        public GameTreeNode GetChild((int, int, int, int) x)
        {
            for(int i = 0; i < _children.Length; i++)
            {
                if (_children[i].Play.Equals(x))
                {
                    return _children[i];
                }
            }
            return null;
        }
    }
}
