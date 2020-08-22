using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatePatternForAOI
{
    public partial class Form1 : Form
    {
        // reference
        // https://me1237guy.pixnet.net/blog/post/65775877-c%23%E6%87%89%E7%94%A8%5B%E7%8B%80%E6%85%8B%E6%A8%A1%E5%BC%8F%5D%E6%96%BCaoi%E6%AA%A2%E6%B8%AC%E7%8B%80%E6%85%8B%E5%88%87%E6%8F%9B
        public Form1()
        {
            InitializeComponent();
        }
        private StatePatternForAOI.StateManager.Specific.StateManager _stateManager;

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_stateManager == null) return;
            _stateManager.NextState();
        }

        private void btnLoadState_Click(object sender, EventArgs e)
        {
            _stateManager = new StateManager.Specific.StateManager(new StatePatternForAOI.State.Specific.LoadState("進料狀態"), this.lblState);
            //_stateManager.Request(); // 這是作者在部落格寫的，雖然部落格中沒有明確宣告或定義，但我覺得這是另一個關鍵！
        }

        private void btnPickState_Click(object sender, EventArgs e)
        {
            _stateManager = new StateManager.Specific.StateManager(new StatePatternForAOI.State.Specific.PickState("吸料狀態"), this.lblState);
            //_stateManager.Request(); // 這是作者在部落格寫的，雖然部落格中沒有明確宣告或定義，但我覺得這是另一個關鍵！
        }

        private void btnMove2ScanStart_Click(object sender, EventArgs e)
        {
            _stateManager = new StateManager.Specific.StateManager(new StatePatternForAOI.State.Specific.MoveLineScanState("移動至掃描線"), this.lblState);
            //_stateManager.Request(); // 這是作者在部落格寫的，雖然部落格中沒有明確宣告或定義，但我覺得這是另一個關鍵！
        }

        private void btnPlaceLineScanState_Click(object sender, EventArgs e)
        {
            _stateManager = new StateManager.Specific.StateManager(new StatePatternForAOI.State.Specific.PlaceLineScanState("線掃描吹料"), this.lblState);
            //_stateManager.Request(); // 這是作者在部落格寫的，雖然部落格中沒有明確宣告或定義，但我覺得這是另一個關鍵！
        }

        private void btnLineScanStart_Click(object sender, EventArgs e)
        {
            _stateManager = new StateManager.Specific.StateManager(new StatePatternForAOI.State.Specific.LineScanStartState("Line Scan Start"), this.lblState);
            //_stateManager.Request(); // 這是作者在部落格寫的，雖然部落格中沒有明確宣告或定義，但我覺得這是另一個關鍵！
        }

        private void btnInspect_Click(object sender, EventArgs e)
        {
            _stateManager = new StateManager.Specific.StateManager(new StatePatternForAOI.State.Specific.InspectState("開始檢測"), this.lblState);
            //_stateManager.Request(); // 這是作者在部落格寫的，雖然部落格中沒有明確宣告或定義，但我覺得這是另一個關鍵！
        }

        private void btnReadBarCode_Click(object sender, EventArgs e)
        {
            _stateManager = new StateManager.Specific.StateManager(new StatePatternForAOI.State.Specific.BarcodeReadState("條碼讀取"), this.lblState);
            //_stateManager.Request(); // 這是作者在部落格寫的，雖然部落格中沒有明確宣告或定義，但我覺得這是另一個關鍵！
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            _stateManager = new StateManager.Specific.StateManager(new StatePatternForAOI.State.Specific.UnloadState("出料狀態"), this.lblState);
            //_stateManager.Request(); // 這是作者在部落格寫的，雖然部落格中沒有明確宣告或定義，但我覺得這是另一個關鍵！
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPreState_Click(object sender, EventArgs e)
        {
            if (_stateManager == null) return;
            _stateManager.PreState();
        }
    }
}
