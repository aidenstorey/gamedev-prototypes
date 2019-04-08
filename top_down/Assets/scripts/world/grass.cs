using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( BoxCollider2D ) )]
public class grass : MonoBehaviour
{
    BoxCollider2D bc;

    Vector3 position;

    grass_top gt;

    Rigidbody2D player_rb;
    float effector = 0.0f;

	void Awake ()
    {
        this.bc = this.GetComponent<BoxCollider2D>();
        this.bc.isTrigger = true;

        this.gt = this.GetComponentInChildren<grass_top>();
    }
	
	void Update ()
    {
        if ( this.player_rb != null )
        {
            float max_distance = 0.2f;

            var position = this.gt.transform.position + (( Vector3 ) this.player_rb.velocity * 0.01f * this.effector);

            if ( ( position - this.gt.position ).magnitude <= max_distance )
            {
                this.gt.transform.position = position;
            }
        }
    }

    void OnTriggerEnter2D( Collider2D other )
    {
        this.player_rb = other.GetComponent<Rigidbody2D>();
    }

    void OnTriggerExit2D( Collider2D other )
    {
        this.player_rb = null;
    }

    void OnTriggerStay2D( Collider2D other )
    {
        float max_distance = 1.0f;
        float distance = ( this.transform.position - other.transform.position ).magnitude;

        this.effector = Mathf.Max( max_distance - distance, 0.0f );
    }
}
