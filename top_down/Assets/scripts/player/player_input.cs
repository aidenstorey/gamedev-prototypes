using System.Collections.Generic;
using UnityEngine;

public class player_input : MonoBehaviour
{
    static player_input instance;

    current_queue<direction> vertical_queue;
    current_queue<direction> horizontal_queue;

    public static direction vertical
    {
        get { return player_input.instance.vertical_queue.current; }
    }

    public static direction horizontal
    {
        get { return player_input.instance.horizontal_queue.current; }
    }

    #region input_dictionaries
    static Dictionary<direction, KeyCode> vertical_input_codes = new Dictionary<direction, KeyCode>()
    {
        { direction.up, KeyCode.W },
        { direction.down, KeyCode.S },
    };

    static Dictionary<direction, KeyCode> horizontal_input_codes = new Dictionary<direction, KeyCode>()
    {
        { direction.left, KeyCode.A },
        { direction.right, KeyCode.D },
    };
    #endregion

    void Start()
    {
        if ( instance != null )
        {
            Destroy( this.gameObject );
            return;
        }

        instance = this;

        this.vertical_queue = new current_queue<direction>();
        this.horizontal_queue = new current_queue<direction>();
    }

    void Update()
    {
        foreach ( KeyValuePair<direction, KeyCode> kvp in vertical_input_codes )
        {
            if ( Input.GetKeyDown( kvp.Value ) )
            {
                this.vertical_queue.add( kvp.Key );
            }

            if ( Input.GetKeyUp( kvp.Value ) )
            {
                this.vertical_queue.remove( kvp.Key );
            }
        }

        foreach ( KeyValuePair<direction, KeyCode> kvp in horizontal_input_codes )
        {
            if ( Input.GetKeyDown( kvp.Value ) )
            {
                this.horizontal_queue.add( kvp.Key );
            }

            if ( Input.GetKeyUp( kvp.Value ) )
            {
                this.horizontal_queue.remove( kvp.Key );
            }
        }
    }
}
