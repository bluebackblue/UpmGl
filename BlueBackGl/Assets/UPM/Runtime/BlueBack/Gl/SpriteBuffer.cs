

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
*/


/** define
*/
#if(ASMDEF_UNITY_MATHEMATICS)
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
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
		#if(ASMDEF_TRUE)
		public Unity.Mathematics.float2x4 texcord;
		#endif

		/** vertex
		*/
		#if(ASMDEF_TRUE)
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

