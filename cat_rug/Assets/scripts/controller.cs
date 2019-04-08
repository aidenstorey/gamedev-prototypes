using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public GameObject node_prefab;
    public int size;

    node[, ] nodes;

    public float distance = 0.5f;

	void Start ()
    {
        this.nodes = new node[ this.size, this.size ];

        float hs = ( this.distance * (this.size - 1) ) / 2.0f;

        float cd = 1.0f / (float)this.size;

        for ( int x = 0; x < this.size; x++ )
        {
            for ( int y = 0; y < this.size; y++ )
            {
                var go = Instantiate( this.node_prefab, this.transform ) as GameObject;
                go.name = "node{" + x + ", " + y + "}";
                go.transform.localScale = new Vector3( 0.2f, 0.2f, 0.2f );

                this.nodes[ x, y ] = go.GetComponent<node>();
                this.nodes[ x, y ].initialise( new Vector3( x * this.distance - hs, y * this.distance - hs ));
            }
        }
    }

    Dictionary<KeyCode, Vector3> movement_direction = new Dictionary<KeyCode, Vector3>()
    {
        { KeyCode.UpArrow, new Vector3( 0.0f, -1.0f ) },
        { KeyCode.DownArrow, new Vector3( 0.0f, 1.0f ) },
        { KeyCode.LeftArrow, new Vector3( 1.0f, 0.0f ) },
        { KeyCode.RightArrow, new Vector3(-1.0f, 0.0f ) },
    };

    void Update()
    {
        var dir = Vector3.zero;

        foreach ( KeyValuePair<KeyCode, Vector3> md in movement_direction )
        {
            if ( Input.GetKey( md.Key ) )
            {
                dir += md.Value;
            }
        }

        dir = dir.normalized * Time.deltaTime;

        var c = Vector3.zero;
        
        var r = 3.0f;

        var pi = Mathf.PI;
        var hpi = pi / 2.0f;

        for ( int x = 0; x < this.size; x++ )
        {
            for ( int y = 0; y < this.size; y++ )
            {
                var p = this.nodes[ x, y ].position_initial;
                p.z = 0.0f;
                
                var d = p - c;
                var m = d.magnitude;

                var rx = 90.0f / r * d.x;
                var ry = 90.0f / r * d.y;

                //this.nodes[ x, y ].rotation = new Vector3( ry, -rx );

                if ( m < r )
                {
                    var h = ( hpi / r ) * m;
                    p.z = -Mathf.Sin( hpi + h ) * 2.5f;

                    if ( m >= 0.9 * r )
                    {
                        var np =  c + (d / d.magnitude * ( d.magnitude * 0.95f ));
                        p.x = np.x;
                        p.y = np.y;
                    }
                }
                else
                {
                    p.z = 0.0f;
                }

                this.nodes[ x, y ].show = m <= r;

                this.nodes[ x, y ].position = p + dir;
                this.nodes[ x, y ].position_initial += dir;
            }
        }

    }
}
