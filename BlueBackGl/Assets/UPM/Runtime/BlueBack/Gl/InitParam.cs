

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
		/** texture_max
		*/
		public int texture_max;

		/** material_max
		*/
		public int material_max;

		/** sprite_max
		*/
		public int sprite_max;

		/** width
		*/
		public int width;

		/** height
		*/
		public int height;

		/** CreateDefault
		*/
		public static InitParam CreateDefault()
		{
			return new InitParam(){
				texture_max = 10,
				material_max = 10,
				sprite_max = 128,
				width = 1280,
				height = 720,
			};
		}
	}
}

