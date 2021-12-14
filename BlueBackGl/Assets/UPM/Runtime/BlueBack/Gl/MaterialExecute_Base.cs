

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** MaterialExecute_Base
	*/
	public interface MaterialExecute_Base
	{
		/** [BlueBack.Gl.MaterialExecute_Base]PreSetPass

			return == false : パスをセットしない。

		*/
		bool PreSetPass(Sprite a_item);

		/** [BlueBack.Gl.MaterialExecute_Base]SetPass
		*/
		void SetPass();
	}
}

