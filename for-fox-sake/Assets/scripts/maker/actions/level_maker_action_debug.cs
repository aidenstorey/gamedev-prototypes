using UnityEngine;
using System.Collections;

public class level_maker_action_debug : level_maker_action {

	public override void perform()
	{
		Debug.Log( "level_maker_action_debug::perform" );
	}

	public override void revert()
	{
		Debug.Log( "level_maker_action_debug::revert" );
	}
}
