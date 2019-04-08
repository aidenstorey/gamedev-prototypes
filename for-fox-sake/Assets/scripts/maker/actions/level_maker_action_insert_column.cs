using UnityEngine;
using System.Collections.Generic;

public class level_maker_action_insert_column : level_maker_action
{
	level_maker lm;
	int x;

	public override void perform()
	{
		var row = new List<level_maker_object>();
		for ( int y = 0; y < this.lm.map_height; y++ )
		{
			row.Add( this.lm.initialise_tile( this.x, y ) );
		}

		this.lm.map.Insert( this.x, row );
		this.lm.map_width++;

		this.lm.recalculate_tile_positions();
	}

	public override void revert()
	{
		for ( int y = 0; y < this.lm.map_height; y++ )
		{
			GameObject.DestroyImmediate( this.lm.map[ this.x ][ y ].gameObject );
		}

		this.lm.map.RemoveAt( this.x );
		this.lm.map_width--;

		this.lm.recalculate_tile_positions();
	}

	public static level_maker_action_insert_column create( level_maker lm, int x )
	{
		var lma = new level_maker_action_insert_column();
		lma.lm = lm;
		lma.x = x;

		return lma;
	}
}
