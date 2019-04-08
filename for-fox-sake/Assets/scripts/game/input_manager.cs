using UnityEngine;
using System.Collections;

public class input_manager {
	static input_manager im = null;
	static input_interface ii = new input_keyboard();

	static public input_manager instance
	{
		get
		{
			if ( im == null )
			{
				im = new input_manager();
			}

			return im;
		}
	}

	static public input_interface input_interface
	{
		get { return ii; }
		set { ii = value; }
	}
}
