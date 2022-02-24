

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 初期化パラメータ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** InitParam
	*/
	public struct InitParam
	{
		/** spritelist_max
		*/
		public int spritelist_max;

		/** texture_max
		*/
		public int texture_max;

		/** material_max
		*/
		public int material_max;

		/** sprite_max
		*/
		public int sprite_max;

		/** camera_depth
		*/
		public float camera_depth;

		/** camera_cullingmask
		*/
		public int camera_cullingmask;

		/** camera_clearflag
		*/
		public UnityEngine.CameraClearFlags camera_clearflag;

		/** camera_bgcolor
		*/
		public UnityEngine.Color camera_bgcolor;

		/** camera_orthographic_size
		*/
		public float camera_orthographic_size;

		/** camera_hdr
		*/
		public bool camera_hdr;

		/** camera_msaa
		*/
		public bool camera_msaa;

		/** screenparam
		*/
		public ScreenParam screenparam;

		/** CreateDefault
		*/
		public static InitParam CreateDefault()
		{
			return new InitParam(){
				spritelist_max = 2,
				texture_max = 10,
				material_max = 10,
				sprite_max = 128,
				camera_depth = 0.0f,
				camera_cullingmask = 0,
				camera_clearflag = UnityEngine.CameraClearFlags.SolidColor,
				camera_bgcolor = new UnityEngine.Color(0.0f,0.0f,0.0f,1.0f),
				camera_orthographic_size = 5.0f,
				camera_hdr = false,
				camera_msaa = false,
				screenparam = ScreenTool.CreateScreenParamWidthStretch(1280,720,UnityEngine.Screen.width,UnityEngine.Screen.height),
			};
		}
	}
}

