using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( BoxCollider2D ) )]
public class player_collision : MonoBehaviour
{
    BoxCollider2D bc;

    void Awake()
    {
        this.bc = this.GetComponent<BoxCollider2D>();
    }
}
