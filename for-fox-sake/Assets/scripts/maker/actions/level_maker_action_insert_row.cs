using UnityEngine;
using System.Collections.Generic;

public class level_maker_action_insert_row : level_maker_action
{
	level_maker lm;
	int y;

	public override void perform()
	{
		for ( int x = 0; x < this.lm.map_width; x++ )
		{
			this.lm.map[ x ].Insert( y, this.lm.initialise_tile( x, this.y ) );
		}
		this.lm.map_height++;

		this.lm.recalculate_tile_positions();
	}

	public override void revert()
	{
		for ( int y = 0; y < this.lm.map_height; y++ )
		{
		}
		for ( int x = 0; x < this.lm.map_width; x++ )
		{
			GameObject.DestroyImmediate( this.lm.map[ x ][ this.y ].gameObject );
			this.lm.map[ x ].RemoveAt( y );
		}
		this.lm.map_height--;

		this.lm.recalculate_tile_positions();
	}

	public static level_maker_action_insert_row create( level_maker lm, int y )
	{
		var lma = new level_maker_action_insert_row();
		lma.lm = lm;
		lma.y = y;

		return lma;
	}
}
