

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
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
		public UnityEngine.Texture[] list;

		/** constructor
		*/
		public TextureList(in InitParam a_initparam)
		{
			this.list = new UnityEngine.Texture[a_initparam.texture_max];
		}

		/** [System.IDisposable]破棄。
		*/
		public void Dispose()
		{
		}
	}
}

