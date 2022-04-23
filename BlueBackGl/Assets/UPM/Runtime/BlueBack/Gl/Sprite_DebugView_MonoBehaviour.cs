

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＧＬ。
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

		/** spriteindex
		*/
		public SpriteIndex spriteindex;

		/** mode
		*/
		public Mode mode;

		/** visible
		*/
		public bool visible;

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
		public float texcord_x0;
		public float texcord_y0;
		public float texcord_x1;
		public float texcord_y1;
		public float texcord_x2;
		public float texcord_y2;
		public float texcord_x3;
		public float texcord_y3;

		/** vertex
		*/
		public float vertex_x0;
		public float vertex_y0;
		public float vertex_x1;
		public float vertex_y1;
		public float vertex_x2;
		public float vertex_y2;
		public float vertex_x3;
		public float vertex_y3;

		/** virtual
		*/
		public float virtual_x0;
		public float virtual_y0;
		public float virtual_x1;
		public float virtual_y1;
		public float virtual_x2;
		public float virtual_y2;
		public float virtual_x3;
		public float virtual_y3;

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

		/** Read
		*/
		private void Read(ref SpriteBuffer a_spritebuffer)
		{
			this.visible = a_spritebuffer.visible;
			this.material_index = a_spritebuffer.material_index;
			this.texture_index = a_spritebuffer.texture_index;
			this.color = a_spritebuffer.color;

			#if(ASMDEF_UNITY_MATHEMATICS)
			{
				this.texcord_x0 = a_spritebuffer.texcord.c0.x;
				this.texcord_y0 = a_spritebuffer.texcord.c0.y;
				this.texcord_x1 = a_spritebuffer.texcord.c1.x;
				this.texcord_y1 = a_spritebuffer.texcord.c1.y;
				this.texcord_x2 = a_spritebuffer.texcord.c2.x;
				this.texcord_y2 = a_spritebuffer.texcord.c2.y;
				this.texcord_x3 = a_spritebuffer.texcord.c3.x;
				this.texcord_y3 = a_spritebuffer.texcord.c3.y;
				this.vertex_x0 = a_spritebuffer.vertex.c0.x;
				this.vertex_y0 = a_spritebuffer.vertex.c0.y;
				this.vertex_x1 = a_spritebuffer.vertex.c1.x;
				this.vertex_y1 = a_spritebuffer.vertex.c1.y;
				this.vertex_x2 = a_spritebuffer.vertex.c2.x;
				this.vertex_y2 = a_spritebuffer.vertex.c2.y;
				this.vertex_x3 = a_spritebuffer.vertex.c3.x;
				this.vertex_y3 = a_spritebuffer.vertex.c3.y;
			}
			#endif

			#if(ASMDEF_UNITY_MATHEMATICS)
			{
				ref ScreenParam t_screenparam = ref this.spriteindex.spritelist.gl.screenparam;
				this.virtual_x0 = (a_spritebuffer.vertex.c0.x - t_screenparam.calc_xy.x) / t_screenparam.calc_wh.x;
				this.virtual_y0 = (a_spritebuffer.vertex.c0.y - t_screenparam.calc_xy.y) / t_screenparam.calc_wh.y;
				this.virtual_x1 = (a_spritebuffer.vertex.c1.x - t_screenparam.calc_xy.x) / t_screenparam.calc_wh.x;
				this.virtual_y1 = (a_spritebuffer.vertex.c1.y - t_screenparam.calc_xy.y) / t_screenparam.calc_wh.y;
				this.virtual_x2 = (a_spritebuffer.vertex.c2.x - t_screenparam.calc_xy.x) / t_screenparam.calc_wh.x;
				this.virtual_y2 = (a_spritebuffer.vertex.c2.y - t_screenparam.calc_xy.y) / t_screenparam.calc_wh.y;
				this.virtual_x3 = (a_spritebuffer.vertex.c3.x - t_screenparam.calc_xy.x) / t_screenparam.calc_wh.x;
				this.virtual_y3 = (a_spritebuffer.vertex.c3.y - t_screenparam.calc_xy.y) / t_screenparam.calc_wh.y;
			}
			#endif
		}

		/** Write
		*/
		private void Write(ref SpriteBuffer a_spritebuffer)
		{
			a_spritebuffer.visible = this.visible;
			a_spritebuffer.material_index = this.material_index;
			a_spritebuffer.texture_index = this.texture_index;
			a_spritebuffer.color = this.color;

			#if(ASMDEF_UNITY_MATHEMATICS)
			{
				a_spritebuffer.texcord.c0.x = this.texcord_x0;
				a_spritebuffer.texcord.c0.y = this.texcord_y0;
				a_spritebuffer.texcord.c1.x = this.texcord_x1;
				a_spritebuffer.texcord.c1.y = this.texcord_y1;
				a_spritebuffer.texcord.c2.x = this.texcord_x2;
				a_spritebuffer.texcord.c2.y = this.texcord_y2;
				a_spritebuffer.texcord.c3.x = this.texcord_x3;
				a_spritebuffer.texcord.c3.y = this.texcord_y3;
				a_spritebuffer.vertex.c0.x = this.vertex_x0;
				a_spritebuffer.vertex.c0.y = this.vertex_y0;
				a_spritebuffer.vertex.c1.x = this.vertex_x1;
				a_spritebuffer.vertex.c1.y = this.vertex_y1;
				a_spritebuffer.vertex.c2.x = this.vertex_x2;
				a_spritebuffer.vertex.c2.y = this.vertex_y2;
				a_spritebuffer.vertex.c3.x = this.vertex_x3;
				a_spritebuffer.vertex.c3.y = this.vertex_y3;
			}
			#endif

			#if(ASMDEF_UNITY_MATHEMATICS)
			{
				ref ScreenParam t_screenparam = ref this.spriteindex.spritelist.gl.screenparam;
				this.virtual_x0 = (a_spritebuffer.vertex.c0.x - t_screenparam.calc_xy.x) / t_screenparam.calc_wh.x;
				this.virtual_y0 = (a_spritebuffer.vertex.c0.y - t_screenparam.calc_xy.y) / t_screenparam.calc_wh.y;
				this.virtual_x1 = (a_spritebuffer.vertex.c1.x - t_screenparam.calc_xy.x) / t_screenparam.calc_wh.x;
				this.virtual_y1 = (a_spritebuffer.vertex.c1.y - t_screenparam.calc_xy.y) / t_screenparam.calc_wh.y;
				this.virtual_x2 = (a_spritebuffer.vertex.c2.x - t_screenparam.calc_xy.x) / t_screenparam.calc_wh.x;
				this.virtual_y2 = (a_spritebuffer.vertex.c2.y - t_screenparam.calc_xy.y) / t_screenparam.calc_wh.y;
				this.virtual_x3 = (a_spritebuffer.vertex.c3.x - t_screenparam.calc_xy.x) / t_screenparam.calc_wh.x;
				this.virtual_y3 = (a_spritebuffer.vertex.c3.y - t_screenparam.calc_xy.y) / t_screenparam.calc_wh.y;
			}
			#endif
		}
	}
	#endif
}

