

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** SpriteList
	*/
	public sealed class SpriteList : System.IDisposable
	{
		/** list
		*/
		public Sprite[] list;

		/** count
		*/
		public int count;

		/** materialexecutelist
		*/
		private MaterialExecute_Base[] materialexecutelist;

		/** width
		*/
		private int width;

		/** height
		*/
		private int height;

		/** constructor
		*/
		public SpriteList(in InitParam a_initparam,Gl a_gl)
		{
			//list
			this.list = new Sprite[a_initparam.sprite_max];

			//count
			this.count = 0;

			//materialexecutelist
			this.materialexecutelist = a_gl.materialexecutelist.list;

			//width
			this.width = a_initparam.width;

			//height
			this.height = a_initparam.height;

			for(int ii=0;ii<this.list.Length;ii++){
				Sprite t_sprite = new Sprite();
				this.list[ii] = t_sprite;
				t_sprite.debugview = new UnityEngine.GameObject("sprite");
				t_sprite.debugview.AddComponent<Sprite_DebugView_MonoBehaviour>().sprite = t_sprite;
				t_sprite.debugview.SetActive(false);
				UnityEngine.GameObject.DontDestroyOnLoad(t_sprite.debugview);
			}
		}

		/** [IDisposable]Dispose。
		*/
		public void Dispose()
		{
		}

		/** CreateSprite
		*/
		public Sprite CreateSprite(int a_material_index,int a_texture_index,in UnityEngine.Color a_color,int a_x,int a_y,int a_w,int a_h)
		{
			BlueBack.Gl.Sprite t_item = this.list[this.count];
			{
				this.count++;
				
				t_item.visible = true;
				t_item.debugview.SetActive(true);
				t_item.material_index = a_material_index;
				t_item.texture_index = a_texture_index;
				t_item.color = a_color;
				t_item.texcord[0] = 0.0f;
				t_item.texcord[1] = 0.0f;
				t_item.texcord[2] = 1.0f;
				t_item.texcord[3] = 1.0f;

				t_item.vertex[0] = (float)(a_x) / this.width;
				t_item.vertex[1] = 1.0f - (float)(a_y) / this.height;
				t_item.vertex[2] = (float)(a_x + a_w) / this.width;
				t_item.vertex[3] = 1.0f - (float)(a_y) / this.height;
				t_item.vertex[4] = (float)(a_x + a_w) / this.width;
				t_item.vertex[5] = 1.0f - (float)(a_y + a_h) / this.height;
				t_item.vertex[6] = (float)(a_x) / this.width;
				t_item.vertex[7] = 1.0f - (float)(a_y + a_h) / this.height;
			}
			return t_item;
		}

		/** OnUnityPostRender
		*/
		public void OnUnityPostRender()
		{
			int t_current_material_index = -1;
			bool t_is_begin = false;

			{
				UnityEngine.GL.PushMatrix();
				{
					UnityEngine.GL.LoadOrtho();

					for(int ii=0;ii<this.count;ii++){
						BlueBack.Gl.Sprite t_item = this.list[ii];
						if(t_item.visible == true){
							if(t_current_material_index != t_item.material_index){
								t_current_material_index = t_item.material_index;
								if(t_is_begin == true){
									t_is_begin = false;
									UnityEngine.GL.End();
								}
							}

							if(this.materialexecutelist[t_current_material_index].PreSetPass(t_item) == true){
								if(t_is_begin == true){
									t_is_begin = false;
									UnityEngine.GL.End();
								}
							}

							if(t_is_begin == false){
								this.materialexecutelist[t_current_material_index].SetPass();
								UnityEngine.GL.Begin(UnityEngine.GL.QUADS);
								t_is_begin = true;
							}

							if(t_is_begin == true){
								UnityEngine.GL.Color(t_item.color);

								UnityEngine.GL.TexCoord2(t_item.texcord[0],t_item.texcord[3]);
								UnityEngine.GL.Vertex3(t_item.vertex[0],t_item.vertex[1],0.0f);

								UnityEngine.GL.TexCoord2(t_item.texcord[2],t_item.texcord[3]);
								UnityEngine.GL.Vertex3(t_item.vertex[2],t_item.vertex[3],0.0f);

								UnityEngine.GL.TexCoord2(t_item.texcord[2],t_item.texcord[1]);
								UnityEngine.GL.Vertex3(t_item.vertex[4],t_item.vertex[5],0.0f);

								UnityEngine.GL.TexCoord2(t_item.texcord[0],t_item.texcord[1]);
								UnityEngine.GL.Vertex3(t_item.vertex[6],t_item.vertex[7],0.0f);	
							}
						}
					}

					if(t_is_begin == true){
						UnityEngine.GL.End();
					}

				}
				UnityEngine.GL.PopMatrix();
			}
		}

	}
}

