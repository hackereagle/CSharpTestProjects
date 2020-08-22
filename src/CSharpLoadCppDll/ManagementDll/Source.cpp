#include "Source.h"
#include "opencv2\opencv.hpp"
ImgInfomation Convert2Gray(ImgInfomation inputImg)
{
	try {
		ImgInfomation outputImg = ImgInfomation();
		cv::Mat srcImg = cv::Mat(cv::Size(inputImg.width, inputImg.height), CV_8UC3, inputImg.src);

		cv::Mat result;
		cvtColor(srcImg, result, cv::COLOR_RGB2GRAY);

		outputImg.width = result.cols;
		outputImg.height = result.rows;
		outputImg.channels = 1;
		outputImg.step = result.step;
		outputImg.src = new uchar[result.total()];
		memcpy((void*)outputImg.src, (void*)result.data, result.total());

		return outputImg;
	}
	catch (cv::Exception err) {

	}
	catch (std::exception err) {

	}
}

	