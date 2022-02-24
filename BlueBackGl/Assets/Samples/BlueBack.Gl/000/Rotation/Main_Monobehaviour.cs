

/** BlueBack.Gl.Samples.Rotation
*/
namespace BlueBack.Gl.Samples.Rotation
{
	/** Main_Monobehaviour
	*/
	public sealed class Main_Monobehaviour : UnityEngine.MonoBehaviour
	{
		/** gl
		*/
		private BlueBack.Gl.Gl gl;

		/** spriteindex
		*/
		private BlueBack.Gl.SpriteIndex spriteindex;

		/** angle
		*/
		public float angle;

		/** shader
		*/
		public UnityEngine.Shader shader;

		/** material
		*/
		public UnityEngine.Material material;

		/** vertex
		*/
		public Unity.Mathematics.float2x2 vertex;

		/** texcord
		*/
		public Unity.Mathematics.float2x2 texcord;

		/** offset
		*/
		public Unity.Mathematics.float2 offset;

		/** Awake
		*/
		public void Awake()
		{
			//gl
			{
				BlueBack.Gl.InitParam t_initparam = BlueBack.Gl.InitParam.CreateDefault();
				{
					t_initparam.spritelist_max = 2;
					t_initparam.texture_max = 2;
					t_initparam.material_max = 2;
					t_initparam.sprite_max = 10;
					t_initparam.screenparam = BlueBack.Gl.ScreenTool.CreateScreenParamWidthStretch(1280,720,UnityEngine.Screen.width,UnityEngine.Screen.height);
				}
				this.gl = new BlueBack.Gl.Gl(in t_initparam);

				UnityEngine.Texture2D t_texture = new UnityEngine.Texture2D(32,32,UnityEngine.TextureFormat.ARGB32,false);
				{
					for(int yy=0;yy<t_texture.height;yy++){
						for(int xx=0;xx<t_texture.width;xx++){
							float t_r = (float)xx / t_texture.width;
							float t_g = (float)yy / t_texture.height;
							t_texture.SetPixel(xx,yy,new UnityEngine.Color(t_r,t_g,0.0f,1.0f));
						}
					}
					t_texture.wrapMode = UnityEngine.TextureWrapMode.Clamp;
					t_texture.filterMode = UnityEngine.FilterMode.Point;
					t_texture.Apply();
				}

				//texturelist
				this.gl.texturelist.list[0] = t_texture;

				//shader
				this.shader = UnityEngine.Shader.Find("Unlit/Texture");

				//material
				this.material = new UnityEngine.Material(this.shader);

				//vertex
				this.vertex = new Unity.Mathematics.float2x2(
					new Unity.Mathematics.float2(-100.0f,-100.0f),
					new Unity.Mathematics.float2(100.0f,100.0f)
				);

				//texcord
				this.texcord = new Unity.Mathematics.float2x2(
					new Unity.Mathematics.float2(0.0f,0.0f),
					new Unity.Mathematics.float2(1.0f,1.0f)
				);

				//offset
				this.offset = new Unity.Mathematics.float2(1280 / 2,720 / 2);

				//materialexecutelist
				this.gl.materialexecutelist.list[0] = new BlueBack.Gl.MaterialExecute_SImple(this.gl,this.material);
			}

			{
				this.spriteindex = this.gl.spritelist[0].CreateSprite();
				ref BlueBack.Gl.SpriteBuffer t_spritebuffer = ref this.spriteindex.GetSpriteBuffer();

				t_spritebuffer.visible = true;
				t_spritebuffer.color = new UnityEngine.Color(1.0f,1.0f,1.0f,1.0f);
				t_spritebuffer.material_index = 0;
				t_spritebuffer.texture_index = 0;
				t_spritebuffer.userdata = 0;
			}

			//angle
			this.angle = 0.0f;
		}

		/** Update
		*/
		public void Update()
		{
			this.angle += UnityEngine.Time.deltaTime;

			ref BlueBack.Gl.SpriteBuffer t_spritebuffer = ref this.spriteindex.GetSpriteBuffer();

			BlueBack.Gl.SpriteTool.SetTexcord(ref t_spritebuffer,in this.texcord);

			BlueBack.Gl.SpriteTool.SetVertex(
				ref t_spritebuffer,
				in this.vertex,
				in this.offset,
				Unity.Mathematics.quaternion.AxisAngle(new UnityEngine.Vector3(0.0f,0.0f,1.0f),this.angle),
				in this.gl.screenparam
			);
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

