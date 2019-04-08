using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Vector3 p;
    Vector3 o = new Vector3( 0.5f, 0.0f, 0.0f );

    float duration = 0.0f;
    float speed = 1.0f;

	void Start ()
    {
        this.p = this.transform.localPosition;
        this.duration = Random.Range( 0.0f, Mathf.PI * 0.3f);
        this.speed = Random.Range( Mathf.PI * 0.5f, Mathf.PI );
	}
	
	void Update ()
    {
        this.transform.localPosition = this.p + Quaternion.Euler( 0.0f, Mathf.Rad2Deg * duration, 0.0f ) * o;
        this.duration += Time.deltaTime * speed;
	}
}
