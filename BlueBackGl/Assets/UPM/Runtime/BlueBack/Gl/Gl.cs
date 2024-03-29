

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
	/** Gl
	*/
	public sealed class Gl : System.IDisposable
	{
		/** texturelist
		*/
		public TextureList texturelist;

		/** materialexecutelist
		*/
		public MaterialExecuteList materialexecutelist;

		/** spritelist
		*/
		public SpriteList[] spritelist;

		/** gameobject
		*/
		private UnityEngine.GameObject gameobject;

		/** camera
		*/
		public UnityEngine.Camera camera;

		/** screenparam
		*/
		public ScreenParam screenparam;

		/** constructor
		*/
		public Gl(in InitParam a_initparam)
		{
			//texturelist
			this.texturelist = new TextureList(in a_initparam);

			//materialexecutelist
			this.materialexecutelist = new MaterialExecuteList(in a_initparam);

			//spritelist
			this.spritelist = new SpriteList[a_initparam.spritelist.Length];
			for(int ii=0;ii<this.spritelist.Length;ii++){
				this.spritelist[ii] = new SpriteList(in a_initparam,this,ii);
			}

			//gameobject
			this.gameobject = new UnityEngine.GameObject(a_initparam.gameobject_name);
			UnityEngine.GameObject.DontDestroyOnLoad(this.gameobject);

			//camera
			this.camera = this.gameobject.AddComponent<UnityEngine.Camera>();
			this.camera.Reset();
			this.camera.depth = a_initparam.camera_depth;
			this.camera.orthographic = true;
			this.camera.orthographicSize = a_initparam.camera_orthographic_size;
			this.camera.clearFlags = a_initparam.camera_clearflag;
			this.camera.backgroundColor = a_initparam.camera_bgcolor;
			this.camera.cullingMask = a_initparam.camera_cullingmask;
			this.camera.useOcclusionCulling = false;
			this.camera.allowHDR = a_initparam.camera_hdr;
			this.camera.allowMSAA = a_initparam.camera_msaa;

			//screenparam
			this.screenparam = a_initparam.screenparam;

			//unitycallback
			UnityCallBack_MonoBehaviour t_unitycallback_monobehaviour = this.gameobject.AddComponent<UnityCallBack_MonoBehaviour>();
			t_unitycallback_monobehaviour.spritelist = this.spritelist;
		}

		/** [System.IDisposable]Dispose。
		*/
		public void Dispose()
		{
			//texturelist
			if(this.texturelist != null){
				this.texturelist.Dispose();
				this.texturelist = null;
			}

			//spritelist
			if(this.spritelist != null){
				foreach(SpriteList t_spritelist in this.spritelist){
					t_spritelist.Dispose();
				}
				this.spritelist = null;
			}

			if(this.gameobject != null){
				UnityEngine.GameObject.Destroy(this.gameobject);
				this.gameobject = null;
			}
		}
	}
}

