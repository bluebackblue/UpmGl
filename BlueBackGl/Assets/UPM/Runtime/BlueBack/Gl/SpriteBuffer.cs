

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
		public float texcord_0;
		public float texcord_1;
		public float texcord_2;
		public float texcord_3;
			
		/** vertex
		*/
		public float[] vertex;
	}
}

