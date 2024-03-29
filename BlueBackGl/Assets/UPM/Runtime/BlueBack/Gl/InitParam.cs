

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
		/** SpriteList
		*/
		public struct SpriteList
		{
			/** sprite_max
			*/
			public int sprite_max;

			/** debugview_disable
			*/
			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			public bool debugview_disable;
			#endif
		}

		/** spritelist
		*/
		public SpriteList[] spritelist;

		/** texture_max
		*/
		public int texture_max;

		/** material_max
		*/
		public int material_max;

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

		/** gameobject_name
		*/
		public string gameobject_name;

		/** CreateDefault
		*/
		public static InitParam CreateDefault()
		{
			return new InitParam(){
				spritelist = new SpriteList[]{
					new SpriteList(){
						sprite_max = 128,
						#if(DEF_BLUEBACK_GL_DEBUGVIEW)
						debugview_disable = false,
						#endif

					},
					new SpriteList(){
						sprite_max = 128,
						#if(DEF_BLUEBACK_GL_DEBUGVIEW)
						debugview_disable = false,
						#endif
					}
				},
				texture_max = 10,
				material_max = 10,
				camera_depth = 0.0f,
				camera_cullingmask = 0,
				camera_clearflag = UnityEngine.CameraClearFlags.SolidColor,
				camera_bgcolor = new UnityEngine.Color(0.0f,0.0f,0.0f,1.0f),
				camera_orthographic_size = 5.0f,
				camera_hdr = false,
				camera_msaa = false,
				screenparam = ScreenTool.CreateScreenParamWidthStretch(1280,720,UnityEngine.Screen.width,UnityEngine.Screen.height),
				gameobject_name = "gl",
			};
		}
	}
}

