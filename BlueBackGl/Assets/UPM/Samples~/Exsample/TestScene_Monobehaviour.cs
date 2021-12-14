

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
					t_initparam.texture_max = 2;
					t_initparam.material_max = 2;
					t_initparam.sprite_max = 100;
					t_initparam.width = SCREEN_W;
					t_initparam.height = SCREEN_H;
				}
				this.gl = new BlueBack.Gl.Gl(in t_initparam);

				//texturelist
				this.gl.texturelist.list[0] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("00");
				this.gl.texturelist.list[1] = UnityEngine.Resources.Load<UnityEngine.Texture2D>("01");

				//materialexecutelist
				this.gl.materialexecutelist.list[0] = new BlueBack.Gl.MaterialExecute_SImple(this.gl,UnityEngine.Resources.Load<UnityEngine.Material>("gl0"));
				this.gl.materialexecutelist.list[1] = new BlueBack.Gl.MaterialExecute_SImple(this.gl,UnityEngine.Resources.Load<UnityEngine.Material>("gl1"));
			}

			for(int xx=0;xx<8;xx++){
				for(int yy=0;yy<8;yy++){
					this.gl.spritelist.CreateSprite(0,0,new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f),TIP_OFFSET_X + xx * (TIP_SIZE + 1),TIP_OFFSET_Y + yy * (TIP_SIZE + 1),TIP_SIZE,TIP_SIZE);
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

