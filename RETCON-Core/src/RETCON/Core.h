#pragma once

/*
* THE CORE FILE WILL INCLUDE DEFINITIONS SPECIAL TO THE CORE OF RETCON
* 
* I totally didn't steal this from TheCherno
*/

#if defined(RETCON_PLATFORM_WIN)
	#if defined(RETCON_BUILD_DLL)
		#define RETCON_API __declspec(dllexport)
	#else
		#define RETCON_API __declspec(dllimport)
	#endif
#endif

#if !defined(RETCON_PLATFORM_WIN)
	#error UNSUPPORTED PLATFORM
#endif

#define BIT(x) 1 << x