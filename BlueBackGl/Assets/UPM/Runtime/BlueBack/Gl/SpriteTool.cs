

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
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

		/** SetMaterialIndex
		*/
		public static void SetMaterialIndex(ref SpriteBuffer a_spritebuffer,int a_material_index)
		{
			a_spritebuffer.material_index = a_material_index;
		}

		/** SetTextureIndex
		*/
		public static void SetTextureIndex(ref SpriteBuffer a_spritebuffer,int a_texture_index)
		{
			a_spritebuffer.texture_index = a_texture_index;
		}

		/** SetColor
		*/
		public static void SetColor(ref SpriteBuffer a_spritebuffer,in UnityEngine.Color a_color)
		{
			a_spritebuffer.color = a_color;
		}

		/** SetTexcord
		*/
		public static void SetTexcord(ref SpriteBuffer a_spritebuffer,in Unity.Mathematics.float2x2 a_texcord)
		{
			a_spritebuffer.texcord.c0 = a_texcord.c0;
			a_spritebuffer.texcord.c1.x = a_texcord.c1.x;
			a_spritebuffer.texcord.c1.y = a_texcord.c0.y;
			a_spritebuffer.texcord.c2 = a_texcord.c1;
			a_spritebuffer.texcord.c3.x = a_texcord.c0.x;
			a_spritebuffer.texcord.c3.y = a_texcord.c1.y;
		}

		/** SetVertex。２頂点。
		*/
		public static void SetVertex(ref SpriteBuffer a_spritebuffer,in Unity.Mathematics.float2x2 a_vertex,in ScreenParam a_screenparam)
		{
			Unity.Mathematics.float2 t_c0 = a_vertex.c0 * a_screenparam.calc_wh + a_screenparam.calc_xy;
			Unity.Mathematics.float2 t_c1 = a_vertex.c1 * a_screenparam.calc_wh + a_screenparam.calc_xy;

			a_spritebuffer.vertex.c0 = t_c0;
			a_spritebuffer.vertex.c1.x = t_c1.x;
			a_spritebuffer.vertex.c1.y = t_c0.y;
			a_spritebuffer.vertex.c2 = t_c1;
			a_spritebuffer.vertex.c3.x = t_c0.x;
			a_spritebuffer.vertex.c3.y = t_c1.y;
		}

		/** SetVertex。２頂点。

			a_offset : オフセット。

		*/
		public static void SetVertex(ref SpriteBuffer a_spritebuffer,in Unity.Mathematics.float2x2 a_vertex,in Unity.Mathematics.float2 a_offset,in ScreenParam a_screenparam)
		{
			Unity.Mathematics.float2 t_c0 = (a_vertex.c0 + a_offset) * a_screenparam.calc_wh + a_screenparam.calc_xy;
			Unity.Mathematics.float2 t_c1 = (a_vertex.c1 + a_offset) * a_screenparam.calc_wh + a_screenparam.calc_xy;

			a_spritebuffer.vertex.c0 = t_c0;
			a_spritebuffer.vertex.c1.x = t_c1.x;
			a_spritebuffer.vertex.c1.y = t_c0.y;
			a_spritebuffer.vertex.c2 = t_c1;
			a_spritebuffer.vertex.c3.x = t_c0.x;
			a_spritebuffer.vertex.c3.y = t_c1.y;
		}

		/** SetVertex。２頂点。

			a_offset		: オフセット。
			a_quaternion	: 回転。

		*/
		public static void SetVertex(ref SpriteBuffer a_spritebuffer,in Unity.Mathematics.float2x2 a_vertex,in Unity.Mathematics.float2 a_offset,in Unity.Mathematics.quaternion a_quaternion,in ScreenParam a_screenparam)
		{
			Unity.Mathematics.float2 t_c0 = Unity.Mathematics.math.mul(a_quaternion,Unity.Mathematics.math.float3(a_vertex.c0,0.0f)).xy + a_offset;
			Unity.Mathematics.float2 t_c1 = Unity.Mathematics.math.mul(a_quaternion,Unity.Mathematics.math.float3(a_vertex.c1.x,a_vertex.c0.y,0.0f)).xy + a_offset;
			Unity.Mathematics.float2 t_c2 = Unity.Mathematics.math.mul(a_quaternion,Unity.Mathematics.math.float3(a_vertex.c1,0.0f)).xy + a_offset;
			Unity.Mathematics.float2 t_c3 = Unity.Mathematics.math.mul(a_quaternion,Unity.Mathematics.math.float3(a_vertex.c0.x,a_vertex.c1.y,0.0f)).xy + a_offset;

			a_spritebuffer.vertex.c0 = t_c0 * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c1 = t_c1 * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c2 = t_c2 * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c3 = t_c3 * a_screenparam.calc_wh + a_screenparam.calc_xy;
		}

		/** SetVertex。４頂点。
		*/
		public static void SetVertex(ref SpriteBuffer a_spritebuffer,in Unity.Mathematics.float2x4 a_vertex,in ScreenParam a_screenparam)
		{
			a_spritebuffer.vertex.c0 = a_vertex.c0 * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c1 = a_vertex.c1 * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c2 = a_vertex.c2 * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c3 = a_vertex.c3 * a_screenparam.calc_wh + a_screenparam.calc_xy;
		}

		/** SetVertex。４頂点。

			a_offset : オフセット。

		*/
		public static void SetVertex(ref SpriteBuffer a_spritebuffer,in Unity.Mathematics.float2x4 a_vertex,in Unity.Mathematics.float2 a_offset,in ScreenParam a_screenparam)
		{
			a_spritebuffer.vertex.c0 = (a_vertex.c0 + a_offset) * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c1 = (a_vertex.c1 + a_offset) * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c2 = (a_vertex.c2 + a_offset) * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c3 = (a_vertex.c3 + a_offset) * a_screenparam.calc_wh + a_screenparam.calc_xy;
		}

		/** SetVertex。４頂点。

			a_offset		: オフセット。
			a_quaternion	: 回転。

		*/
		public static void SetVertex(ref SpriteBuffer a_spritebuffer,in Unity.Mathematics.float2x4 a_vertex,in Unity.Mathematics.float2 a_offset,in UnityEngine.Quaternion a_quaternion,in ScreenParam a_screenparam)
		{
			Unity.Mathematics.float2 t_c0 = Unity.Mathematics.math.float3(a_quaternion * Unity.Mathematics.math.float3(a_vertex.c0,0.0f)).xy + a_offset;
			Unity.Mathematics.float2 t_c1 = Unity.Mathematics.math.float3(a_quaternion * Unity.Mathematics.math.float3(a_vertex.c1,0.0f)).xy + a_offset;
			Unity.Mathematics.float2 t_c2 = Unity.Mathematics.math.float3(a_quaternion * Unity.Mathematics.math.float3(a_vertex.c2,0.0f)).xy + a_offset;
			Unity.Mathematics.float2 t_c3 = Unity.Mathematics.math.float3(a_quaternion * Unity.Mathematics.math.float3(a_vertex.c3,0.0f)).xy + a_offset;

			a_spritebuffer.vertex.c0 = t_c0 * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c1 = t_c1 * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c2 = t_c2 * a_screenparam.calc_wh + a_screenparam.calc_xy;
			a_spritebuffer.vertex.c3 = t_c3 * a_screenparam.calc_wh + a_screenparam.calc_xy;
		}
	}
}

