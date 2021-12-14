

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** Gl_MonoBehaviour
	*/
	public sealed class Gl_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** spritelist
		*/
		public SpriteList spritelist;

		/** OnPostRender
		*/
		private void OnPostRender()
		{
			this.spritelist.OnUnityPostRender();
		}
	}
}

