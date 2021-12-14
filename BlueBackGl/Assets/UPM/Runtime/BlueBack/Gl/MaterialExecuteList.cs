

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief ＧＬ。
*/


/** BlueBack.Gl
*/
namespace BlueBack.Gl
{
	/** MaterialExecuteList
	*/
	public sealed class MaterialExecuteList : System.IDisposable
	{
		/** list
		*/
		public MaterialExecute_Base[] list;

		/** constructor
		*/
		public MaterialExecuteList(in InitParam a_initparam)
		{
			this.list = new MaterialExecute_Base[a_initparam.material_max];
		}

		/** [IDisposable]Dispose。
		*/
		public void Dispose()
		{
		}
	}
}

