

/**
* Copyright (c) blueback
* Released under the MIT License
* @brief ＧＬ。
*/


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
		public static BlueBack.Gl.ScreenParam CreateScreenParamWidthStretch(int a_screen_virtual_w,int a_screen_virtual_h,int a_rendertexture_w,int a_rendertexture_h)
		{
			float t_screen_virtual_w_inv = 1.0f / a_screen_virtual_w;
			float t_screen_virtual_h_inv = 1.0f / a_screen_virtual_h;
			float t_use_ypix = (a_rendertexture_w * a_screen_virtual_h) * t_screen_virtual_w_inv;
			float t_rendertexture_h_inv = 1.0f / a_rendertexture_h;

			return new ScreenParam()
			{
				virtual_w_pix_inv = t_screen_virtual_w_inv,
				virtual_h_pix_inv = t_screen_virtual_h_inv,
				offset_x = 0.0f,
				offset_y = (a_rendertexture_h - t_use_ypix) * 0.5f * t_rendertexture_h_inv,
				scale_w = 1.0f,
				scale_h = t_use_ypix * t_rendertexture_h_inv,
			};
		}
	}
}

