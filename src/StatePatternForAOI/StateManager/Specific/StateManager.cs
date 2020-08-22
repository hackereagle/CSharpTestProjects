using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePatternForAOI.StateManager.Specific
{
    class StateManager : StatePatternForAOI.StateManager.Base.IDisp
    {
        public delegate void dShowInfo(String mystring);

        #region Privates Field
        private StatePatternForAOI.State.Base.IState _state;
        private System.Windows.Forms.Label _label;
        private dShowInfo showInfo;
        #endregion Privates Field

        public StateManager(StatePatternForAOI.State.Base.IState state, System.Windows.Forms.Label label)
        {
            this._state = state;
            this._label = label;
            ShowInfo(string.Format("事件名稱: {0}, 訊息: {1}", this.GetType().Name, _state.Info));
        }

        #region Public Properties Field
        public StatePatternForAOI.State.Base.IState State
        {
            get { return _state; }
            set
            {
                _state = value;
                ShowInfo(string.Format("事件名稱: {0}, 訊息: {1}", this.GetType().Name, _state.Info));
            }
        }
        #endregion Public Properties Field

        #region Interface method
        public void ShowInfo(string Info)
        {
            if (_label.InvokeRequired)
            {
                showInfo = new dShowInfo(ShowInfo);
                _label.Invoke(showInfo, new object[] { Info });
            }
            else
            {
                _label.Text = Info;
            }
        }
        #endregion Interface method

        public void NextState()
        {
            _state.NexStage(this);
        }

        public void PreState()
        {
            _state.PreState(this);
        }
    }
}
