using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sub_node : MonoBehaviour
{
    public MeshRenderer mr;

    float time_taken;

    public float wave_time = 0.0f;
    float wave_speed = 1.0f;

    void Awake ()
    {
        this.mr = this.GetComponent<MeshRenderer>();
        this.time_taken = Random.Range( 0, Mathf.PI );

        this.wave_time = Random.Range( 0.0f, Mathf.PI * 0.2f );
        //this.wave_speed = Random.Range( Mathf.PI * 0.5f, Mathf.PI * 0.6f );
    }
	
	void Update ()
    {
        this.time_taken += Time.deltaTime * 4.0f;
        this.transform.localPosition = new Vector3( 0.0f, 0.0f, Mathf.Sin( this.time_taken ) );

        this.wave_time += Time.deltaTime * this.wave_speed;
	}
}
