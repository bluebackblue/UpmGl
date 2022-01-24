

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
		/** SetVisible
		*/
		public static void SetVisible(ref SpriteBuffer a_spritebuffer,bool a_flag)
		{
			a_spritebuffer.visible = a_flag;
		}

		/** SetVisible
		*/
		public static void SetVisible(SpriteIndex a_spriteindex,bool a_flag)
		{
			a_spriteindex.spritelist.buffer[a_spriteindex.index].visible = a_flag;
		}

		/** SetMaterialIndex
		*/
		public static void SetMaterialIndex(ref SpriteBuffer a_spritebuffer,int a_material_index)
		{
			a_spritebuffer.material_index = a_material_index;
		}

		/** SetMaterialIndex
		*/
		public static void SetMaterialIndex(SpriteIndex a_spriteindex,int a_material_index)
		{
			a_spriteindex.spritelist.buffer[a_spriteindex.index].material_index = a_material_index;
		}

		/** SetTextureIndex
		*/
		public static void SetTextureIndex(ref SpriteBuffer a_spritebuffer,int a_texture_index)
		{
			a_spritebuffer.texture_index = a_texture_index;
		}

		/** SetTextureIndex
		*/
		public static void SetTextureIndex(SpriteIndex a_spriteindex,int a_texture_index)
		{
			a_spriteindex.spritelist.buffer[a_spriteindex.index].texture_index = a_texture_index;
		}

		/** SetColor
		*/
		public static void SetColor(ref SpriteBuffer a_spritebuffer,in UnityEngine.Color a_color)
		{
			a_spritebuffer.color = a_color;
		}

		/** SetColor
		*/
		public static void SetColor(SpriteIndex a_spriteindex,in UnityEngine.Color a_color)
		{
			a_spriteindex.spritelist.buffer[a_spriteindex.index].color = a_color;
		}

		/** SetTexcord
		*/
		public static void SetTexcord(ref SpriteBuffer a_spritebuffer,float a_texcord_x1,float a_texcord_y1,float a_texcord_x2,float a_texcord_y2)
		{
			a_spritebuffer.texcord_x1 = a_texcord_x1;
			a_spritebuffer.texcord_y1 = a_texcord_y1;
			a_spritebuffer.texcord_x2 = a_texcord_x2;
			a_spritebuffer.texcord_y2 = a_texcord_y2;
		}

		/** SetTexcord
		*/
		public static void SetTexcord(SpriteIndex a_spriteindex,float a_texcord_x1,float a_texcord_y1,float a_texcord_x2,float a_texcord_y2)
		{
			SetTexcord(ref a_spriteindex.spritelist.buffer[a_spriteindex.index],a_texcord_x1,a_texcord_y1,a_texcord_x2,a_texcord_y2);
		}

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

		/** SetXYWH
		*/
		public static void SetXYWH(SpriteIndex a_spriteindex,int a_x,int a_y,int a_w,int a_h,in ScreenParam a_screenparam)
		{
			SetXYWH(ref a_spriteindex.spritelist.buffer[a_spriteindex.index],a_x,a_y,a_w,a_h,in a_screenparam);
		}

		/** SetXY1XY2
		*/
		public static void SetXY1XY2(ref SpriteBuffer a_spritebuffer,int a_x1,int a_y1,int a_x2,int a_y2,in ScreenParam a_screenparam)
		{
			float t_x1 = ((float)a_x1 * a_screenparam.scale_w) * a_screenparam.virtual_w_pix_inv;
			float t_y1 = (1.0f - ((float)a_y1 * a_screenparam.scale_h) * a_screenparam.virtual_h_pix_inv);
			float t_x2 = ((float)(a_x2 + 1) * a_screenparam.scale_w) * a_screenparam.virtual_w_pix_inv;
			float t_y2 = (1.0f - ((float)(a_y2 + 1) * a_screenparam.scale_h) * a_screenparam.virtual_h_pix_inv);
			a_spritebuffer.vertex_x1 = t_x1 + a_screenparam.offset_x;
			a_spritebuffer.vertex_y1 = t_y1 - a_screenparam.offset_y;
			a_spritebuffer.vertex_x2 = t_x2 + a_screenparam.offset_x;
			a_spritebuffer.vertex_y2 = t_y1 - a_screenparam.offset_y;
			a_spritebuffer.vertex_x3 = t_x2 + a_screenparam.offset_x;
			a_spritebuffer.vertex_y3 = t_y2 - a_screenparam.offset_y;
			a_spritebuffer.vertex_x4 = t_x1 + a_screenparam.offset_x;
			a_spritebuffer.vertex_y4 = t_y2 - a_screenparam.offset_y;
		}

		/** SetXY1XY2
		*/
		public static void SetXY1XY2(SpriteIndex a_spriteindex,int a_x1,int a_y1,int a_x2,int a_y2,in ScreenParam a_screenparam)
		{
			SetXY1XY2(ref a_spriteindex.spritelist.buffer[a_spriteindex.index],a_x1,a_y1,a_x2,a_y2,in a_screenparam);
		}
	}
}

