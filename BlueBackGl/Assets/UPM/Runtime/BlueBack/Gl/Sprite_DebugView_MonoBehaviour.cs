

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

		/** screenparam
		*/
		public static ScreenParam s_screenparam;

		/** screen
		*/
		public int screen_virtual_w_pix;
		public int screen_virtual_h_pix;
		public float screen_x;
		public float screen_y;
		public float screen_scale_w;
		public float screen_scale_h;


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
		public float texcord_1_x1;
		public float texcord_1_y2;
		public float texcord_2_x2;
		public float texcord_2_y2;
		public float texcord_3_x2;
		public float texcord_3_y1;
		public float texcord_4_x1;
		public float texcord_4_y1;

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

		/** SetScreenParam
		*/
		public static void SetScreenParam(in ScreenParam a_screenparam)
		{
			s_screenparam = a_screenparam;
		}

		/** Read
		*/
		private void Read(ref SpriteBuffer a_spritebuffer)
		{
			this.screen_virtual_w_pix = (int)(1.0f / s_screenparam.virtual_w_pix_inv);
			this.screen_virtual_h_pix = (int)(1.0f / s_screenparam.virtual_h_pix_inv);
			this.screen_x = s_screenparam.offset_x;
			this.screen_y = s_screenparam.offset_y;
			this.screen_scale_w = s_screenparam.scale_w;
			this.screen_scale_h = s_screenparam.scale_h;

			this.visible = a_spritebuffer.visible;
			this.material_index = a_spritebuffer.material_index;
			this.texture_index = a_spritebuffer.texture_index;
			this.color = a_spritebuffer.color;
			this.texcord_1_x1 = a_spritebuffer.texcord_1_x1;
			this.texcord_1_y2 = a_spritebuffer.texcord_1_y2;
			this.texcord_2_x2 = a_spritebuffer.texcord_2_x2;
			this.texcord_2_y2 = a_spritebuffer.texcord_2_y2;
			this.texcord_3_x2 = a_spritebuffer.texcord_3_x2;
			this.texcord_3_y1 = a_spritebuffer.texcord_3_y1;
			this.texcord_4_x1 = a_spritebuffer.texcord_4_x1;
			this.texcord_4_y1 = a_spritebuffer.texcord_4_y1;
			this.vertex_x1 = (a_spritebuffer.vertex_x1 - s_screenparam.offset_x) / s_screenparam.scale_w / s_screenparam.virtual_w_pix_inv;
			this.vertex_x2 = (a_spritebuffer.vertex_x2 - s_screenparam.offset_x) / s_screenparam.scale_w / s_screenparam.virtual_w_pix_inv;
			this.vertex_x3 = (a_spritebuffer.vertex_x3 - s_screenparam.offset_x) / s_screenparam.scale_w / s_screenparam.virtual_w_pix_inv;
			this.vertex_x4 = (a_spritebuffer.vertex_x4 - s_screenparam.offset_x) / s_screenparam.scale_w / s_screenparam.virtual_w_pix_inv;
			this.vertex_y1 = (1.0f - (a_spritebuffer.vertex_y1 - s_screenparam.offset_y) / s_screenparam.scale_h) / s_screenparam.virtual_h_pix_inv;
			this.vertex_y2 = (1.0f - (a_spritebuffer.vertex_y2 - s_screenparam.offset_y) / s_screenparam.scale_h) / s_screenparam.virtual_h_pix_inv;
			this.vertex_y3 = (1.0f - (a_spritebuffer.vertex_y3 - s_screenparam.offset_y) / s_screenparam.scale_h) / s_screenparam.virtual_h_pix_inv;
			this.vertex_y4 = (1.0f - (a_spritebuffer.vertex_y4 - s_screenparam.offset_y) / s_screenparam.scale_h) / s_screenparam.virtual_h_pix_inv;
		}

		/** Write
		*/
		private void Write(ref SpriteBuffer a_spritebuffer)
		{
			a_spritebuffer.visible = this.visible;
			a_spritebuffer.material_index = this.material_index;
			a_spritebuffer.texture_index = this.texture_index;
			a_spritebuffer.color = this.color;
			a_spritebuffer.texcord_1_x1 = this.texcord_1_x1;
			a_spritebuffer.texcord_1_y2 = this.texcord_1_y2;
			a_spritebuffer.texcord_2_x2 = this.texcord_2_x2;
			a_spritebuffer.texcord_2_y2 = this.texcord_2_y2;
			a_spritebuffer.texcord_3_x2 = this.texcord_3_x2;
			a_spritebuffer.texcord_3_y1 = this.texcord_3_y1;
			a_spritebuffer.texcord_4_x1 = this.texcord_4_x1;
			a_spritebuffer.texcord_4_y1 = this.texcord_4_y1;
			a_spritebuffer.vertex_x1 = s_screenparam.offset_x + (this.vertex_x1 * s_screenparam.virtual_w_pix_inv) * s_screenparam.scale_w;
			a_spritebuffer.vertex_x2 = s_screenparam.offset_x + (this.vertex_x2 * s_screenparam.virtual_w_pix_inv) * s_screenparam.scale_w;
			a_spritebuffer.vertex_x3 = s_screenparam.offset_x + (this.vertex_x3 * s_screenparam.virtual_w_pix_inv) * s_screenparam.scale_w;
			a_spritebuffer.vertex_x4 = s_screenparam.offset_x + (this.vertex_x4 * s_screenparam.virtual_w_pix_inv) * s_screenparam.scale_w;
			a_spritebuffer.vertex_y1 = s_screenparam.offset_y + (1.0f - this.vertex_y1 * s_screenparam.virtual_h_pix_inv) * s_screenparam.scale_h;
			a_spritebuffer.vertex_y2 = s_screenparam.offset_y + (1.0f - this.vertex_y2 * s_screenparam.virtual_h_pix_inv) * s_screenparam.scale_h;
			a_spritebuffer.vertex_y3 = s_screenparam.offset_y + (1.0f - this.vertex_y3 * s_screenparam.virtual_h_pix_inv) * s_screenparam.scale_h;
			a_spritebuffer.vertex_y4 = s_screenparam.offset_y + (1.0f - this.vertex_y4 * s_screenparam.virtual_h_pix_inv) * s_screenparam.scale_h;
		}
	}
	#endif
}

 