using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "For Fox Sake/tile_behaviour/slide")]
public class tile_slide : tile_behaviour {
    public override void on_enter(tile_object _tile)
    {
        _tile.player.travel_relative(_tile.player.transitioning_direction);
    }

    public override void on_exit(tile_object _tile)
    {

    }
}
