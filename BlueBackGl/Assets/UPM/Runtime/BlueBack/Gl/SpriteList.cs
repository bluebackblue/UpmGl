

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

		/** constructor
		*/
		public SpriteList(in InitParam a_initparam,Gl a_gl)
		{
			//buffer
			this.buffer = new SpriteBuffer[a_initparam.sprite_max];

			//list
			this.list = new PoolList.BufferList<SpriteIndex,SpriteBuffer>(this.buffer,()=>{
				return new SpriteIndex(this);
			});

			//materialexecutelist
			this.materialexecutelist = a_gl.materialexecutelist.list;
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
		public SpriteIndex CreateSprite()
		{
			System.Collections.Generic.LinkedListNode<SpriteIndex> t_node = this.list.Create();
			{
				//node
				t_node.Value.node = t_node;

				#if(DEF_BLUEBACK_GL_DEBUGVIEW)
				t_node.Value.SetDebugViewActive(true);
				#endif

				//buffer
				this.buffer[t_node.Value.index] = new SpriteBuffer(){
					visible = false,
					material_index = -1,
					texture_index = -1,
					color = new UnityEngine.Color(1,1,1,1),
					texcord_1_x1 = 0.0f,
					texcord_1_y1 = 1.0f,
					texcord_2_x2 = 1.0f,
					texcord_2_y1 = 1.0f,
					texcord_3_x2 = 1.0f,
					texcord_3_y2 = 0.0f,
					texcord_4_x1 = 0.0f,
					texcord_4_y2 = 0.0f,
					vertex_x1 = 0,
					vertex_y1 = 0,
					vertex_x2 = 0,
					vertex_y2 = 0,
					vertex_x3 = 0,
					vertex_y3 = 0,
					vertex_x4 = 0,
					vertex_y4 = 0,
				};
			}
			return t_node.Value;
		}

		/** CreateSprite
		*/
		public SpriteIndex CreateSprite(bool a_visible,int a_material_index,int a_texture_index,in UnityEngine.Color a_color,int a_x,int a_y,int a_w,int a_h,in ScreenParam a_screenparam)
		{
			System.Collections.Generic.LinkedListNode<SpriteIndex> t_node = this.list.Create();
			{
				//node
				t_node.Value.node = t_node;

				#if(DEF_BLUEBACK_GL_DEBUGVIEW)
				t_node.Value.SetDebugViewActive(true);
				#endif

				float t_x1 = ((float)a_x * a_screenparam.scale_w) * a_screenparam.virtual_w_pix_inv;
				float t_y1 = (1.0f - ((float)a_y * a_screenparam.scale_h) * a_screenparam.virtual_h_pix_inv);
				float t_x2 = t_x1 + ((float)a_w * a_screenparam.scale_w) * a_screenparam.virtual_w_pix_inv;
				float t_y2 = (t_y1 - ((float)a_h * a_screenparam.scale_h) * a_screenparam.virtual_h_pix_inv);

				//buffer
				this.buffer[t_node.Value.index] = new SpriteBuffer(){
					visible = a_visible,
					material_index = a_material_index,
					texture_index = a_texture_index,
					color = a_color,
					texcord_1_x1 = 0.0f,
					texcord_1_y1 = 1.0f,
					texcord_2_x2 = 1.0f,
					texcord_2_y1 = 1.0f,
					texcord_3_x2 = 1.0f,
					texcord_3_y2 = 0.0f,
					texcord_4_x1 = 0.0f,
					texcord_4_y2 = 0.0f,
					vertex_x1 = t_x1 + a_screenparam.offset_x,
					vertex_y1 = t_y1 - a_screenparam.offset_y,
					vertex_x2 = t_x2 + a_screenparam.offset_x,
					vertex_y2 = t_y1 - a_screenparam.offset_y,
					vertex_x3 = t_x2 + a_screenparam.offset_x,
					vertex_y3 = t_y2 - a_screenparam.offset_y,
					vertex_x4 = t_x1 + a_screenparam.offset_x,
					vertex_y4 = t_y2 - a_screenparam.offset_y,
				};
			}
			return t_node.Value;
		}

		/** DeleteSprite
		*/
		public void DeleteSprite(SpriteIndex a_spriteindex)
		{
			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			a_spriteindex.SetDebugViewActive(false);
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

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord_1_x1,this.buffer[ii].texcord_1_y1);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex_x1,this.buffer[ii].vertex_y1,0.0f);

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord_2_x2,this.buffer[ii].texcord_2_y1);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex_x2,this.buffer[ii].vertex_y2,0.0f);

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord_3_x2,this.buffer[ii].texcord_3_y2);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex_x3,this.buffer[ii].vertex_y3,0.0f);

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord_4_x1,this.buffer[ii].texcord_4_y2);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex_x4,this.buffer[ii].vertex_y4,0.0f);	
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

