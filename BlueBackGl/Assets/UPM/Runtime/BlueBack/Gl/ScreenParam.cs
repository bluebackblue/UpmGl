

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
*/


/** define
*/
#if(ASMDEF_COM_UNITY_MATHEMATICS)
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** ScreenParam
	*/
	#if(UNITY_EDITOR)
	[System.Serializable]
	#endif
	public struct ScreenParam
	{
		/** 仮想サイズ。
		*/
		public float virtual_w;
		public float virtual_h;

		/** レンダーテクスチャーサイズ。
		*/
		public float rendertexture_w;
		public float rendertexture_h;

		/** 計算用。
		*/
		#if(ASMDEF_TRUE)
		public Unity.Mathematics.float2 calc_wh;
		public Unity.Mathematics.float2 calc_xy;
		#endif
	}
}

