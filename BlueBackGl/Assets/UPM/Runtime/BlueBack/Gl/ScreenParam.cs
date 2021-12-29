

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
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
		/** 仮想画面サイズ。

			virtual_w_pix_inv : 1.0f / VIRTUAL_W
			virtual_h_pix_inv : 1.0f / VIRTUAL_H

		*/
		public float virtual_w_pix_inv;
		public float virtual_h_pix_inv;

		/** スクリーンオフセット。

			単位：レンダーテクスチャーの幅/高を1.0f

		*/
		public float offset_x;
		public float offset_y;

		/** スクリーンスケール。

			単位：レンダーテクスチャーの幅/高を1.0f

		*/
		public float scale_w;
		public float scale_h;
    }
}

