

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** SpriteBuffer
	*/
	public struct SpriteBuffer
	{
		/** texcord
		*/
		public Unity.Mathematics.float2x4 texcord;

		/** vertex
		*/
		public Unity.Mathematics.float2x4 vertex;

		/** visible
		*/
		public bool visible;

		/** material_index
		*/
		public int material_index;

		/** texture_index
		*/
		public int texture_index;

		/** userdata
		*/
		public int userdata;

		/** color
		*/
		public UnityEngine.Color color;
	}
}

