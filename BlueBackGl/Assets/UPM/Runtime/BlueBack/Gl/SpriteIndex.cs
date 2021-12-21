

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** SpriteIndex
	*/
	public class SpriteIndex : BlueBack.PoolList.BufferList_Item_Base , System.IDisposable
	{
		/** index
		*/
		public int index;

		/** spritelist
		*/
		public SpriteList spritelist;

		/** node
		*/
		public System.Collections.Generic.LinkedListNode<SpriteIndex> node;

		/** debugview_gameobject
		*/
		#if(DEF_BLUEBACK_GL_DEBUGVIEW)
		public UnityEngine.GameObject debugview_gameobject;
		#endif

		/** [BlueBack.PoolList.BufferList_Item_Base]GetIndex
		*/
		public int GetIndex()
		{
			return this.index;
		}

		/** [BlueBack.PoolList.BufferList_Item_Base]SetIndex
		*/
		public void SetIndex(int a_index)
		{
			this.index = a_index;
		}

		/** constructor
		*/
		public SpriteIndex(SpriteList a_spritelist)
		{
			//spritelist
			this.spritelist = a_spritelist;

			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			this.debugview_gameobject = new UnityEngine.GameObject("sprite");
			Sprite_DebugView_MonoBehaviour t_debugview_monobehaviour = this.debugview_gameobject.AddComponent<Sprite_DebugView_MonoBehaviour>();
			this.debugview_gameobject.SetActive(false);

			#if(DEF_BLUEBACK_GL_DEBUGVIEW_VIEWALL)
			#else
			this.debugview_gameobject.hideFlags = UnityEngine.HideFlags.HideInHierarchy;
			#endif

			UnityEngine.GameObject.DontDestroyOnLoad(this.debugview_gameobject);
			t_debugview_monobehaviour.spritelist = a_spritelist;
			t_debugview_monobehaviour.spriteindex = this;
			#endif
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			UnityEngine.GameObject.Destroy(this.debugview_gameobject);
			this.debugview_gameobject = null;
			#endif
		}

		/** SetDebugName
		*/
		#if(DEF_BLUEBACK_GL_DEBUGVIEW)
		public void SetDebugName(string a_debugname)
		{
			this.debugview_gameobject.name = a_debugname;
		}
		#endif

		/** SetDebugActive
		*/
		#if(DEF_BLUEBACK_GL_DEBUGVIEW)
		public void SetDebugActive(bool a_flag)
		{
			if(a_flag == true){
				this.debugview_gameobject.SetActive(true);

				#if(DEF_BLUEBACK_GL_DEBUGVIEW_VIEWALL)
				#else
				this.debugview_gameobject.hideFlags = UnityEngine.HideFlags.None;
				#endif
			}else{
				this.debugview_gameobject.SetActive(false);

				#if(DEF_BLUEBACK_GL_DEBUGVIEW_VIEWALL)
				#else
				this.debugview_gameobject.hideFlags = UnityEngine.HideFlags.HideInHierarchy;
				#endif
			}
		}
		#endif
	}
}

