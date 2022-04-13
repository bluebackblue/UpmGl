

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
*/


#if(!ASMDEF_UNITY_MATHEMATICS)
#warning "Installing Required Package : com.unity.mathematics"
#endif


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
		#if(ASMDEF_UNITY_MATHEMATICS)
		public Unity.Mathematics.float2x4 texcord;
		#endif

		/** vertex
		*/
		#if(ASMDEF_UNITY_MATHEMATICS)
		public Unity.Mathematics.float2x4 vertex;
		#endif

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

