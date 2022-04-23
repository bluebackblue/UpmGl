

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
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
		public SpriteList[] spritelist;

		/** OnPostRender
		*/
		private void OnPostRender()
		{
			int ii_max = this.spritelist.Length;
			for(int ii=0;ii<ii_max;ii++){
				this.spritelist[ii].UnityPostRender();
			}
		}
	}
}

