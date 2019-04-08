using UnityEngine;
using System.Collections.Generic;

public class tile_position : System.Object
{
	public int x;
	public int y;

    static Dictionary<direction, tile_position> tile_offset = new Dictionary<direction, tile_position>()
    {
        { direction.up, new tile_position(0, 1) },
        { direction.down, new tile_position(0, -1) },
        { direction.left, new tile_position(-1, 0) },
        { direction.right, new tile_position(1, 0) },
        { direction.none, new tile_position(0, 0) },
    };

    public tile_position( int _x, int _y )
	{
		this.x = _x;
		this.y = _y;
	}

	public static tile_position operator +( tile_position a, tile_position b )
	{
		return new tile_position( a.x + b.x, a.y + b.y );
	}

	public static tile_position operator -( tile_position a, tile_position b )
	{
		return new tile_position( a.x - b.x, a.y - b.y );
	}

	public static tile_position operator *( tile_position a, int val )
	{
		return new tile_position( a.x * val, a.y * val );
	}

	public static tile_position operator /( tile_position a, int val )
	{
		return new tile_position( a.x / val, a.y / val );
	}

	public static bool operator ==( tile_position a, tile_position b )
	{
		if ( System.Object.ReferenceEquals( a, b ) )
		{
			return true;
		}
		
		if ( ( ( object )a == null ) || ( ( object )b == null ) )
		{
			return false;
		}

		return a.x == b.x && a.y == b.y;
	}

	public static bool operator !=( tile_position a, tile_position b )
	{
		return !( a == b );
	}

	public override bool Equals( System.Object obj )
	{
		if ( obj == null )
		{
			return false;
		}
		
		tile_position a = obj as tile_position;
		if ( ( System.Object )a == null )
		{
			return false;
		}
		
		return ( this.x == a.x ) && ( this.y == a.y );
	}

	public bool Equals( tile_position a )
	{
		if ( ( object )a == null )
		{
			return false;
		}
		
		return ( this.x == a.x ) && ( this.y == a.y );
	}

	public override int GetHashCode()
	{
		return x ^ y;
	}

    public override string ToString()
    {
        return "tile_space(x: " + this.x + ", y: " + this.y + ")";
    }

    public static tile_position offset_left()
    {
        return tile_position.tile_offset[direction.left];
    }

    public static tile_position offset_right()
    {
        return tile_position.tile_offset[direction.right];
    }

    public static tile_position offset_up()
    {
        return tile_position.tile_offset[direction.up];
    }

    public static tile_position offset_down()
    {
        return tile_position.tile_offset[direction.down];
    }

    public static tile_position offset(direction _direction)
    {
        return tile_position.tile_offset[_direction];
    }
}
