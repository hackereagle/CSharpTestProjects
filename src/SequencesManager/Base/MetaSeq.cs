using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesManager.Base
{
    public abstract class MetaSeq
    {
        #region "Parameters"
        #region "meta parameters"
        #endregion "meta parameters"
        #endregion "Parameters"

        #region "Abstract Parameters"
        public abstract string Description { get; }
        public virtual string Title { get => this.GetType().ToString(); }
        #endregion "Abstract Parameters"

        #region "Abstract Function"
        protected abstract bool mExecute();
        public abstract bool Reset();
        #endregion "Abstract Function"

        #region "Public Function"
        public async Task<bool> Execute_Async()
        {
            if (OnExecute != null)
                OnExecute.Invoke();

            return await Task.Run(() =>
            {
                bool ret = false;

                ret = this.mExecute();
                if (OnExecuted != null)
                    OnExecute.Invoke();

                return ret;
            } );
        }
        #endregion "Public Function"

        // delegate
        public delegate void MetaSeqEventHandler();
        public delegate void MetaSeqOnErrorOccurredEventHandler(string p_ErrorMsg);
        // Events
        public event MetaSeqEventHandler OnExecute;
        public event MetaSeqEventHandler OnExecuted;
        public event MetaSeqOnErrorOccurredEventHandler OnErrorOccurred;
    }
}
