

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_POOLLIST)||(USERDEF_BLUEBACK_POOLLIST))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** SpriteList
	*/
	public sealed class SpriteList : System.IDisposable
	{
		/** gl
		*/
		public Gl gl;

		/** index
		*/
		public int index;

		/** debugview_disable
		*/
		#if(DEF_BLUEBACK_GL_DEBUGVIEW)
		public readonly bool debugview_disable;
		#endif

		/** buffer
		*/
		public SpriteBuffer[] buffer;

		/** list
		*/
		#if(ASMDEF_TRUE)
		public BlueBack.PoolList.BufferList<SpriteIndex,SpriteBuffer> list;
		#endif

		/** materialexecutelist
		*/
		public MaterialExecute_Base[] materialexecutelist;

		/** constructor
		*/
		public SpriteList(in InitParam a_initparam,Gl a_gl,int a_index)
		#if(ASMDEF_TRUE)
		{
			//gl
			this.gl = a_gl;

			//index
			this.index = a_index;

			//debugview
			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			this.debugview_disable = a_initparam.spritelist[a_index].debugview_disable;
			#endif

			//buffer
			this.buffer = new SpriteBuffer[a_initparam.spritelist[a_index].sprite_max];

			//list
			this.list = new PoolList.BufferList<SpriteIndex,SpriteBuffer>(this.buffer,()=>{
				#if(DEF_BLUEBACK_GL_DEBUGVIEW)
				return new SpriteIndex(this,this.debugview_disable);
				#else
				return new SpriteIndex(this);
				#endif
			});

			//materialexecutelist
			this.materialexecutelist = a_gl.materialexecutelist.list;
		}
		#else
		{
		}
		#endif

		/** [System.IDisposable]Dispose。
		*/
		public void Dispose()
		#if(ASMDEF_TRUE)
		{
			foreach(SpriteIndex t_spriteindex in this.list.list_free){
				t_spriteindex.Dispose();
			}
			foreach(SpriteIndex t_spriteindex in this.list.list_use){
				t_spriteindex.Dispose();
			}
		}
		#else
		{
		}
		#endif

		/** CreateSprite
		*/
		public SpriteIndex CreateSprite()
		#if(ASMDEF_TRUE)
		{
			System.Collections.Generic.LinkedListNode<SpriteIndex> t_node = this.list.Create();

			#if(DEF_BLUEBACK_DEBUG_ASSERT)
			DebugTool.Assert(t_node != null,"node == null");
			#endif

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
					color = new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f),
					texcord = Unity.Mathematics.float2x4.zero,
					vertex = Unity.Mathematics.float2x4.zero,
				};
			}

			return t_node.Value;
		}
		#else
		{
			return null;
		}
		#endif

		/** CreateSprite
		*/
		public SpriteIndex CreateSprite(bool a_visible,int a_material_index,int a_texture_index)
		#if(ASMDEF_TRUE)
		{
			System.Collections.Generic.LinkedListNode<SpriteIndex> t_node = this.list.Create();

			#if(DEF_BLUEBACK_DEBUG_ASSERT)
			DebugTool.Assert(t_node != null,"node == null");
			#endif

			{
				//node
				t_node.Value.node = t_node;

				#if(DEF_BLUEBACK_GL_DEBUGVIEW)
				t_node.Value.SetDebugViewActive(true);
				#endif

				//buffer
				this.buffer[t_node.Value.index] = new SpriteBuffer(){
					visible = a_visible,
					material_index = a_material_index,
					texture_index = a_texture_index,
					color = new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f),
					texcord = Unity.Mathematics.float2x4.zero,
					vertex = Unity.Mathematics.float2x4.zero,
				};
			}

			return t_node.Value;
		}
		#else
		{
			return null;
		}
		#endif

		/** DeleteSprite
		*/
		public void DeleteSprite(SpriteIndex a_spriteindex)
		#if(ASMDEF_TRUE)
		{
			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			a_spriteindex.SetDebugViewActive(false);
			#endif

			this.list.Delete(a_spriteindex.node);

			a_spriteindex.node = null;
		}
		#else
		{
		}
		#endif

		/** UnityPostRender
		*/
		public void UnityPostRender()
		#if(ASMDEF_TRUE)
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

								#if(DEF_BLUEBACK_DEBUG_ASSERT)
								DebugTool.Assert(this.materialexecutelist[t_current_material_index] != null,"material == null");
								#endif

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

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord.c0.x,this.buffer[ii].texcord.c0.y);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex.c0.x,this.buffer[ii].vertex.c0.y,0.0f);

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord.c1.x,this.buffer[ii].texcord.c1.y);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex.c1.x,this.buffer[ii].vertex.c1.y,0.0f);

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord.c2.x,this.buffer[ii].texcord.c2.y);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex.c2.x,this.buffer[ii].vertex.c2.y,0.0f);

								UnityEngine.GL.TexCoord2(this.buffer[ii].texcord.c3.x,this.buffer[ii].texcord.c3.y);
								UnityEngine.GL.Vertex3(this.buffer[ii].vertex.c3.x,this.buffer[ii].vertex.c3.y,0.0f);
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
		#else
		{
		}
		#endif
	}
}

