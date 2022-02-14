

/** Samples.Gl.Exsample
*/
namespace Samples.Gl.Exsample
{
	/** TestScene_Monobehaviour
	*/
	public sealed class TestScene_Monobehaviour : UnityEngine.MonoBehaviour
	{
		/** gl
		*/
		private BlueBack.Gl.Gl gl;

		/** VIRTUAL_SCREEN
		*/
		private const int VIRTUAL_SCREEN_W = 1280;
		private const int VIRTUAL_SCREEN_H = 720;

		/** TIP
		*/
		private const int TIP_SIZE = 60;
		private const int TIP_OFFSET_X = (VIRTUAL_SCREEN_W - (TIP_SIZE + 1) * 8) / 2;
		private const int TIP_OFFSET_Y = (VIRTUAL_SCREEN_H - (TIP_SIZE + 1) * 8) / 2;

		/** Item
		*/
		private struct Item
		{
			public int x;
			public int y;
			public int w;
			public int h;
			public BlueBack.Gl.SpriteIndex spriteindex;
		}

		/** list
		*/
		private System.Collections.Generic.List<Item> list;

		/** screenparam
		*/
		public BlueBack.Gl.ScreenParam screenparam;

		/** rendertexture
		*/
		public int rendertexture_w;
		public int rendertexture_h;

		/** Awake
		*/
		public void Awake()
		{
			//rendertexture
			this.rendertexture_w = UnityEngine.Screen.width;
			this.rendertexture_h = UnityEngine.Screen.height;

			//screenparam
			this.screenparam = BlueBack.Gl.ScreenTool.CreateScreenParamWidthStretch(VIRTUAL_SCREEN_W,VIRTUAL_SCREEN_H,this.rendertexture_w,this.rendertexture_h);

			//gl
			{
				BlueBack.Gl.InitParam t_initparam = BlueBack.Gl.InitParam.CreateDefault();
				{
					t_initparam.spritelist_max = 2;
					t_initparam.texture_max = 2;
					t_initparam.material_max = 2;
					t_initparam.sprite_max = 100;
				}
				this.gl = new BlueBack.Gl.Gl(in t_initparam);

				//SetScreenParam
				#if(DEF_BLUEBACK_GL_DEBUGVIEW)
				BlueBack.Gl.Sprite_DebugView_MonoBehaviour.SetScreenParam(in this.screenparam);
				#endif
					
				//texturelist
				this.gl.texturelist.list[0] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("red");
				this.gl.texturelist.list[1] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("green");

				//materialexecutelist
				this.gl.materialexecutelist.list[0] = new BlueBack.Gl.MaterialExecute_SImple(this.gl,UnityEngine.Resources.Load<UnityEngine.Material>("opaque"));
				this.gl.materialexecutelist.list[1] = new BlueBack.Gl.MaterialExecute_SImple(this.gl,UnityEngine.Resources.Load<UnityEngine.Material>("transparent"));
			}

			{
				this.list = new System.Collections.Generic.List<Item>();

				//８ｘ８。
				for(int xx=0;xx<8;xx++){
					for(int yy=0;yy<8;yy++){
						Item t_item = new Item();
						{
							t_item.x = TIP_OFFSET_X + xx * (TIP_SIZE + 1);
							t_item.y = TIP_OFFSET_Y + yy * (TIP_SIZE + 1);
							t_item.w = TIP_SIZE;
							t_item.h = TIP_SIZE;
							int t_texture_index = (xx + yy < 8) ? 0 : 1;
							int t_material_index = 0;
							t_item.spriteindex = this.gl.spritelist[0].CreateSprite(
								true,
								t_material_index,
								t_texture_index,
								new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f),
								t_item.x,
								t_item.y,
								t_item.w,
								t_item.h,
								in this.screenparam
							);
							#if(DEF_BLUEBACK_GL_DEBUGVIEW)
							t_item.spriteindex.SetDebugViewName(xx.ToString() + "_" + yy.ToString());
							#endif
						}
						this.list.Add(t_item);
					}
				}

				//左上。
				{
					Item t_item = new Item();
					{
						t_item.x = 0;
						t_item.y = 0;
						t_item.w = 64;
						t_item.h = 64;
						int t_texture_index = 0;
						int t_material_index = 0;
						t_item.spriteindex = this.gl.spritelist[0].CreateSprite(
							true,
							t_material_index,
							t_texture_index,
							new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f),
							t_item.x,
							t_item.y,
							t_item.w,
							t_item.h,
							in this.screenparam
						);
						#if(DEF_BLUEBACK_GL_DEBUGVIEW)
						t_item.spriteindex.SetDebugViewName("lt");
						#endif
					}

					this.list.Add(t_item);
				}

				//右下。
				{
					Item t_item = new Item();
					{
						t_item.x = VIRTUAL_SCREEN_W - 64;
						t_item.y = VIRTUAL_SCREEN_H - 64;
						t_item.w = 64;
						t_item.h = 64;
						int t_texture_index = 0;
						int t_material_index = 0;
						t_item.spriteindex = this.gl.spritelist[0].CreateSprite(
							true,
							t_material_index,
							t_texture_index,
							new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f),
							t_item.x,
							t_item.y,
							t_item.w,
							t_item.h,
							in this.screenparam
						);
						#if(DEF_BLUEBACK_GL_DEBUGVIEW)
						t_item.spriteindex.SetDebugViewName("rd");
						#endif
					}
					this.list.Add(t_item);
				}
			}
		}

		/** Update
		*/
		public void Update()
		{
			//サイズ変更。
			if((this.rendertexture_w != UnityEngine.Screen.width)||(this.rendertexture_h != UnityEngine.Screen.height)){
				this.rendertexture_w = UnityEngine.Screen.width;
				this.rendertexture_h = UnityEngine.Screen.height;

				//screenparam
				this.screenparam = BlueBack.Gl.ScreenTool.CreateScreenParamWidthStretch(VIRTUAL_SCREEN_W,VIRTUAL_SCREEN_H,this.rendertexture_w,this.rendertexture_h);

				//SetScreenParam
				#if(DEF_BLUEBACK_GL_DEBUGVIEW)
				BlueBack.Gl.Sprite_DebugView_MonoBehaviour.SetScreenParam(in this.screenparam);
				#endif

				int ii_max = this.list.Count;
				for(int ii=0;ii<ii_max;ii++){
					Item t_item = this.list[ii];
					BlueBack.Gl.SpriteTool.SetTexcordXY12(t_item.spriteindex,0.0f,0.0f,1.0f,1.0f);
					BlueBack.Gl.SpriteTool.SetVertexXYWH(t_item.spriteindex,t_item.x,t_item.y,t_item.w,t_item.h,in this.screenparam);
				}
			}
		}

		/** OnDestroy
		*/
		public void OnDestroy()
		{
			if(this.gl != null){
				this.gl.Dispose();
				this.gl = null;
			}
		}
	}
}

