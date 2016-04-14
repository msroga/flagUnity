using UnityEngine;
using System.Collections;

public class WindConrol : MonoBehaviour {

    private float x;

    private float z;
	void Start () {
        x = 8;
        z = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.GetComponent<Cloth>().externalAcceleration = new Vector3(x, 0, z);
    }

    public void setZ(float newZ)
    {
        z = newZ;
    }

    public void setX(float newX)
    {
        x = newX;
    }
}
