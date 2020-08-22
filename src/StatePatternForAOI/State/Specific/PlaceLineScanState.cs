using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePatternForAOI.StateManager.Specific;

namespace StatePatternForAOI.State.Specific
{
    class PlaceLineScanState: StatePatternForAOI.State.Base.IState
    {
        public PlaceLineScanState(string info)
        {
            this.Info = info;
        }

        public override void NexStage(StateManager.Specific.StateManager stateManager)
        {
            stateManager.State = new StatePatternForAOI.State.Specific.LineScanStartState("Line Scan Start");
        }

        public override void PreState(StateManager.Specific.StateManager stateManager)
        {
            stateManager.State = new StatePatternForAOI.State.Specific.MoveLineScanState("移動至掃描線"); 
        }
    }
}
