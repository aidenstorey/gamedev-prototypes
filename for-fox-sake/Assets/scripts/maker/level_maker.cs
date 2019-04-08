using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class level_maker : MonoBehaviour {

	public List<List<level_maker_object>> map;

	const int map_width_min = 1;
	const int map_width_max = 100;
	const int map_width_default = 10;
	
	const int map_height_min = 1;
	const int map_height_max = 100;
	const int map_height_default = 10;

	[Range( level_maker.map_width_min, level_maker.map_width_max )]
	public int map_width = level_maker.map_width_default;

	[Range( level_maker.map_height_min, level_maker.map_width_max )]
	public int map_height = level_maker.map_height_default;

	public float tile_size = 1.28f;

	float half_tile_size;
	float half_map_width;
	float half_map_height;

	level_maker_action_manager lmam;
	level_maker_selection_manager lmsm;

	GameObject go_map;

	void Start ()
	{
		// TODO:	Discover all tile objects
		this.map_width = level_maker.map_width_min <= this.map_width && this.map_width <= level_maker.map_width_max ? this.map_width : level_maker.map_width_default;
		this.map_height = level_maker.map_height_min <= this.map_height && this.map_height <= level_maker.map_height_max ? this.map_height : level_maker.map_height_default;

		this.initialise_map( this.map_width, this.map_height );

		this.lmam = new level_maker_action_manager();
		this.lmam.lm = this;

		this.lmsm = new level_maker_selection_manager();
		this.lmsm.lm = this;
	}

	void Update()
	{
		this.lmam.handle_input();
		this.lmsm.handle_input();
	}

	public tile_position get_mouse_position_ts()
	{
		var mp = Camera.main.ScreenToWorldPoint( Input.mousePosition );

		return new tile_position(
			Mathf.RoundToInt( this.round_tile_space( mp.x + this.half_map_width - this.half_tile_size ) / this.tile_size ),
			Mathf.RoundToInt( this.round_tile_space( mp.y + this.half_map_height - this.half_tile_size ) / this.tile_size ) 
		);
    }


	float round_tile_space( float _value )
	{
		return this.tile_size * Mathf.Round( _value / this.tile_size );
	}

	bool initialise_map( int _width, int _height )
	{
		// Potentially clamp the incoming width and height instead of checking them
		// int width = Mathf.Max( Mathf.Min( _width, level_maker.map_width_max ), level_maker.map_width_min );
		// int height = Mathf.Max( Mathf.Min( _height, level_maker.map_height_max ), level_maker.map_height_min );

		// Return early if the width and height aren't within constraints
		if ( level_maker.map_width_min > _width || _width > level_maker.map_width_max || level_maker.map_height_min > _height && _height > level_maker.map_height_max )
		{
			return false;
		}

		this.go_map = new GameObject("level_maker_map");

		// Find sizing of map.
		this.half_tile_size = this.tile_size / 2.0f;
		this.half_map_width = _width / 2.0f * this.tile_size;
		this.half_map_height = _height / 2.0f * this.tile_size;
		
		this.map = new List<List<level_maker_object>>();
		for ( int x = 0; x < _width; x++ )
		{
			this.map.Add( new List<level_maker_object>() );
			for ( int y = 0; y < _height; y++ )
			{

				this.map[ x ].Add( this.initialise_tile( x, y ) );
			}
		}

		this.map_width = _width;
		this.map_height = _height;

		return true;
	}

	public level_maker_object initialise_tile( int _x, int _y )
	{
		GameObject go = new GameObject( "level_maker_object" );
		var lmo = go.AddComponent<level_maker_object>();
		lmo.transform.parent = this.go_map.transform;
		lmo.transform.position = new Vector3(
			_x * this.tile_size - this.half_map_width + this.half_tile_size,
			_y * this.tile_size - this.half_map_height + this.half_tile_size
		);

		return lmo;
	}

	public void recalculate_tile_positions()
	{
		// Find sizing of map.
		this.half_tile_size = this.tile_size / 2.0f;
		this.half_map_width = this.map_width / 2.0f * this.tile_size;
		this.half_map_height = this.map_height / 2.0f * this.tile_size;

		for ( int x = 0; x < this.map_width; x++ )
		{
			for ( int y = 0; y < this.map_height; y++ )
			{
				this.map[ x ][ y ].transform.position = new Vector3(
					x * this.tile_size - this.half_map_width + this.half_tile_size,
					y * this.tile_size - this.half_map_height + this.half_tile_size
				);
			}
		}
	}
}
