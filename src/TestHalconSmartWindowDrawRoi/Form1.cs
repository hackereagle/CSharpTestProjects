using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

        private const string RCP_FILE_NAME = "testRcp";
        private void btnTestSaveRegion_Click(object sender, EventArgs e)
        {
            List<MyRegion> myRegions = mController.GetRegions();
            System.IO.FileStream fileStream = new System.IO.FileStream(RCP_FILE_NAME, System.IO.FileMode.OpenOrCreate);
            // Halcon.Region can not be serialized to xml, because HRegion is without public field.
            //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyRegion));

            //System.Xml.XmlWriter writer = new System.Xml.XmlTextWriter(fileStream, Encoding.Unicode);
            //serializer.Serialize(writer, myRegions);
            //writer.Close();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, myRegions);
            fileStream.Close();
        }

        private void btnTestReadRegion_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(RCP_FILE_NAME))
            {
                List<MyRegion> obj;
                System.IO.FileStream stream = new System.IO.FileStream(RCP_FILE_NAME, System.IO.FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                obj = (List<MyRegion>)binaryFormatter.Deserialize(stream);

                stream.Close();

                mController.DispAllRoi(obj);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            HalconDotNet.HImage img = new HalconDotNet.HImage();
            img.ReadImage("D:/Rorze_Data/Projects/lena.bmp");
            hswDisplay.HalconWindow.DispObj(img);
        }
    }
}
