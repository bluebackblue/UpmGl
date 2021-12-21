

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 初期化パラメータ。
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

		/** screen
		*/
		public int screen_w;
		public int screen_h;

		/** CreateDefault
		*/
		public static InitParam CreateDefault()
		{
			return new InitParam(){
				spritelist_max = 2,
				texture_max = 10,
				material_max = 10,
				sprite_max = 128,
				screen_w = 1280,
				screen_h = 720,
			};
		}
	}
}

