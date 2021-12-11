using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stowaway
{
    public partial class ReportForm : Form
    {
        private const int MARGIN = 5;
        public ReportForm()
        {
            InitializeComponent();
        }

        public void showStates(Dictionary<State, StateDetails> episodeValues, int gridsHorizontal, int gridsVertical)
        {
            Graphics gridDrawer = pnlRewards.CreateGraphics();
            int unitWidth = (pnlRewards.Width - MARGIN) / gridsHorizontal;
            int unitHeight = (pnlRewards.Height - MARGIN) / gridsVertical;

            Brush brushClean = new SolidBrush(Color.White);
            gridDrawer.FillRectangle(brushClean, new Rectangle(0, 0, pnlRewards.Width, pnlRewards.Height));


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

            Pen pen = new Pen(Color.Black);

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
        }
        public void clear()
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
