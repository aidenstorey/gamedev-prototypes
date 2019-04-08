using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
public class player_movement : MonoBehaviour
{
    public float speed = 5.0f;

    Rigidbody2D rb;

	void Awake ()
    {
        this.rb = this.GetComponent<Rigidbody2D>();

        this.rb.gravityScale = 0.0f;
	}
	
	void FixedUpdate()
    {
        this.rb.velocity = this.get_player_velocity();
	}

    #region velocity_dictionaries
    static Dictionary<direction, Vector2> velocities = new Dictionary<direction, Vector2>()
    {
        { direction.none, new Vector2( 0.0f, 0.0f ) },
        { direction.up, new Vector2( 0.0f, 1.0f ) },
        { direction.down, new Vector2( 0.0f, -1.0f ) },
        { direction.left, new Vector2( -1.0f, 0.0f ) },
        { direction.right, new Vector2( 1.0f, 0.0f ) },
    };

    static Vector2 get_velocity_direction(direction vertical, direction horizontal)
    {
        return ( player_movement.velocities[ horizontal ] + player_movement.velocities[ vertical ] ).normalized;
    }

    Vector2 get_player_velocity()
    {
        return get_velocity_direction(player_input.vertical, player_input.horizontal) * this.speed;
    }
    #endregion velocity_dictionaries
}
