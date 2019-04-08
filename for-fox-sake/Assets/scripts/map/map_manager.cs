using UnityEngine;
using System.Collections;

public class map_manager : MonoBehaviour
{
	public map_object map_current;
	
	public void load_map_as_current_map( map_description description )
	{
		if ( this.map_current )
		{
			this.unload_current_map();
		}
		
		this.map_current = description.to_object();
	}

	public void unload_current_map()
	{
		DestroyImmediate( this.map_current );
	}
}
