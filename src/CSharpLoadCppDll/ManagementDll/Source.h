#pragma once
#include <opencv2\opencv.hpp>

#ifndef MANAGEMENT_DLL_H_
#define MANAGEMENT_DLL_H_

#ifdef MANAGEMENTDLL_EXPORTS // 20181021 sc.lin: must add define in project property
#define DLLEXPORT_API extern "C" __declspec(dllexport) 
#else
#define DLLEXPORT_API extern "C" __declspec(dllimport) 
#endif
	public struct ImgInfomation
	{
	
		int width;
		int height;
		int channels;
		int step;
		unsigned char* src;
	};

	// **method1: call manage dll function
	DLLEXPORT_API ImgInfomation Convert2Gray(ImgInfomation inputImg);




#endif // !MANAGEMENT_DLL_H_




