using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WindConrol : MonoBehaviour {

    private Slider xSlider;

    private Slider zSlider;

    private float x;

    private float z;
	void Start () {
        x = 8;
        z = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //keys maping
        if (Input.GetAxis("Slide X") < 0)
        {
            float newX = x - 1;
            if (newX >= -30)
            {
                setX(newX);
            }
        }
        if (Input.GetAxis("Slide X") > 0)
        {
            float newX = x + 1;
            if (newX <= 30)
            {
                setX(x + 1);
            }
        }
        if (Input.GetAxis("Slide Y") < 0)
        {
            float newZ = z - 1;
            if (newZ >= -30)
            {
                setZ(newZ);
            }
        }
        if (Input.GetAxis("Slide Y") > 0)
        {
            float newZ = z + 1;
            if (newZ <= 30)
            {
                setZ(newZ);
            }
        }

        transform.GetComponent<Cloth>().externalAcceleration = new Vector3(x, 0, z);

        GameObject temp = GameObject.Find("Slider X");
        if (temp != null)
        {
            xSlider = temp.GetComponent<Slider>();
            if (xSlider != null)
            {
                xSlider.value = x;
            }
        }
        temp = GameObject.Find("Slider Y");
        if (temp != null)
        {
            zSlider = temp.GetComponent<Slider>();
            if (zSlider != null)
            {
                zSlider.value = z;
            }
        }
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
