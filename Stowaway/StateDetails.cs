using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stowaway
{
    public enum Action
    {
        LEFT,
        UP,
        RIGHT,
        DOWN
    }

    public class StateDetails
    {
        /*
         * 4 actions describes
         * - LEFT
         * - UP
         * - RIGHT
         * - DOWN
         */
        public const int NUM_OF_ACTIONS = 4;

        public int[] Rewards = new int[NUM_OF_ACTIONS];

        public State NextState = null;
        public int LastSelectedAction = -1;
    }
}
