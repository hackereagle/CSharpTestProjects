using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestHalconSmartWindowDrawRoi
{
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mController = new HDrawingObjectController(this.hswDisplay.HalconWindow);
        }

        //private HalconDotNet.HDrawingObject mDrawing = new HalconDotNet.HDrawingObject(); // version 1
        //private List<HalconDotNet.HDrawingObject> mDrawing = new List<HalconDotNet.HDrawingObject>(); // version 2
        private HDrawingObjectController mController;
        private void btnAddRect_Click(object sender, EventArgs e)
        {
            // version 1: test how to add region
            //if (mDrawing != null)
            //    mDrawing.Dispose();
            //mDrawing.CreateDrawingObjectRectangle1(100, 100, 500, 500);
            //hswDisplay.HalconWindow.AttachDrawingObjectToWindow(mDrawing);

            // version 2: put into list
            //mDrawing.Add(new HalconDotNet.HDrawingObject());
            //mDrawing.Last().CreateDrawingObjectRectangle1(100, 100, 500, 500);
            //hswDisplay.HalconWindow.AttachDrawingObjectToWindow(mDrawing.Last());

            mController.AddRoi(RoiType.Rectangle);
        }

        private void btnAddCircle_Click(object sender, EventArgs e)
        {
            mController.AddRoi(RoiType.Circle);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mController.DeleteRoi(DeleteType.One);
        }

        private void btnDrawPolygon_Click(object sender, EventArgs e)
        {
            mController.AddRoi(RoiType.Polygon);
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            mController.DeleteRoi(DeleteType.All);
        }
    }
}
