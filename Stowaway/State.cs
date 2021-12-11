using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stowaway
{
    public class State
    {
        private int xPosition = 1;
        private int yPosition = 1;

        public State(int x, int y)
        {
            xPosition = x;
            yPosition = y;
        }
        public int getXPosition()
        {
            return xPosition;
        }
        public int getYPosition()
        {
            return yPosition;
        }
        public override int GetHashCode()
        { 
            return xPosition * 10000 + yPosition;
        }
        public override bool Equals(object objToCompare)
        {
            if(objToCompare is State)
            {
                State state = (State)objToCompare;
                if(state.getXPosition() == this.getXPosition() && state.getYPosition() == this.getYPosition())
                {
                    /*bool isEqual = base.Equals(objToCompare);
                    if(!isEqual)
                    {
                        isEqual = true;
                    }*/
                    return true;
                }
            }
            return base.Equals(objToCompare);
        }
    }
}
