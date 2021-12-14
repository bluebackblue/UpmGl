

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** Sprite
	*/
	#if(UNITY_EDITOR)
	[System.Serializable]
	#endif
	public class Sprite
	{
		/** debugview
		*/
		#if(UNITY_EDITOR)
		public UnityEngine.GameObject debugview;
		#endif

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
		public float[] texcord;
			
		/** vertex
		*/
		public float[] vertex;

		/** constructor
		*/
		public Sprite()
		{
			//debugview
			#if(UNITY_EDITOR)
			this.debugview = null;
			#endif

			//visible
			this.visible = false;

			//material_index
			this.material_index = 0;

			//texture_index
			this.texture_index = 0;

			//color
			this.color = new UnityEngine.Color(0.0f,0.0f,0.0f,0.0f);
				
			//texcord
			this.texcord = new float[4]{0.0f,0.0f,0.0f,0.0f};

			//vertex
			this.vertex = new float[8]{0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f};
		}
	}
}

