using UnityEngine;
using System.Collections;

public class level_maker_object : MonoBehaviour
{
	SpriteRenderer sr_foreground;
	SpriteRenderer sr_background;

	public tile_description tile;

	void Awake()
	{
		{
			GameObject go = new GameObject("sprite_foreground");
			this.sr_foreground = go.AddComponent<SpriteRenderer>();
			this.sr_foreground.sortingLayerName = "level_maker_foreground";

			go.transform.parent = this.transform;
		}
		{
			GameObject go = new GameObject("sprite_background");
			this.sr_background = go.AddComponent<SpriteRenderer>();
			this.sr_background.sortingLayerName = "level_maker_background";
			this.sr_background.sprite = sprite_manager.instance.level_maker_background;

			go.transform.parent = this.transform;
		}
	}

	public void select()
	{
		this.sr_foreground.sprite = sprite_manager.instance.level_maker_error;
	}

	public void unselect()
	{
		this.sr_foreground.sprite = null;
	}
}
