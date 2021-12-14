

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** TextureList
	*/
	public sealed class TextureList : System.IDisposable
	{
		/** list
		*/
		public UnityEngine.Texture2D[] list;

		/** constructor
		*/
		public TextureList(in InitParam a_initparam)
		{
			this.list = new UnityEngine.Texture2D[a_initparam.texture_max];
		}

		/** [IDisposable]Dispose。
		*/
		public void Dispose()
		{
		}
	}
}

