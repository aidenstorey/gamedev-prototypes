using UnityEngine;
using System.Collections.Generic;

public class level_maker_action_manager
{
	public level_maker lm;

	List<level_maker_action> history = new List<level_maker_action>();
	List<level_maker_action> reverted = new List<level_maker_action>();

	public void handle_input()
	{
		if ( Input.GetKey( KeyCode.LeftControl ) )
		{
			if ( !Input.GetKey( KeyCode.LeftShift ) )
			{
				if ( Input.GetKeyDown( KeyCode.Z ) )
				{
					this.undo();
				}
			}
			else
			{
				if ( Input.GetKeyDown( KeyCode.Z ) )
				{
					this.redo();
				}
			}
		}
	}

	public void perform_action( level_maker_action _lma )
	{
		_lma.perform();
		this.history.Add( _lma );

		this.reverted.Clear();
	}

	public void undo()
	{
		if ( this.history.Count > 0 )
		{
			int last = this.history.Count - 1;

			var lma = this.history[ last ];
			this.history.RemoveAt( last );

			lma.revert();

			this.reverted.Add( lma );
		}
	}

	public void redo()
	{
		if ( this.reverted.Count > 0 )
		{
			int last = this.reverted.Count - 1;

			var lma = this.reverted[ last ];
			this.reverted.RemoveAt( last );

			lma.perform();

			this.history.Add( lma );
		}
	}
}
