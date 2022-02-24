

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
*/


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
		public Unity.Mathematics.float2 calc_wh;
		public Unity.Mathematics.float2 calc_xy;
	}
}

