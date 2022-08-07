

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** MaterialExecute_SImple

		マテリアルに _MainTex / SetPass(0) が必要。

	*/
	public sealed class MaterialExecute_SImple : MaterialExecute_Base
	{
		/** current_texture_index
		*/
		private int current_texture_index;

		/** material
		*/
		private UnityEngine.Material material;

		/** texturelist
		*/
		private UnityEngine.Texture[] texturelist;

		/** constructor
		*/
		public MaterialExecute_SImple(Gl a_gl,UnityEngine.Material a_material)
		{
			//current_texture_index
			this.current_texture_index = -1;

			//material
			this.material = a_material;

			//texturelist
			this.texturelist = a_gl.texturelist.list;
		}

		/** [BlueBack.Gl.MaterialExecute_Base]PreSetPass

			return == false : パスをセットしない。

		*/
		public bool PreSetPass(ref SpriteBuffer a_spritebuffer)
		{
			if(this.current_texture_index != a_spritebuffer.texture_index){
				this.current_texture_index = a_spritebuffer.texture_index;
				this.material.SetTexture("_MainTex",this.texturelist[this.current_texture_index]);
				return true;
			}

			return false;
		}

		/** [BlueBack.Gl.MaterialExecute_Base]SetPass
		*/
		public void SetPass()
		{
			this.material.SetPass(0);
		}
	}
}

