

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
		public SpriteList spritelist;

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
			this.spritelist = new SpriteList(in a_initparam,this);

			//gl_gameobject
			this.gl_gameobject = new UnityEngine.GameObject("gl");
			UnityEngine.GameObject.DontDestroyOnLoad(this.gl_gameobject);

			//gl_camera
			this.gl_camera = this.gl_gameobject.AddComponent<UnityEngine.Camera>();
			this.gl_camera.Reset();
			this.gl_camera.depth = 0.0f;
			this.gl_camera.orthographic = true;
			this.gl_camera.clearFlags = UnityEngine.CameraClearFlags.SolidColor;
			this.gl_camera.backgroundColor = new UnityEngine.Color(0.0f,0.0f,0.0f,1.0f);
			this.gl_camera.cullingMask = 0;
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

			//spritelist
			this.spritelist.Dispose();

			if(this.gl_gameobject != null){
				UnityEngine.GameObject.Destroy(this.gl_gameobject);
				this.gl_gameobject = null;
			}
		}
	}
}

