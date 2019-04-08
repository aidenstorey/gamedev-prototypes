using UnityEngine;

public class tile_object : MonoBehaviour
{
	public tile_position position;
	public tile_description description;
    public player player;

	public void on_enter(player player)
	{
		this.player = player;
        this.description.on_enter( this );
    }

	public void on_exit()
    {
        this.description.on_exit( this );
        this.player = null;
    }

	public bool is_traversible()
	{
		return this.description.traversible;
	}
}
