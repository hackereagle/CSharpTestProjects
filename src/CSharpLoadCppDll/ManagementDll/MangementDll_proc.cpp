#include <opencv2\opencv.hpp>
#include "MangementDll_proc.h"

namespace TestCSUsingCppDll {
	TestCSUsingCppDll::MangementDll_proc::MangementDll_proc()
	{
		std::cout << "hello~~~" << std::endl;
		// 相關資料: https://blog.xuite.net/tzeng015/twblog/113272128-%E6%8C%87%E6%A8%99%E8%A7%80%E5%BF%B5+%E5%86%8D%E5%8A%A0%E5%BC%B7+%284%29
		unsigned char* test;
		std::cout << "byte* size = " << sizeof(unsigned char*) << "（bytes）" << std::endl;
		std::cout << "test size = " << sizeof(test) << "（bytes）" << std::endl;
		std::cout << "int size = " << sizeof(int) << "（bytes）" << std::endl;
		std::cout << "int* size = " << sizeof(int*) << "（bytes）" << std::endl;
		std::cout << "unsigned char(byte) size = " << sizeof(unsigned char) << "（bytes）" << std::endl;
	}

	TestCSUsingCppDll::MangementDll_proc::~MangementDll_proc()
	{

	}

	TestCSUsingCppDll::ImgInfomation2 TestCSUsingCppDll::MangementDll_proc::ConvertRgb2gray(TestCSUsingCppDll::ImgInfomation2 inputImg)
	{
		TestCSUsingCppDll::ImgInfomation2 outputImg = TestCSUsingCppDll::ImgInfomation2();
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

	int TestCSUsingCppDll::MangementDll_proc::ConverBitmapFormatToOpencvFormat(int BitmapFormat)
	{
		switch (BitmapFormat)
		{
		default:
			return CV_8UC3;
			break;
		}
	}

	int TestCSUsingCppDll::MangementDll_proc::testOtherFunc()
	{
		std::cout << "test other function!" << std::endl;
		return 1;
	}

	void TestCSUsingCppDll::MangementDll_proc::TestPassByStruct(TestCSUsingCppDll::ImgInfomation2 inputImg, TestCSUsingCppDll::ImgInfomation2% outputImg)
	{
		std::cout << "congradulation!" << std::endl;
		outputImg = TestCSUsingCppDll::ImgInfomation2();
		cv::Mat srcImg = cv::Mat(cv::Size(inputImg.width, inputImg.height), CV_8UC3, inputImg.src);

		cv::Mat result;
		cvtColor(srcImg, result, cv::COLOR_RGB2GRAY);

		outputImg.width = result.cols;
		outputImg.height = result.rows;
		outputImg.channels = 1;
		outputImg.step = result.step;
		outputImg.src = new uchar[result.total()];
		memcpy((void*)outputImg.src, (void*)result.data, result.total());

	}

}