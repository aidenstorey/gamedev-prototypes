using UnityEngine;

public class grass_top : MonoBehaviour
{
    public Vector3 position;

    void Awake()
    {
        this.position = this.transform.position;
    }

    void Update()
    {
        if ( this.position != this.transform.position )
        {
            var delta = this.position - this.transform.position;
            this.transform.position += delta * Time.deltaTime * 3.0f;
        }
    }
}
