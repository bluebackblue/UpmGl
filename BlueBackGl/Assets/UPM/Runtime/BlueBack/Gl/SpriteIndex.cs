

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
	/** SpriteIndex
	*/
	#if(ASMDEF_TRUE)
	public class SpriteIndex : BlueBack.PoolList.BufferList_Item_Base , System.IDisposable
	#else
	public class SpriteIndex : System.IDisposable
	#endif
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
		public Sprite_DebugView_MonoBehaviour debugview_monobehaviour;
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

		/** GetSpriteBuffer
		*/
		public ref SpriteBuffer GetSpriteBuffer()
		{
			return ref this.spritelist.buffer[this.index];
		}

		/** constructor
		*/
		#if(DEF_BLUEBACK_GL_DEBUGVIEW)
		public SpriteIndex(SpriteList a_spritelist,bool a_debugview_disable)
		#else
		public SpriteIndex(SpriteList a_spritelist)
		#endif
		{
			//spritelist
			this.spritelist = a_spritelist;

			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			if(a_debugview_disable == false){
				this.debugview_gameobject = new UnityEngine.GameObject("sprite");
				this.debugview_monobehaviour = this.debugview_gameobject.AddComponent<Sprite_DebugView_MonoBehaviour>();
				this.debugview_gameobject.SetActive(false);

				#if(DEF_BLUEBACK_GL_DEBUGVIEW_VIEWALL)
				#else
				this.debugview_gameobject.hideFlags = UnityEngine.HideFlags.HideInHierarchy;
				#endif

				UnityEngine.GameObject.DontDestroyOnLoad(this.debugview_gameobject);
				this.debugview_monobehaviour.spriteindex = this;
			}
			#endif
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
			#if(DEF_BLUEBACK_GL_DEBUGVIEW)
			if(this.debugview_gameobject != null){
				UnityEngine.GameObject.Destroy(this.debugview_gameobject);
				this.debugview_gameobject = null;
			}
			#endif
		}

		/** 「DebugView」用。
		*/
		#if(DEF_BLUEBACK_GL_DEBUGVIEW)
		public void SetDebugViewName(string a_debugname)
		{
			if(this.debugview_gameobject != null){
				this.debugview_gameobject.name = a_debugname;
			}
		}
		#endif

		/** SetDebugViewActive
		*/
		#if(DEF_BLUEBACK_GL_DEBUGVIEW)
		public void SetDebugViewActive(bool a_flag)
		{
			if(this.debugview_gameobject != null){
				this.debugview_gameobject.SetActive(a_flag);

				#if(DEF_BLUEBACK_GL_DEBUGVIEW_VIEWALL)
				#else
				if(a_flag == true){
					this.debugview_gameobject.hideFlags = UnityEngine.HideFlags.None;
				}else{
					this.debugview_gameobject.hideFlags = UnityEngine.HideFlags.HideInHierarchy;
				}
				#endif
			}
		}
		#endif
	}
}

