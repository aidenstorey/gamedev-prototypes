using UnityEngine;

public class node : MonoBehaviour
{
    MeshRenderer[] cmr;

    public Vector3 position_initial;

    void Awake()
    {
        this.cmr = this.GetComponentsInChildren<MeshRenderer>();
    }

    public void initialise( Vector3 position)
    {
        this.position = position;
        this.position_initial = position;
    }

    public Vector3 position
    {
        get { return this.transform.position; }
        set { this.transform.position = value; }
    }

    public Vector3 rotation
    {
        set
        {
            this.transform.localRotation = Quaternion.Euler( value );
        }
    }

    public bool show
    {
        set
        {
            foreach ( var mr in this.cmr )
            {
                mr.enabled = value;
            }
        }
    }
}
