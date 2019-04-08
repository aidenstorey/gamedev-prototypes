using UnityEngine;
using System.Collections.Generic;

public class level_maker_selection_manager
{
	public level_maker lm;

	tile_position selection_start_position;

	List<tile_position> selected = new List<tile_position>();

	public void handle_input()
	{
		if ( Input.GetMouseButtonDown( 0 ) )
		{
			this.selection_start_position = this.lm.get_mouse_position_ts();
		}
		else if ( Input.GetMouseButtonUp( 0 ) )
		{
			List<tile_position> altered = new List<tile_position>();

			var mp = this.lm.get_mouse_position_ts();

			if ( this.selection_start_position == mp )
			{
				altered.Add( this.selection_start_position );
			}
			else
			{
				var a = this.selection_start_position;
				var b = mp;

				int min_x = Mathf.Min( a.x, b.x );
				int max_x = Mathf.Max( a.x, b.x );

				int min_y = Mathf.Min( a.y, b.y );
				int max_y = Mathf.Max( a.y, b.y );

				for ( int x = min_x; x <= max_x; x++ )
				{
					for ( int y = min_y; y <= max_y; y++ )
					{
						if ( 0 <= x && x < this.lm.map_width && 0 <= y && y < this.lm.map_height )
						{
							altered.Add( new tile_position( x, y ) );
						}
					}
				}
			}

			if ( Input.GetKey( KeyCode.LeftShift ) )
			{
				this.add_selected( altered );
			}
			else if ( Input.GetKey( KeyCode.LeftAlt ) )
			{
				this.remove_selected( altered );
			}
			else
			{
				this.clear_selected();
				this.add_selected( altered );
			}
		}
	}

	void add_selected( List<tile_position> _tiles )
	{
		foreach ( var s in _tiles )
		{
			this.lm.map[ s.x ][ s.y ].select();
		}

		this.selected.AddRange( _tiles );
	}

	void remove_selected( List<tile_position> _tiles )
	{
		foreach ( var s in _tiles )
		{
			this.lm.map[ s.x ][ s.y ].unselect();
			this.selected.Remove( s );
		}
	}

	void clear_selected()
	{
		foreach ( var s in this.selected )
		{
			this.lm.map[ s.x ][ s.y ].unselect();
		}

		this.selected.Clear();
	}
}
