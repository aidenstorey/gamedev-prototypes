using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu( menuName = "For Fox Sake/map_description")]
public class map_description : ScriptableObject
{
	public int map_width;
	public int map_height;
	public List<tile_description> tiles;
	public float tile_size;

	public virtual map_object to_object()
    {
        GameObject go = new GameObject("map");

		// Initialise map object
		map_object mo = go.AddComponent<map_object>();
		mo.map_width = this.map_width;
		mo.map_height = this.map_height;

		// Find sizing of map.
		float half_tile = this.tile_size / 2.0f;
		float half_width = map_width / 2.0f * this.tile_size;
		float half_height = map_height / 2.0f * this.tile_size;

		// Iterate over tiles in description, creating the corrosponding objects. 
		mo.tiles = new List<List<tile_object>>();
		for ( int x = 0; x < this.map_width; x++ )
		{
			mo.tiles.Add(new List<tile_object>());
			for ( int y = 0; y < this.map_height; y++ )
			{
				// Initialise tile object for position in map.
				tile_object to = this.tiles[ ( map_height * x ) + y ].to_object();
				to.position = new tile_position( x, y );

				// Set tile objects game object values.
				to.transform.parent = go.transform;
				to.transform.position = new Vector3(
					x * this.tile_size - half_width + half_tile,
					y * this.tile_size - half_height + half_tile
				);

				mo.tiles[ x ].Add( to );
			}
		}

		return mo;
    }
}
