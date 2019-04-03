/* RandomSimulator.cs
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
    /// Does random simulation for the game based on board position
    /// </summary>
    public static class RandomSimulator
    {
        /// <summary>
        /// Stores the random number generator
        /// </summary>
        private static Random _randomNumbers = new Random();
        /// <summary>
        /// Simulates the random numbers
        /// </summary>
        /// <param name="b">The node that is being simulated through</param>
        /// <returns></returns>
        public static float Simulate(UltimateBoard b)
        {
            if(b.IsOver == true)
            {
                if (b.IsWon == true)
                {
                    return 1;
                }
                else
                {
                    return 0.5f;
                }
            }
            else
            {
                List<(int, int, int, int)> x = b.GetAvailablePlays();
                int i = _randomNumbers.Next(x.Count);
                b.Play(x[i]);
                return 1 - Simulate(b);
            }
        }
    }
}
