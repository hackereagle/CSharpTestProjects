using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHalconSmartWindowDrawRoi
{
    internal enum DeleteType
    { 
        One,
        All,
    }

    internal enum RoiType
    {
        Rectangle,
        Circle,
        Polygon,
    }

    internal class HDrawingObjectController
    {
        public HDrawingObjectController(HalconDotNet.HWindow hWindow)
        {
            mHDrawRegions = new List<HalconDotNet.HDrawingObject>();
            mHWindow = hWindow;
            Callback = DrawingObjectCallbackHandler;
        }

        private HalconDotNet.HDrawingObject.HDrawingObjectCallback Callback { get; }
        private long mCurrentRoiId;
        private void DrawingObjectCallbackHandler(IntPtr drawId, IntPtr windowHandle, string eventType)
        {
            if (eventType == "on_select")
            {
                Console.WriteLine($"{drawId}");
                mCurrentRoiId = drawId.ToInt64();
            } // following code is in order to understand other events
            else if (eventType == "on_attach")
            {
                Console.WriteLine($"{drawId}: on_attach");
            }
            else if (eventType == "on_detach")
            {
                Console.WriteLine($"{drawId}: on_detach");
            }
            else if (eventType == "on_drag")
            {
                Console.WriteLine($"{drawId}: on_drag");
            }
            else if (eventType == "on_resize")
            {
                Console.WriteLine($"{drawId}: on_resize");
            }
        }

        private List<HalconDotNet.HDrawingObject> mHDrawRegions;
        private HalconDotNet.HWindow mHWindow;

        public bool AddRoi(RoiType type)
        {
            bool isSuccess = false;
            try
            {
                switch (type)
                {
                    case RoiType.Rectangle:
                        mHDrawRegions.Add(new HalconDotNet.HDrawingObject());
                        mHDrawRegions.Last().CreateDrawingObjectRectangle1(100, 100, 500, 500);
                        break;
                    case RoiType.Circle:
                        mHDrawRegions.Add(new HalconDotNet.HDrawingObject());
                        mHDrawRegions.Last().CreateDrawingObjectCircle(100, 100, 250);
                        break;
                    case RoiType.Polygon: // 先不要用，目前還不知道怎麼定形
                        mHDrawRegions.Add(new HalconDotNet.HDrawingObject());
                        mHDrawRegions.Last().CreateDrawingObjectXld(new HalconDotNet.HTuple(new int[] { 100, 150}), new HalconDotNet.HTuple(new int[] { 100, 150 }));
                        break;
                }

                HalconDotNet.HDrawingObject.HDrawingObjectCallback test = Callback;
                IntPtr callback = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(test);
                HalconDotNet.HTuple listenTo = new HalconDotNet.HTuple("on_select", "on_attach", "on_detach", "on_drag", "on_resize"); // in order to try order events
                //HalconDotNet.HTuple listenTo = new HalconDotNet.HTuple("on_select");

                if (mHWindow != null)
                    mHWindow.AttachDrawingObjectToWindow(mHDrawRegions.Last());

                mHDrawRegions.Last().SetDrawingObjectCallback(listenTo, new HalconDotNet.HTuple(callback));
                mCurrentRoiId = mHDrawRegions.Last().ID;

                isSuccess = true;
            }
            catch (HalconDotNet.HalconException ex)
            {
                Console.WriteLine($"{ex.StackTrace}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"{ex.StackTrace}");
            }

            return isSuccess;
        }


        public void DeleteRoi(DeleteType type)
        {
            if (DeleteType.One == type)
            {
                HalconDotNet.HDrawingObject removed = null;
                foreach (HalconDotNet.HDrawingObject obj in mHDrawRegions)
                {
                    if (obj.ID == mCurrentRoiId)
                    {
                        removed = obj;
                        break;
                    }
                }

                if (removed != null)
                {
                    removed.ClearDrawingObject();
                    mHDrawRegions.Remove(removed);
                }
            }
            else
            {
                int len = mHDrawRegions.Count;
                for (int i = 0; i < len; i++)
                {
                    mHDrawRegions[i].ClearDrawingObject();
                }
                mHDrawRegions.Clear();
            }
        }

        public void DispAllRoi(List<HalconDotNet.HRegion> rois)
        {
        }

        public List<HalconDotNet.HRegion> GetRegion()
        {
            List<HalconDotNet.HRegion> region = new List<HalconDotNet.HRegion>();
            foreach (HalconDotNet.HDrawingObject obj in mHDrawRegions)
            {
                region.Add((HalconDotNet.HRegion)obj.GetDrawingObjectIconic());
            }
            return region;
        }
    }
}
