using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "For Fox Sake/tile_description")]
public class tile_description : ScriptableObject
{
	public List<Sprite> sprites_foreground;
	public List<Sprite> sprites_background;

	public bool traversible = true;
	
	public float transition_time = 0.1f;

	public tile_behaviour behaviour;

	public void on_enter( tile_object tile )
	{
		if ( this.behaviour )
		{
			this.behaviour.on_enter( tile );
		}
	}

	public void on_exit( tile_object tile )
	{
		if ( this.behaviour )
		{
			this.behaviour.on_exit( tile );
		}
	}

	public tile_object to_object()
	{
		GameObject go = new GameObject("tile");

		// Add tile_object script and initialize parameters.
		tile_object to = go.AddComponent<tile_object>();
		to.position = new tile_position( 0, 0 ); // This is just a temporary position, it is expected that it will be set in the calling scope.
		to.description = this;

		// Loop through all background images and add them as a new sprite renderer.
		for ( int i = 0; i < this.sprites_background.Count; i++ )
		{
            GameObject go_s = new GameObject("sprite_background");
            go_s.transform.parent = go.transform;

			SpriteRenderer sr = go_s.AddComponent<SpriteRenderer>();
			sr.sprite = this.sprites_background[ i ];
			sr.sortingLayerName = "tile_background";
			sr.sortingOrder = i;
		}

		// Loop through all foreground images and add them as a new sprite renderer.
		for ( int i = 0; i < this.sprites_foreground.Count; i++ )
        {
            GameObject go_s = new GameObject("sprite_foreground");
            go_s.transform.parent = go.transform;

            SpriteRenderer sr = go_s.AddComponent<SpriteRenderer>();
			sr.sprite = this.sprites_foreground[ i ];
			sr.sortingLayerName = "tile_foreground";
			sr.sortingOrder = i;
		}
		
		return to;
	}
}
