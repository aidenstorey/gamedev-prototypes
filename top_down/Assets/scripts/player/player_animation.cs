using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Animator ) )]
[RequireComponent( typeof( SpriteRenderer ) )]
public class player_animation : MonoBehaviour
{
    public enum state
    {
        idle,
    }

    Animator a;
    SpriteRenderer sr;

    public state default_state;

	void Awake ()
    {
        this.a = this.GetComponent<Animator>();
        this.sr = this.GetComponent<SpriteRenderer>();

        this.a.Play( default_state.ToString() );
	}
}
