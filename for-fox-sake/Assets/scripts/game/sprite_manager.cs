using UnityEngine;
using System.Collections.Generic;

public class sprite_manager : MonoBehaviour {
    Dictionary<direction, Sprite> player;
	static private sprite_manager sm;
	
	public Sprite player_up;
	public Sprite player_down;
	public Sprite player_left;
	public Sprite player_right;
	
	public Sprite level_maker_background;
	public Sprite level_maker_error;
	public Sprite level_maker_okay;

	void Awake()
	{
		if ( sprite_manager.sm == null )
		{
			sprite_manager.sm = this;
		}
        player = new Dictionary<direction, Sprite>()
        {
            { direction.up, this.player_up },
            { direction.down, this.player_down },
            { direction.left, this.player_left },
            { direction.right, this.player_right },
            { direction.none, this.player_up },
        };
	}

    public Sprite player_direction (direction _direction)
    {
        return this.player[_direction];
    }

	static public sprite_manager instance
	{
		get
		{
			if ( sm == null )
			{
				sm = new sprite_manager();
			}

			return sm;
		}
	}
}
