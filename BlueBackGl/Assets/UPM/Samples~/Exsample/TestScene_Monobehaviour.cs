

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

		/** SCREEN
		*/
		private const int SCREEN_W = 1280;
		private const int SCREEN_H = 720;

		/** TIP
		*/
		private const int TIP_SIZE = 60;
		private const int TIP_OFFSET_X = (SCREEN_W - (TIP_SIZE + 1) * 8) / 2;
		private const int TIP_OFFSET_Y = (SCREEN_H - (TIP_SIZE + 1) * 8) / 2;

		/** Awake
		*/
		public void Awake()
		{
			{
				BlueBack.Gl.InitParam t_initparam = BlueBack.Gl.InitParam.CreateDefault();
				{
					t_initparam.spritelist_max = 2;
					t_initparam.texture_max = 2;
					t_initparam.material_max = 2;
					t_initparam.sprite_max = 100;
					t_initparam.width = SCREEN_W;
					t_initparam.height = SCREEN_H;
				}
				this.gl = new BlueBack.Gl.Gl(in t_initparam);

				//texturelist
				this.gl.texturelist.list[0] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("red");
				this.gl.texturelist.list[1] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("green");

				//materialexecutelist
				this.gl.materialexecutelist.list[0] = new BlueBack.Gl.MaterialExecute_SImple(this.gl,UnityEngine.Resources.Load<UnityEngine.Material>("opaque"));
				this.gl.materialexecutelist.list[1] = new BlueBack.Gl.MaterialExecute_SImple(this.gl,UnityEngine.Resources.Load<UnityEngine.Material>("transparent"));
			}

			for(int xx=0;xx<8;xx++){
				for(int yy=0;yy<8;yy++){
					int t_texture_index = (xx + yy < 8) ? 0 : 1;
					BlueBack.Gl.SpriteIndex t_spriteindex = this.gl.spritelist[0].CreateSprite(0,t_texture_index,new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f),TIP_OFFSET_X + xx * (TIP_SIZE + 1),TIP_OFFSET_Y + yy * (TIP_SIZE + 1),TIP_SIZE,TIP_SIZE);
					#if(DEF_BLUEBACK_GL_DEBUGVIEW)
					t_spriteindex.SetDebugName(xx.ToString() + "_" + yy.ToString());
					#endif
				}
			}

		}

		/** OnDestroy
		*/
		public void OnDestroy()
		{
		}
	}
}

