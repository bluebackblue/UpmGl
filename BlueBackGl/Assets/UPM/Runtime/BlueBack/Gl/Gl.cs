

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


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

		/** gl
		*/
		private UnityEngine.GameObject gl_gameobject;
		private UnityEngine.Camera gl_camera;

		/** constructor
		*/
		public Gl(in InitParam a_initparam)
		{
			//texturelist
			this.texturelist = new TextureList(in a_initparam);

			//materialexecutelist
			this.materialexecutelist = new MaterialExecuteList(in a_initparam);

			//spritelist
			this.spritelist = new SpriteList[a_initparam.spritelist_max];
			for(int ii=0;ii<this.spritelist.Length;ii++){
				this.spritelist[ii] = new SpriteList(in a_initparam,this);
			}

			//gl_gameobject
			this.gl_gameobject = new UnityEngine.GameObject("gl");
			UnityEngine.GameObject.DontDestroyOnLoad(this.gl_gameobject);

			//gl_camera
			this.gl_camera = this.gl_gameobject.AddComponent<UnityEngine.Camera>();
			this.gl_camera.Reset();
			this.gl_camera.depth = a_initparam.camera_depth;
			this.gl_camera.orthographic = true;
			this.gl_camera.clearFlags = a_initparam.camera_clearflag;
			this.gl_camera.backgroundColor = a_initparam.camera_bgcolor;
			this.gl_camera.cullingMask = a_initparam.camera_cullingmask;
			this.gl_camera.useOcclusionCulling = false;

			//gl_monobehaviour
			Gl_MonoBehaviour t_gl_monobehaviour = this.gl_gameobject.AddComponent<Gl_MonoBehaviour>();
			t_gl_monobehaviour.spritelist = this.spritelist;
		}

		/** [IDisposable]Dispose。
		*/
		public void Dispose()
		{
			//texturelist
			this.texturelist.Dispose();
			this.texturelist = null;

			//spritelist
			foreach(SpriteList t_spritelist in this.spritelist){
				t_spritelist.Dispose();
			}
			this.spritelist = null;

			if(this.gl_gameobject != null){
				UnityEngine.GameObject.Destroy(this.gl_gameobject);
				this.gl_gameobject = null;
			}
		}
	}
}

