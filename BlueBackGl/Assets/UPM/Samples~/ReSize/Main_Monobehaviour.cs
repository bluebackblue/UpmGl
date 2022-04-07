

/** BlueBack.Gl.Samples.ReSize
*/
namespace BlueBack.Gl.Samples.ReSize
{
	/** Main_Monobehaviour
	*/
	public sealed class Main_Monobehaviour : UnityEngine.MonoBehaviour
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
			public BlueBack.Gl.SpriteIndex spriteindex;
			public Unity.Mathematics.float2 offset;
		}

		/** list
		*/
		private System.Collections.Generic.List<Item> list;

		/** rendertexture
		*/
		public int rendertexture_w;
		public int rendertexture_h;

		/** texcord
		*/
		public Unity.Mathematics.float2x2 texcord;

		/** vertex
		*/
		public Unity.Mathematics.float2x2 vertex;

		/** Awake
		*/
		public void Awake()
		{
			//rendertexture
			this.rendertexture_w = UnityEngine.Screen.width;
			this.rendertexture_h = UnityEngine.Screen.height;

			//gl
			{
				BlueBack.Gl.InitParam t_initparam = BlueBack.Gl.InitParam.CreateDefault();
				{
					t_initparam.spritelist = new InitParam.SpriteList[]{
						new InitParam.SpriteList(){
							sprite_max = 100,
							#if(DEF_BLUEBACK_GL_DEBUGVIEW)
							debugview_disable = false,
							#endif
						},
						new InitParam.SpriteList(){
							sprite_max = 100,
							#if(DEF_BLUEBACK_GL_DEBUGVIEW)
							debugview_disable = false,
							#endif
						}
					};
					t_initparam.texture_max = 2;
					t_initparam.material_max = 2;
					t_initparam.screenparam = BlueBack.Gl.ScreenTool.CreateScreenParamWidthStretch(VIRTUAL_SCREEN_W,VIRTUAL_SCREEN_H,this.rendertexture_w,this.rendertexture_h);
				}
				this.gl = new BlueBack.Gl.Gl(in t_initparam);

				//texturelist
				this.gl.texturelist.list[0] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("ReSize/Red");
				this.gl.texturelist.list[1] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("ReSize/Green");

				//materialexecutelist
				this.gl.materialexecutelist.list[0] = new BlueBack.Gl.MaterialExecute_SImple(this.gl,UnityEngine.Resources.Load<UnityEngine.Material>("ReSize/Opaque"));
				this.gl.materialexecutelist.list[1] = new BlueBack.Gl.MaterialExecute_SImple(this.gl,UnityEngine.Resources.Load<UnityEngine.Material>("ReSize/Transparent"));
			}

			{
				this.list = new System.Collections.Generic.List<Item>();

				//texcord
				this.texcord = new Unity.Mathematics.float2x2(
					new Unity.Mathematics.float2(0.0f,0.0f),
					new Unity.Mathematics.float2(1.0f,1.0f)
				);

				//vertex
				this.vertex = new Unity.Mathematics.float2x2(
					new Unity.Mathematics.float2(0.0f,0.0f),
					new Unity.Mathematics.float2(TIP_SIZE,TIP_SIZE)
				);

				//８ｘ８。
				for(int xx=0;xx<8;xx++){
					for(int yy=0;yy<8;yy++){
						Item t_item = new Item();
						{
							//spriteindex
							t_item.spriteindex = this.gl.spritelist[0].CreateSprite();

							//offset
							t_item.offset = new Unity.Mathematics.float2(
								TIP_OFFSET_X + xx * (TIP_SIZE + 1),
								TIP_OFFSET_Y + yy * (TIP_SIZE + 1)
							);

							ref BlueBack.Gl.SpriteBuffer t_spritebuffer = ref t_item.spriteindex.GetSpriteBuffer();
							{
								t_spritebuffer.visible = true;
								t_spritebuffer.material_index = 0;
								t_spritebuffer.texture_index = (xx + yy < 8) ? 0 : 1;
								t_spritebuffer.color = new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f);

								BlueBack.Gl.SpriteTool.SetVertex(ref t_spritebuffer,in this.vertex,in t_item.offset,in this.gl.screenparam);
								BlueBack.Gl.SpriteTool.SetTexcord(ref t_spritebuffer,in this.texcord);
							}

							#if(DEF_BLUEBACK_GL_DEBUGVIEW)
							t_item.spriteindex.SetDebugViewName(xx.ToString() + "_" + yy.ToString());
							#endif
						}
						this.list.Add(t_item);
					}
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
				this.gl.screenparam = BlueBack.Gl.ScreenTool.CreateScreenParamWidthStretch(VIRTUAL_SCREEN_W,VIRTUAL_SCREEN_H,this.rendertexture_w,this.rendertexture_h);

				int ii_max = this.list.Count;
				for(int ii=0;ii<ii_max;ii++){
					Item t_item = this.list[ii];
					ref BlueBack.Gl.SpriteBuffer t_spritebuffer = ref t_item.spriteindex.GetSpriteBuffer();
					BlueBack.Gl.SpriteTool.SetVertex(ref t_spritebuffer,in this.vertex,in t_item.offset,in this.gl.screenparam);
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

