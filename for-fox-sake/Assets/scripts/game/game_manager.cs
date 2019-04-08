using UnityEngine;
using System.IO;

public class game_manager : MonoBehaviour {

	public map_description md;

	[System.NonSerialized]
	public player p;

	map_manager mm;

    void Start()
    {
        this.mm = this.GetComponent<map_manager>();
        this.mm.load_map_as_current_map(this.md);

        GameObject go = new GameObject("player");
        this.p = go.AddComponent<player>();
        this.p._map = this.mm.map_current;
    }
}
