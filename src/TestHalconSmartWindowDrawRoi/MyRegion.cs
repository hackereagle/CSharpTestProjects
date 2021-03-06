using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestHalconSmartWindowDrawRoi
{
    [Serializable]
    internal class MyRegion : ISerializable
    {
        public MyRegion(RoiType type, HalconDotNet.HRegion region)
        {
            mRoiType = type;
            mRegion = region;
        }

        private MyRegion(SerializationInfo info, StreamingContext context)
        {
            SerializationInfoEnumerator enumerator = info.GetEnumerator();
            while (enumerator.MoveNext())
            {
                switch (enumerator.Current.Name)
                {
                    case "mRegion":
                        mRegion = (HalconDotNet.HRegion)info.GetValue(enumerator.Current.Name, typeof(HalconDotNet.HRegion));
                        break;
                    case "mRoiType":
                        mRoiType = (RoiType)info.GetValue(enumerator.Current.Name, typeof(RoiType));
                        break;
                }
            }
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("mRoiType", mRoiType);
            info.AddValue("mRegion", mRegion);
        }
    }
}
