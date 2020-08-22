#pragma once
#include <opencv2\opencv.hpp>


namespace TestCSUsingCppDll {

	public value struct ImgInfomation2
	{

		int width;
		int height;
		int channels;
		int step;
		unsigned char* src;
	};

	public ref class MangementDll_proc
	{
	public:
		MangementDll_proc();
		~MangementDll_proc();
		ImgInfomation2 ConvertRgb2gray(ImgInfomation2 inputImg);
		void TestPassByStruct(TestCSUsingCppDll::ImgInfomation2 inputImg, TestCSUsingCppDll::ImgInfomation2% outputImg);
		int testOtherFunc();

	private:
		int ConverBitmapFormatToOpencvFormat(int BitmapFormat);

	};
	
}



