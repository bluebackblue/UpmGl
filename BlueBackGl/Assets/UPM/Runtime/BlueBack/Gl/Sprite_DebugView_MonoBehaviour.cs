

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

		/** spritelist
		*/
		public SpriteList spritelist;

		/** Mode
		*/
		public enum Mode
		{
			Read,
			Write,
			None,
		}

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

		/** Texcord
		*/
		[System.Serializable]
		public struct Texcord
		{
			public float x1;
			public float y1;
			public float x2;
			public float y2;
		}

		/** Vertex
		*/
		[System.Serializable]
		public struct Vertex
		{
			public float x1;
			public float y1;
			public float x2;
			public float y2;
			public float x3;
			public float y3;
			public float x4;
			public float y4;
		}

		/** texcord
		*/
		public Texcord texcord;

		/** vertex
		*/
		public Vertex vertex;

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
				switch(this.mode){
				case Mode.Read:
					{
						this.visible = this.spritelist.buffer[this.spriteindex.index].visible;
						this.material_index = this.spritelist.buffer[this.spriteindex.index].material_index;
						this.texture_index = this.spritelist.buffer[this.spriteindex.index].texture_index;
						this.color = this.spritelist.buffer[this.spriteindex.index].color;
						this.texcord.x1 = this.spritelist.buffer[this.spriteindex.index].texcord_0;
						this.texcord.y1 = this.spritelist.buffer[this.spriteindex.index].texcord_1;
						this.texcord.x2 = this.spritelist.buffer[this.spriteindex.index].texcord_2;
						this.texcord.y2 = this.spritelist.buffer[this.spriteindex.index].texcord_3;
						this.vertex.x1 = this.spritelist.buffer[this.spriteindex.index].vertex_0 * this.spritelist.width;
						this.vertex.y1 = this.spritelist.height - this.spritelist.buffer[this.spriteindex.index].vertex_1 * this.spritelist.height;
						this.vertex.x2 = this.spritelist.buffer[this.spriteindex.index].vertex_2 * this.spritelist.width;
						this.vertex.y2 = this.spritelist.height - this.spritelist.buffer[this.spriteindex.index].vertex_3 * this.spritelist.height;
						this.vertex.x3 = this.spritelist.buffer[this.spriteindex.index].vertex_4 * this.spritelist.width;
						this.vertex.y3 = this.spritelist.height - this.spritelist.buffer[this.spriteindex.index].vertex_5 * this.spritelist.height;
						this.vertex.x4 = this.spritelist.buffer[this.spriteindex.index].vertex_6 * this.spritelist.width;
						this.vertex.y4 = this.spritelist.height - this.spritelist.buffer[this.spriteindex.index].vertex_7 * this.spritelist.height;

					}break;
				case Mode.Write:
					{
						this.spritelist.buffer[this.spriteindex.index].visible = this.visible;
						this.spritelist.buffer[this.spriteindex.index].material_index = this.material_index;
						this.spritelist.buffer[this.spriteindex.index].texture_index = this.texture_index;
						this.spritelist.buffer[this.spriteindex.index].color = this.color;
						this.spritelist.buffer[this.spriteindex.index].texcord_0 = this.texcord.x1;
						this.spritelist.buffer[this.spriteindex.index].texcord_1 = this.texcord.y1;
						this.spritelist.buffer[this.spriteindex.index].texcord_2 = this.texcord.x2;
						this.spritelist.buffer[this.spriteindex.index].texcord_3 = this.texcord.y2;
						this.spritelist.buffer[this.spriteindex.index].vertex_0 = this.vertex.x1 / this.spritelist.width;
						this.spritelist.buffer[this.spriteindex.index].vertex_1 = 1.0f - this.vertex.y1 / this.spritelist.height;
						this.spritelist.buffer[this.spriteindex.index].vertex_2 = this.vertex.x2 / this.spritelist.width;
						this.spritelist.buffer[this.spriteindex.index].vertex_3 = 1.0f - this.vertex.y2 / this.spritelist.height;
						this.spritelist.buffer[this.spriteindex.index].vertex_4 = this.vertex.x3 / this.spritelist.width;
						this.spritelist.buffer[this.spriteindex.index].vertex_5 = 1.0f - this.vertex.y3 / this.spritelist.height;
						this.spritelist.buffer[this.spriteindex.index].vertex_6 = this.vertex.x4 / this.spritelist.width;
						this.spritelist.buffer[this.spriteindex.index].vertex_7 = 1.0f - this.vertex.y4 / this.spritelist.height;
					}break;
				}
			}else{
				this.mode = Mode.Read;
			}
			#endif
		}
	}
	#endif
}

