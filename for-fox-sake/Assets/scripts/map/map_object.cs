using UnityEngine;
using System.Collections.Generic;

public class map_object : MonoBehaviour
{
	public List<List<tile_object>> tiles;
	public int map_width;
	public int map_height;

	public bool on_map_ts( int _x, int _y )
	{
		return
			0 <= _x && _x < this.map_width &&
			0 <= _y && _y < this.map_height;
	}

	public bool on_map_ts( tile_position position )
	{
		return this.on_map_ts( position.x, position.y );
	}

	public bool is_traversible_ts( int _x, int _y )
	{
		if ( !this.on_map_ts( _x, _y ) )
		{
			return false;
		}

		return this.tiles[ _x ][ _y ].description.traversible;
	}

	public bool is_traversible_ts( tile_position position )
	{
		return this.is_traversible_ts( position.x, position.y );
	}

	public Vector3 get_ms_position_ts( int _x, int _y )
	{
		return
			this.on_map_ts( _x, _y ) ?
			this.tiles[ _x ][ _y ].transform.position :
			new Vector3( 0.0f, 0.0f );
	}

	public Vector3 get_ms_position_ts( tile_position position )
	{
		return this.get_ms_position_ts( position.x, position.y );
	}

    public tile_object get_tile(int x, int y)
    {
        return this.tiles[x][y];
    }

    public tile_object get_tile(tile_position position)
    {
        return this.get_tile(position.x, position.y);
    }
}
