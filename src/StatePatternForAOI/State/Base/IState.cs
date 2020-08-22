using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePatternForAOI.State.Base
{
    abstract class IState
    {
        protected string info;
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
        public abstract void NexStage(StatePatternForAOI.StateManager.Specific.StateManager stateManager);
        public abstract void PreState(StatePatternForAOI.StateManager.Specific.StateManager stateManager);
    }
}
