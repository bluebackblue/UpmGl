

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** SpriteBuffer
	*/
	public struct SpriteBuffer
	{
		/** visible
		*/
		public bool visible;

		/** material_index
		*/
		public int material_index;

		/** texture_index
		*/
		public int texture_index;

		/** color
		*/
		public UnityEngine.Color color;

		/** texcord
		*/
		public float texcord_1_x1;
		public float texcord_1_y1;
		public float texcord_2_x2;
		public float texcord_2_y1;
		public float texcord_3_x2;
		public float texcord_3_y2;
		public float texcord_4_x1;
		public float texcord_4_y2;

		/** vertex
		*/
		public float vertex_x1;
		public float vertex_y1;
		public float vertex_x2;
		public float vertex_y2;
		public float vertex_x3;
		public float vertex_y3;
		public float vertex_x4;
		public float vertex_y4;
	}
}

