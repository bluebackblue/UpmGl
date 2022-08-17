

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
*/


/** define
*/
#if(ASMDEF_COM_UNITY_MATHEMATICS)
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** ScreenTool
	*/
	public static class ScreenTool
	{
		/** 横幅吸着。
		*/
		public static BlueBack.Gl.ScreenParam CreateScreenParamWidthStretch(int a_virtual_w,int a_virtual_h,int a_rendertexture_w,int a_rendertexture_h)
		#if(ASMDEF_TRUE)
		{
			float t_virtual_w_inv = 1.0f / a_virtual_w;
			float t_virtual_h_inv = 1.0f / a_virtual_h;
			float t_use_ypix = (a_rendertexture_w * a_virtual_h) * t_virtual_w_inv;
			float t_rendertexture_h_inv = 1.0f / a_rendertexture_h;

			return new ScreenParam()
			{
				virtual_w = a_virtual_w,
				virtual_h = a_virtual_h,

				rendertexture_w = a_rendertexture_w,
				rendertexture_h = a_rendertexture_h,

				calc_wh = new Unity.Mathematics.float2(
					1.0f * t_virtual_w_inv,
					- t_use_ypix * t_rendertexture_h_inv * t_virtual_h_inv
				),

				calc_xy = new Unity.Mathematics.float2(
					0.0f,
					1.0f - (a_rendertexture_h - t_use_ypix) * 0.5f * t_rendertexture_h_inv
				),

			};
		}
		#else
		{
			#warning "ASMDEF_TRUE"
			return new BlueBack.Gl.ScreenParam();
		}
		#endif
	}
}

