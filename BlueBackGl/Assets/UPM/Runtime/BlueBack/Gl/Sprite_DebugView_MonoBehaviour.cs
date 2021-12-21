

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** Sprite_DebugView_MonoBehaviour
	*/
	#if(DEF_BLUEBACK_GL_DEBUGVIEW)
	public class Sprite_DebugView_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** spriteindex
		*/
		public SpriteIndex spriteindex;

		/** Mode
		*/
		public enum Mode
		{
			/** 読み込み。
			*/
			Read,

			/** 書き込み。
			*/
			Write,

			/** なし。
			*/
			None,
		}

		/** mode
		*/
		public Mode mode;

		/** visible
		*/
		public bool visible;

		/** screen
		*/
		public int screen_w;
		public int screen_h;

		/** material_index
		*/
		public int material_index;

		/** texture_index
		*/
		public int texture_index;

		/** color
		*/
		public UnityEngine.Color color;

		/** texcord
		*/
		public float texcord_x1;
		public float texcord_y1;
		public float texcord_x2;
		public float texcord_y2;

		/** vertex
		*/
		public float vertex_x1;
		public float vertex_y1;
		public float vertex_x2;
		public float vertex_y2;
		public float vertex_x3;
		public float vertex_y3;
		public float vertex_x4;
		public float vertex_y4;

		/** Awake
		*/
		public void Awake()
		{
			this.mode = Mode.Read;
		}

		/** Update
		*/
		public void Update()
		{
			#if(UNITY_EDITOR)
			if(UnityEditor.Selection.activeGameObject == this.gameObject){
				SpriteList t_spritelist = this.spriteindex.spritelist;

				switch(this.mode){
				case Mode.Read:
					{
						this.Read(ref t_spritelist.buffer[this.spriteindex.index]);
					}break;
				case Mode.Write:
					{
						this.Write(ref t_spritelist.buffer[this.spriteindex.index]);
					}break;
				}
			}else{
				this.mode = Mode.Read;
			}
			#endif
		}

		/** SetScreenSize
		*/
		public void SetScreenSize(int a_screen_w,int a_screen_h)
		{
			this.screen_w = a_screen_w;
			this.screen_h = a_screen_h;
		}

		/** Read
		*/
		private void Read(ref SpriteBuffer a_spritebuffer)
		{
			this.visible = a_spritebuffer.visible;
			this.material_index = a_spritebuffer.material_index;
			this.texture_index = a_spritebuffer.texture_index;
			this.color = a_spritebuffer.color;
			this.vertex_x1 = a_spritebuffer.texcord_x1;
			this.vertex_y1 = a_spritebuffer.texcord_y1;
			this.vertex_x2 = a_spritebuffer.texcord_x2;
			this.vertex_y2 = a_spritebuffer.texcord_y2;
			this.vertex_x1 = a_spritebuffer.vertex_x1 * this.screen_w;
			this.vertex_y1 = this.screen_h - a_spritebuffer.vertex_y1 * this.screen_h;
			this.vertex_x2 = a_spritebuffer.vertex_x2 * this.screen_w;
			this.vertex_y2 = this.screen_h - a_spritebuffer.vertex_y2 * this.screen_h;
			this.vertex_x3 = a_spritebuffer.vertex_x3 * this.screen_w;
			this.vertex_y3 = this.screen_h - a_spritebuffer.vertex_y3 * this.screen_h;
			this.vertex_x4 = a_spritebuffer.vertex_x4 * this.screen_w;
			this.vertex_y4 = this.screen_h - a_spritebuffer.vertex_y4 * this.screen_h;
		}

		/** Write
		*/
		private void Write(ref SpriteBuffer a_spritebuffer)
		{
			a_spritebuffer.visible = this.visible;
			a_spritebuffer.material_index = this.material_index;
			a_spritebuffer.texture_index = this.texture_index;
			a_spritebuffer.color = this.color;
			a_spritebuffer.texcord_x1 = this.texcord_x1;
			a_spritebuffer.texcord_y1 = this.texcord_y1;
			a_spritebuffer.texcord_x2 = this.texcord_x2;
			a_spritebuffer.texcord_y2 = this.texcord_y2;
			a_spritebuffer.vertex_x1 = this.vertex_x1 / this.screen_w;
			a_spritebuffer.vertex_y1 = 1.0f - this.vertex_y1 / this.screen_h;
			a_spritebuffer.vertex_x2 = this.vertex_x2 / this.screen_w;
			a_spritebuffer.vertex_y2 = 1.0f - this.vertex_y2 / this.screen_h;
			a_spritebuffer.vertex_x3 = this.vertex_x3 / this.screen_w;
			a_spritebuffer.vertex_y3 = 1.0f - this.vertex_y3 / this.screen_h;
			a_spritebuffer.vertex_x4 = this.vertex_x4 / this.screen_w;
			a_spritebuffer.vertex_y4 = 1.0f - this.vertex_y4 / this.screen_h;
		}
	}
	#endif
}

