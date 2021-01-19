using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHalconSmartWindowDrawRoi
{
    internal class MyRegion
    {
        public MyRegion(RoiType type, HalconDotNet.HRegion region)
        {
            mRoiType = type;
            mRegion = region;
        }

        private RoiType mRoiType;
        private HalconDotNet.HRegion mRegion;
        public RoiType Type
        {
            get { return mRoiType; }
        }

        public HalconDotNet.HRegion Region
        {
            get { return mRegion; }
        }
    }
}
