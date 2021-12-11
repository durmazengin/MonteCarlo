using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stowaway
{
    public enum EnvironmentResponse
    {
        NOT_AVAILABLE,
        AVAILABLE,
        GOAL
    }
    public class Environment
    {
        private const int MARGIN = 5;

        Panel pnlBackground = null;
        int gridsHorizontal = 0;
        int gridsVertical = 0;
        int unitWidth = 0;
        int unitHeight =0;
        Color backgroundColor = Color.White;

        Point agentPosition = new Point(1, 1);
        Point goalPosition = new Point(4, 4);

        Color gridLineColor = Color.Black;
        bool animated = true;

        public Environment(Panel background)
        {
            pnlBackground = background;
            System.Threading.Thread threadAnimate = new System.Threading.Thread(new System.Threading.ThreadStart(CheckAnimate));
            threadAnimate.Start();
        }
        void CheckAnimate()
        {
            while(true)
            {
                animated = System.IO.File.Exists("animate");
                System.Threading.Thread.Sleep(1000);
            }
        }
        public void DrawGrids(int columnCount, int rowCount, Color lineColor, Color backColor)
        {
            gridsHorizontal = rowCount;
            gridsVertical = columnCount;
            backgroundColor = backColor;
            gridLineColor = lineColor;
            
            unitWidth = (pnlBackground.Width - MARGIN) / gridsHorizontal;
            unitHeight = (pnlBackground.Height - MARGIN) / gridsVertical;

            agentPosition = new Point(1, 1);
            goalPosition = new Point(goalPosition.X, goalPosition.Y);

            PaintAll();
        }

        internal EnvironmentResponse TryAction(int xPosition, int yPosition)
        {
            if(xPosition < 1 || yPosition< 1 || xPosition>gridsVertical || yPosition>gridsHorizontal)
            {
                return EnvironmentResponse.NOT_AVAILABLE;
            }
            Point oldPosition = agentPosition;
            agentPosition = new Point(xPosition, yPosition);

            MoveAgent(oldPosition, agentPosition);

            if((agentPosition.X == goalPosition.X) && (agentPosition.Y == goalPosition.Y))
            {
                if (animated)
                {
                    System.Threading.Thread.Sleep(500);
                }
                return EnvironmentResponse.GOAL;
            }
            return EnvironmentResponse.AVAILABLE;
        }
        
        private void MoveAgent(Point oldPosition, Point agentPosition)
        {
            if (animated)
            {
                Graphics gridDrawer = pnlBackground.CreateGraphics();
                Brush brushBackcolor = new SolidBrush(backgroundColor);

                // clear old position
                gridDrawer.FillRectangle(brushBackcolor, new Rectangle((oldPosition.X - 1) * unitWidth,
                    (oldPosition.Y - 1) * unitHeight, unitWidth, unitHeight));


                Brush brushAgentcolor = new SolidBrush(gridLineColor);
                // set new position for agent
                gridDrawer.FillEllipse(brushAgentcolor, new Rectangle((agentPosition.X - 1) * unitWidth,
                    (agentPosition.Y - 1) * unitHeight, unitWidth, unitHeight));

                System.Threading.Thread.Sleep(2);
            }
        }

        internal void SetGoalPosition(int xPosition, int yPosition)
        {
            goalPosition = new Point(xPosition, yPosition);

            PaintAll();
        }

        private void PaintAll()
        {
            Graphics gridDrawer = pnlBackground.CreateGraphics();
            // firstly clear all field
            Brush brushClean = new SolidBrush(Color.White);
            gridDrawer.FillRectangle(brushClean, new Rectangle(0, 0, pnlBackground.Width, pnlBackground.Height));


            /*
               all width to be painted is not equal to panel width 
               all height to be painted is not equal to panel height
               since points are integer and "allWidth / row count" can be decimal
               then they are rounded to integer. then width decreased
               for example allWidth = 600, row count 11, 
                         then cell width 50
                         colored all width 50 * 11 = 550

               and scenario for height (allHeight / column count)
               so recalculate 
               */
            int allWidth = unitWidth * gridsHorizontal;
            int allHeight = unitHeight * gridsVertical;

            // Fill background with selected color
            Brush brushBackcolor = new SolidBrush(backgroundColor);
            gridDrawer.FillRectangle(brushBackcolor, new Rectangle(0, 0, allWidth, allHeight));

            Pen pen = new Pen(gridLineColor);

            // draw vertical lines
            for (int i = 0; i <= gridsHorizontal; i++)
            {
                gridDrawer.DrawLine(pen, new Point(i * unitWidth, 0), new Point(i * unitWidth, allHeight));
            }
            // draw horizontal lines
            for (int j = 0; j <= gridsVertical; j++)
            {
                gridDrawer.DrawLine(pen, new Point(0, j * unitHeight), new Point(allWidth, j * unitHeight));
            }
            
            Brush brushAgentcolor = new SolidBrush(gridLineColor);
            // set new position for agent
            gridDrawer.FillEllipse(brushAgentcolor, new Rectangle((agentPosition.X - 1) * unitWidth,
                (agentPosition.Y - 1) * unitHeight, unitWidth, unitHeight));

            Brush brushGoalcolor = new SolidBrush(Color.Green);
            // set new position for agent
            gridDrawer.FillEllipse(brushGoalcolor, new Rectangle((goalPosition.X - 1) * unitWidth,
                (goalPosition.Y - 1) * unitHeight, unitWidth, unitHeight));
        }
        
        internal bool getIsAnimate()
        {
            return animated;
        }
    }
}
