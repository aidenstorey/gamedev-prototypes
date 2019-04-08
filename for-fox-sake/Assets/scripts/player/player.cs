using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum direction { none, up, down, left, right }

public class player : MonoBehaviour
{
	public Text debug_text;

	private direction input_direction = direction.none;
	List<direction> travelling_queue = new List<direction>();

	bool transitioning = false;
	public direction transitioning_direction = direction.none;

	float transition_time_in = 0.0f;
	float transition_time_out = 0.0f;
	float transition_time_total = 0.0f;

	float transition_time_current;

	Vector3 transition_position_start = Vector3.zero;
	Vector3 transition_position_halfway = Vector3.zero;
	Vector3 transition_delta_half = Vector3.zero;
	
	public map_object _map;

	tile_position _position = new tile_position( 0, 0 );
    tile_object current_tile;

	SpriteRenderer _sr;

	// Use this for initialization
	void Start()
	{
		this.hard_set_position( this._position );

		this._sr = this.gameObject.AddComponent<SpriteRenderer>();
		this._sr.sprite = sprite_manager.instance.player_direction(direction.none);
		this._sr.sortingLayerName = "player";
	}

	// Update is called once per frame
	void Update()
	{
		this.handle_input();
		if ( !this.handle_transition() )
		{
			this.handle_travel();
		}
	}

	void hard_set_position( tile_position _position )
	{
		this._position = _position;

		var position = this._map.get_ms_position_ts( _position );
		this.transform.position = position;
		this.transition_position_start = position;
		this.transition_position_halfway = position;
        this.transitioning_direction = direction.none;

		this.transition_time_current = 0.0f;
        this.current_tile = this._map.get_tile(this._position);
	}
	
	void _handle_pressed( bool _pressed, direction _direction )
	{
		if ( _pressed )
		{
			if ( this.input_direction == direction.none )
			{
				this.input_direction = _direction;
			}
			else
			{
				this.travelling_queue.Add( _direction );
			}
		}
	}

	void _handle_released( bool _released, direction _direction )
	{
		if ( _released )
		{
			if ( this.input_direction == _direction )
			{
				if ( this.travelling_queue.Count > 0 )
				{
					this.input_direction = this.travelling_queue[ 0 ];
					this.travelling_queue.RemoveAt( 0 );
				}
				else
				{
					this.input_direction = direction.none;
				}
			}
			else
			{
				this.travelling_queue.Remove( _direction );
			}
		}
	}

	void handle_input()
	{
		this._handle_pressed( input_manager.input_interface.up_pressed(), direction.up );
		this._handle_pressed( input_manager.input_interface.down_pressed(), direction.down );
		this._handle_pressed( input_manager.input_interface.left_pressed(), direction.left );
		this._handle_pressed( input_manager.input_interface.right_pressed(), direction.right );
		this._handle_released( input_manager.input_interface.up_released(), direction.up );
		this._handle_released( input_manager.input_interface.down_released(), direction.down );
		this._handle_released( input_manager.input_interface.left_released(), direction.left );
		this._handle_released( input_manager.input_interface.right_released(), direction.right );
	}

	bool handle_transition()
	{
		if ( this.transitioning_direction != direction.none )
        {
			this.transition_time_current = Mathf.Min( this.transition_time_current + Time.deltaTime, this.transition_time_total );
			if ( this.transition_time_current < this.transition_time_out )
			{
				var delta = ( this.transition_delta_half / this.transition_time_out ) * this.transition_time_current;
				this.transform.position = this.transition_position_start + delta;
			}
			else if ( this.transition_time_current < this.transition_time_total )
			{
				var delta = ( this.transition_delta_half / this.transition_time_in ) * ( this.transition_time_current - this.transition_time_out );
				this.transform.position = this.transition_position_halfway + delta;
			}
			else
			{
				this.transform.position = this.transition_position_start + this.transition_delta_half * 2.0f;

				this.transitioning = false;

				this.current_tile.on_enter( this );

				if ( !this.transitioning )
				{
					this.transitioning_direction = direction.none;
				}
			}

			return true;
		}

        return false;
	}

	void handle_travel()
	{
		this.travel_relative( this.input_direction );
    }
	

    public void travel_relative(direction _direction) 
    {
		if ( _direction != direction.none )
		{
			tile_position position = this._position + tile_position.offset( _direction );

			if ( this._map.is_traversible_ts( position ) )
			{
				this._position = position;

				// Update the current tile and ensure clean up of previous by grabbing the out time and calling on_exit.
				this.transition_time_out = this.current_tile.description.transition_time;
				this.current_tile.on_exit();
				this.current_tile = this._map.get_tile( this._position );

				// Store the value for time in and calculate the time out value.
				this.transition_time_in = this.current_tile.description.transition_time;
				this.transition_time_total = this.transition_time_in + this.transition_time_out;

				// Update the sprite renderer to have the sprite of the current facing direction
				this._sr.sprite = sprite_manager.instance.player_direction( _direction );

				// Set transitioning to true and ensure timer is zero'd.
				this.transitioning = true;
				this.transitioning_direction = _direction;
				this.transition_time_current = 0.0f;

				// Calculate the delta between positions, storing half delta.
				var delta = this._map.get_ms_position_ts( this._position ) - this.transform.position;
				this.transition_delta_half = delta / 2.0f;

				// Store the start position and the halfway position for transition effect.
				this.transition_position_start = this.transform.position;
				this.transition_position_halfway = this.transition_position_start + this.transition_delta_half;
			}
		}
    }
}
