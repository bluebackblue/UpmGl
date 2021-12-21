

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
		public static void SetXYWH(ref SpriteBuffer a_spritebuffer,int a_x,int a_y,int a_w,int a_h,int a_screen_w,int a_screen_h)
		{
			float t_x1 = (float)a_x / a_screen_w;
			float t_y1 = 1.0f - (float)a_y / a_screen_h;
			float t_x2 = t_x1 + (float)a_w / a_screen_w;
			float t_y2 = t_y1 + (float)a_h / a_screen_h;
			a_spritebuffer.vertex_x1 = t_x1;
			a_spritebuffer.vertex_y1 = t_y1;
			a_spritebuffer.vertex_x2 = t_x2;
			a_spritebuffer.vertex_y2 = t_y1;
			a_spritebuffer.vertex_x3 = t_x2;
			a_spritebuffer.vertex_y3 = t_y2;
			a_spritebuffer.vertex_x4 = t_x1;
			a_spritebuffer.vertex_y4 = t_y2;
		}
	}
}

