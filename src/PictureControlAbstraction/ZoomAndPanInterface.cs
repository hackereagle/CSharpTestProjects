using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCSEM.ImgProcToolsGui.BusinessLogic.Interface
{
    
    public interface IZoomAndPan<ImageType, PointType, SizeType>
    {
        bool Disp(ImageType DisplayImg);
        void MovePicture(ImageType DisplayImg, PointType CurrentMousePos, PointType LastMousePos);

        void ZoomPicture(ImageType DisplayImg, double WheelDelta, PointType mousePos);

        void CoordinateAfterZoom(ref PointType RealPoint, PointType MousePos);

        double ZoomRatio
        {
            get;
        }

        PointType get_LeftTopPoint
        {
            get;
        }
    }
}
