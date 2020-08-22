using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePatternForAOI.StateManager.Specific;

namespace StatePatternForAOI.State.Specific
{
    class LoadState : StatePatternForAOI.State.Base.IState
    {
        public LoadState(string info)
        {
            this.Info = info;
        }

        public override void NexStage(StateManager.Specific.StateManager stateManager)
        {
            stateManager.State = new StatePatternForAOI.State.Specific.PickState("吸料狀態");
        }

        public override void PreState(StateManager.Specific.StateManager stateManager)
        {
            stateManager.State = new StatePatternForAOI.State.Specific.UnloadState("出料狀態");
        }
    }
}
