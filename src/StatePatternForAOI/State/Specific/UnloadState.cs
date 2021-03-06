﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePatternForAOI.StateManager.Specific;

namespace StatePatternForAOI.State.Specific
{
    class UnloadState : StatePatternForAOI.State.Base.IState
    {
        public UnloadState(string info)
        {
            this.Info = info;
        }

        public override void NexStage(StateManager.Specific.StateManager stateManager)
        {
            stateManager.State = new StatePatternForAOI.State.Specific.LoadState("進料狀態");
        }

        public override void PreState(StateManager.Specific.StateManager stateManager)
        {
            stateManager.State = new StatePatternForAOI.State.Specific.BarcodeReadState("條碼讀取");
        }
    }
}
