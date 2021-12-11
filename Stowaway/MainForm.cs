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
    public partial class MainForm : Form
    {
        Environment environment = null;
        const int REWARD_TO_GOAL_ACTION = 1000;
        const double LAMBDA = 0.1;

        Dictionary<State, StateDetails> globalStateValues = new Dictionary<State, StateDetails>();
        Dictionary<State, StateDetails> bestStateValues = new Dictionary<State, StateDetails>();
        int episodeNr = 0;
        
        public MainForm()
        {
            InitializeComponent();

            environment = new Environment(this.pnlGameField);

            numerHorizontalGrids.Value = 30;
            numerVerticalGrids.Value = 30;            
        }

        private void btnSelectFillColor_Click(object sender, EventArgs e)
        {
            if (clrDialogSelector.ShowDialog() == DialogResult.OK)
            {
                btnSelectFillColor.BackColor = clrDialogSelector.Color;
                btnSelectLineColor.BackColor = clrDialogSelector.Color;

                Prepare();
            }
        }

        private void btnSelectLineColor_Click(object sender, EventArgs e)
        {
            if (clrDialogSelector.ShowDialog() == DialogResult.OK)
            {
                btnSelectFillColor.ForeColor = clrDialogSelector.Color;
                btnSelectLineColor.ForeColor = clrDialogSelector.Color;

                Prepare();
            }
        }

        private void numerHorizontalGrids_ValueChanged(object sender, EventArgs e)
        {
            Prepare();
        }

        private void numerVerticalGrids_ValueChanged(object sender, EventArgs e)
        {
            Prepare();
        }

        private void numerStartPositionX_ValueChanged(object sender, EventArgs e)
        {
            environment.TryAction((int)numerStartPositionX.Value, (int)numerStartPositionY.Value);
        }

        private void numerStartPositionY_ValueChanged(object sender, EventArgs e)
        {
            environment.TryAction((int)numerStartPositionX.Value, (int)numerStartPositionY.Value);
        }

        private void numerGoalPositionX_ValueChanged(object sender, EventArgs e)
        {
            environment.SetGoalPosition((int)numerGoalPositionX.Value, (int)numerGoalPositionY.Value);
        }

        private void numerGoalPositionY_ValueChanged(object sender, EventArgs e)
        {
            environment.SetGoalPosition((int)numerGoalPositionX.Value, (int)numerGoalPositionY.Value);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Prepare();
            environment.SetGoalPosition((int)numerGoalPositionX.Value, (int)numerGoalPositionY.Value);

            environment.TryAction((int)numerStartPositionX.Value, (int)numerStartPositionY.Value);
        }

        private void Prepare()
        {
            numerStartPositionX.Maximum = numerVerticalGrids.Value;
            numerStartPositionY.Maximum = numerHorizontalGrids.Value;

            numerGoalPositionX.Maximum = numerVerticalGrids.Value;
            numerGoalPositionY.Maximum = numerHorizontalGrids.Value;

            environment.DrawGrids((int)numerHorizontalGrids.Value,
                (int)numerVerticalGrids.Value,
                btnSelectLineColor.ForeColor,
                btnSelectFillColor.BackColor);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            globalStateValues = new Dictionary<State, StateDetails>();
            bestStateValues = new Dictionary<State, StateDetails>();

            txtLogs.Clear();
            episodeNr = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numerSuccessIterations.Value; i++)
            {
                Prepare();
                environment.TryAction((int)numerStartPositionX.Value, (int)numerStartPositionY.Value);

                globalStateValues = Train(globalStateValues);

            }
        }
        
        private Dictionary<State, StateDetails> Train(Dictionary<State, StateDetails> cumulativeEpisode)
        {
            episodeNr++;
            State currentState = new State((int)numerStartPositionX.Value, (int)numerStartPositionY.Value);

            Dictionary<State, StateDetails> currentEpisode = new Dictionary<State, StateDetails>();
            currentEpisode.Add(currentState, new StateDetails());
            if(cumulativeEpisode.ContainsKey(currentState))
            {
                currentEpisode[currentState].Rewards = cumulativeEpisode[currentState].Rewards;
            }

            int iterationCount = 0;
            State tempState = currentState; // save this state, it is starting point
            while (true)
            {
                /*
                   select action randomly, care action rewards
                 */
                int[] returns = new int[StateDetails.NUM_OF_ACTIONS];
                for(int i = 0; i < StateDetails.NUM_OF_ACTIONS; i++)
                {
                    int depth = 0;
                    State stateRef = GetNextStateReference(currentState, (Action)i);
                    returns[i] = CalculateReturn(cumulativeEpisode, stateRef, out depth);
                    if (depth > 0)
                    {
                        returns[i] = returns[i] / depth;
                    }
                    // or R(t) = Sum(k->T, lamda*r(k+t+1), 0 < lamda < 1
                    returns[i] = (int)(LAMBDA * (double)returns[i]);
                }

                int selectedAction = SelectAction(currentEpisode[currentState].Rewards, returns);
                // Policy to take favorite action
                if (episodeNr > bestStateValues.Keys.Count)
                {
                    int random = GetRandomNumber(1, episodeNr);
                    
                    if (bestStateValues.ContainsKey(currentState) && (random > bestStateValues.Keys.Count))
                    {
                        selectedAction = bestStateValues[currentState].LastSelectedAction;
                    }
                }
                State nextState = GetNextStateReference(currentState, (Action)selectedAction);
                                
                iterationCount++;

                EnvironmentResponse envResponse = environment.TryAction(nextState.getXPosition(), nextState.getYPosition());

                if (envResponse == EnvironmentResponse.NOT_AVAILABLE) // action could not be available
                {
                    // do nothing
                }
                else
                {
                    currentEpisode[currentState].LastSelectedAction = selectedAction;
                    currentEpisode[currentState].NextState = nextState;

                    if (!currentEpisode.ContainsKey(nextState))
                    {
                        currentEpisode.Add(nextState, new StateDetails());
                    }
                    currentState = nextState;

                    if (cumulativeEpisode.ContainsKey(currentState))
                    {
                        currentEpisode[currentState].Rewards = cumulativeEpisode[currentState].Rewards;
                    }

                    if (envResponse == EnvironmentResponse.GOAL)
                    {
                        // update rewards
                        /*
                         * give points as GOAL REWARD / Steps count to goal state
                         */
                        currentEpisode[currentState].Rewards[0] = REWARD_TO_GOAL_ACTION;

                        // update previous state points
                        StateDetails tempStateDetails = null;
                        int visitedStatesCount = 0;
                        State visitedState = tempState;
                        for (int i = 0; i < currentEpisode.Keys.Count; i++)
                        {
                            tempStateDetails = currentEpisode[visitedState];
                            if (tempStateDetails.LastSelectedAction < 0)// end of array
                            {
                                break;
                            }
                            visitedStatesCount++;
                            visitedState = tempStateDetails.NextState;
                        }

                        tempStateDetails = null;
                        for (int i = 0; i < visitedStatesCount; i++)
                        {
                            tempStateDetails = currentEpisode[tempState];
                            if (tempStateDetails.LastSelectedAction < 0)// end of array
                            {
                                break;
                            }
                            int actionTobeRewarded = tempStateDetails.LastSelectedAction;
                            int rewardToAction = REWARD_TO_GOAL_ACTION / (visitedStatesCount - i);
                            tempStateDetails.Rewards[actionTobeRewarded] = rewardToAction;
                            
                            currentEpisode[tempState] = tempStateDetails; // update rewards
                            tempState = tempStateDetails.NextState;
                            if (tempState == null)
                            {
                                break;
                            }

                            if (i == (visitedStatesCount - 2))
                            {
                                // may be some debug
                            }
                        }
                        break;
                    }
                }
            }
            
            // update cumulative episode
            foreach(State state in currentEpisode.Keys)
            {
                if(!cumulativeEpisode.ContainsKey(state))
                {
                    cumulativeEpisode.Add(state, currentEpisode[state]);
                }
            }

            if ((bestStateValues.Keys.Count == 0) || (bestStateValues.Keys.Count >= currentEpisode.Keys.Count))
            {
                bestStateValues = currentEpisode;
            }

            String strLog = String.Format("Iteration {0:D3}: {1:D5}", episodeNr, iterationCount);
            txtLogs.AppendText(strLog + "\r\n");
            txtLogs.Refresh();
            /*
            reportForm.addEpisode(episodeValues, prevState);
            reportForm.ShowDialog();
            */
            return cumulativeEpisode;
        }
        // function to calculate rewards of a state
        private int SumRewards(Dictionary<State, StateDetails> episodeValues, State state)
        {
            int totalReward = 0;
            if (episodeValues.ContainsKey(state))
            {
                int[] rewards = episodeValues[state].Rewards;
                for (int i = 0; i< rewards.Length; i++)
                {
                    totalReward += rewards[i];
                }
            }
            return totalReward;
        }
        private int CalculateReturn(Dictionary<State, StateDetails> episodeValues, State visitedState, out int depth)
        {
            // R(t) = Sum(k->T, r(k+t+1)

            depth = 0;
            if (!episodeValues.ContainsKey(visitedState))
            {
                return 0;
            }
            StateDetails tempStateDetails = episodeValues[visitedState];
            if (tempStateDetails.LastSelectedAction < 0)// end of array
            {
                return 0;
            }
            int actionReward = tempStateDetails.Rewards[tempStateDetails.LastSelectedAction];
            
            int stateReturn = CalculateReturn(episodeValues, tempStateDetails.NextState, out depth);
            depth++;

            return actionReward + stateReturn; 
        }

        // function to calculate maximum reward of a state
        private int GetMaxReward(Dictionary<State, StateDetails> episodeValues, State state)
        {
            int maxReward = 0;
            if (episodeValues.ContainsKey(state))
            {
                int[] rewards = episodeValues[state].Rewards;
                for (int i = 0; i < rewards.Length; i++)
                {
                    if (rewards[i] > maxReward)
                    {
                        maxReward = rewards[i];
                    }
                }
            }
            return maxReward;
        }
        private State GetNextStateReference(State currentState, Action selectedAction)
        {
            State nextState = null;

            switch (selectedAction)
            {
                case Action.LEFT:
                    nextState = new State(currentState.getXPosition() - 1, currentState.getYPosition());
                    break;
                case Action.UP:
                    nextState = new State(currentState.getXPosition(), currentState.getYPosition() - 1);
                    break;
                case Action.RIGHT:
                    nextState = new State(currentState.getXPosition() + 1, currentState.getYPosition());
                    break;
                case Action.DOWN:
                    nextState = new State(currentState.getXPosition(), currentState.getYPosition() + 1);
                    break;
            }

            return nextState;
        }

        private int SelectAction(int [] stateRewards, int[] returns)
        {
            int selectedAction = -1;

            /*
             * Assume rewards like
             * Action 1 :   1
             * Action 2 :  10
             * Action 3 :  25
             * Action 4 :   0
             * 
             *   do not forget, if action reaches the goal state, do not select randomly
             */
            double [] tempRewards = new double[stateRewards.Length];
            int totalRewards = 0;
            for (int i = 0; i < tempRewards.Length; i++)
            {
                if (stateRewards[i] >= REWARD_TO_GOAL_ACTION)
                {
                    selectedAction = i;
                    break;
                }

                /*
                 * Assume action rewards as followings
                 * Action 1 :   1  
                 * Action 2 :  10
                 * Action 3 :  25
                 * Action 4 :   0
                 * 
                 * Add 1 to each to escape divide by zero
                 * Action 1 :   2  
                 * Action 2 :  11  
                 * Action 3 :  26  
                 * Action 4 :   1   
                 *
                 */

                tempRewards[i] = stateRewards[i] + (double)returns[i] + 1;//+1 to escape divide by zero exception
                totalRewards += (int)tempRewards[i];
            }
            if (selectedAction == -1)// goal state is not reached yet
            {
                 /*
                 * Then calculate rate is 100 * reward / all rewards
                 * Action 1 :   2  ->  2/40 -> 05.0  %
                 * Action 2 :  11  -> 11/40 -> 27.5  %
                 * Action 3 :  26  -> 27/40 -> 65.0  %
                 * Action 4 :   1  ->  1/40 -> 02.5  %
                 
                 * random and action decision
                 * 
                 * [ 00.0 -  05.0)  - Action 1
                 * [ 05.0 -  32.5)  - Action 2
                 * [ 32.5 -  97.5)  - Action 3
                 * [ 97.5 - 100.0)  - Action 4
                 * 
                 * random selection is 5, then action 2 should be selected
                 * 
                 */
                int random = new Random().Next(100);
                double rate = (double)((double)100 / totalRewards);
                double previousRate = 0;
                for (int i = 0; i < tempRewards.Length; i++)
                {
                    tempRewards[i] = tempRewards[i] * rate + previousRate;
                    if (random>= previousRate && random < tempRewards[i])
                    {
                        selectedAction = i;
                        break;                        
                    }
                    previousRate = tempRewards[i];
                }
                if(selectedAction==-1)
                {
                    selectedAction = 0;
                }
            }
            return selectedAction;
        }
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.showStates(globalStateValues, (int)numerHorizontalGrids.Value, (int)numerVerticalGrids.Value);
            reportForm.ShowDialog();
        }
    }
}
