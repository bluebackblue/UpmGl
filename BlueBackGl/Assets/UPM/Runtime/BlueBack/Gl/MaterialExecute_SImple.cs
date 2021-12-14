

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** MaterialExecute_SImple

		_MainTex

		SetPass(0)

	*/
	public class MaterialExecute_SImple : MaterialExecute_Base
	{
		/** current_texture_index
		*/
		private int current_texture_index;

		/** material
		*/
		private UnityEngine.Material material;

		/** texturelist
		*/
		private UnityEngine.Texture2D[] texturelist;

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
		public bool PreSetPass(Sprite a_item)
		{
			if(this.current_texture_index != a_item.texture_index){
				this.current_texture_index = a_item.texture_index;
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

