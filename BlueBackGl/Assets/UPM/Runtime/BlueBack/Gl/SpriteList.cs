

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
		/** buffer
		*/
		public SpriteBuffer[] buffer;

		/** list
		*/
		public BlueBack.PoolList.BufferList<SpriteIndex,SpriteBuffer> list;

		/** materialexecutelist
		*/
		public MaterialExecute_Base[] materialexecutelist;

		/** width
		*/
		public int width;

		/** height
		*/
		public int height;

		/** constructor
		*/
		public SpriteList(in InitParam a_initparam,Gl a_gl)
		{
			//buffer
			this.buffer = new SpriteBuffer[a_initparam.sprite_max];

			//list
			this.list = new PoolList.BufferList<SpriteIndex,SpriteBuffer>(this.buffer,()=>{return new SpriteIndex(this);});

			//materialexecutelist
			this.materialexecutelist = a_gl.materialexecutelist.list;

			//width
			this.width = a_initparam.width;

			//height
			this.height = a_initparam.height;
		}

		/** [IDisposable]Dispose。
		*/
		public void Dispose()
		{
			foreach(SpriteIndex t_spriteindex in this.list.list_free){
				t_spriteindex.Dispose();
			}
			foreach(SpriteIndex t_spriteindex in this.list.list_use){
				t_spriteindex.Dispose();
			}
		}

		/** CreateSprite
		*/
		public SpriteIndex CreateSprite(int a_material_index,int a_texture_index,in UnityEngine.Color a_color,int a_x,int a_y,int a_w,int a_h)
		{
			System.Collections.Generic.LinkedListNode<SpriteIndex> t_node = this.list.Create();
			{
				//node
				t_node.Value.node = t_node;

				#if(DEF_BLUEBACK_GL_DEBUGVIEW)
				t_node.Value.debugview_gameobject.SetActive(true);

				#if(DEF_BLUEBACK_GL_DEBUGVIEW_VIEWALL)
				#else
				t_node.Value.debugview_gameobject.hideFlags = UnityEngine.HideFlags.None;
				#endif

				#endif

				//buffer
				this.buffer[t_node.Value.index] = new SpriteBuffer(){
					visible = true,
					material_index = a_material_index,
					texture_index = a_texture_index,
					color = a_color,
					texcord_0 = 0.0f,
					texcord_1 = 0.0f,
					texcord_2 = 1.0f,
					texcord_3 = 1.0f,
					vertex = new float[8]{
						(float)(a_x) / this.width,
						1.0f - (float)(a_y) / this.height,
						(float)(a_x + a_w) / this.width,
						1.0f - (float)(a_y) / this.height,
						(float)(a_x + a_w) / this.width,
						1.0f - (float)(a_y + a_h) / this.height,
						(float)(a_x) / this.width,
						1.0f - (float)(a_y + a_h) / this.height,
					},
				};
			}
			return t_node.Value;
		}

		/** DeleteSprite
		*/
		public void DeleteSprite(SpriteIndex a_spriteindex)
		{
			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			a_spriteindex.debugview_gameobject.SetActive(false);

			#if(DEF_BLUEBACK_GL_DEBUGVIEW_VIEWALL)
			#else
			a_spriteindex.debugview_gameobject.hideFlags = UnityEngine.HideFlags.HideInHierarchy;
			#endif

			#endif

			this.list.Delete(a_spriteindex.node);

			a_spriteindex.node = null;
		}

		/** UnityPostRender
		*/
		public void UnityPostRender()
		{
			int t_current_material_index = -1;
			bool t_is_begin = false;

			this.list.GcWithSwapBuffer();

			{
				UnityEngine.GL.PushMatrix();
				{
					UnityEngine.GL.LoadOrtho();

					int ii_max = this.list.list_use.Count;
					for(int ii=0;ii<ii_max;ii++){
						if(this.buffer[ii].visible == true){
							if(t_current_material_index != this.buffer[ii].material_index){
								t_current_material_index = this.buffer[ii].material_index;
								if(t_is_begin == true){
									t_is_begin = false;
									UnityEngine.GL.End();
								}
							}

							if(this.materialexecutelist[t_current_material_index].PreSetPass(ref this.buffer[ii]) == true){
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
								UnityEngine.GL.Color(this.buffer[ii].color);

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord_0,this.buffer[ii].texcord_3);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex[0],this.buffer[ii].vertex[1],0.0f);

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord_2,this.buffer[ii].texcord_3);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex[2],this.buffer[ii].vertex[3],0.0f);

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord_2,this.buffer[ii].texcord_1);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex[4],this.buffer[ii].vertex[5],0.0f);

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord_0,this.buffer[ii].texcord_1);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex[6],this.buffer[ii].vertex[7],0.0f);	
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

