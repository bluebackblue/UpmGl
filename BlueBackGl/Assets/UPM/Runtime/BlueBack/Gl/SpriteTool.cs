

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** SpriteTool
	*/
	public static class SpriteTool
	{
		/** SetXYWH
		*/
		public static void SetXYWH(ref SpriteBuffer a_spritebuffer,int a_x,int a_y,int a_w,int a_h,in ScreenParam a_screenparam)
		{
			float t_x1 = ((float)a_x * a_screenparam.scale_w) * a_screenparam.virtual_w_pix_inv;
			float t_y1 = (1.0f - ((float)a_y * a_screenparam.scale_h) * a_screenparam.virtual_h_pix_inv);
			float t_x2 = t_x1 + ((float)a_w * a_screenparam.scale_w) * a_screenparam.virtual_w_pix_inv;
			float t_y2 = (t_y1 - ((float)a_h * a_screenparam.scale_h) * a_screenparam.virtual_h_pix_inv);
			a_spritebuffer.vertex_x1 = t_x1 + a_screenparam.offset_x;
			a_spritebuffer.vertex_y1 = t_y1 - a_screenparam.offset_y;
			a_spritebuffer.vertex_x2 = t_x2 + a_screenparam.offset_x;
			a_spritebuffer.vertex_y2 = t_y1 - a_screenparam.offset_y;
			a_spritebuffer.vertex_x3 = t_x2 + a_screenparam.offset_x;
			a_spritebuffer.vertex_y3 = t_y2 - a_screenparam.offset_y;
			a_spritebuffer.vertex_x4 = t_x1 + a_screenparam.offset_x;
			a_spritebuffer.vertex_y4 = t_y2 - a_screenparam.offset_y;
		}
	}
}

