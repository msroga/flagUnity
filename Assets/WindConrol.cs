using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class WindConrol : MonoBehaviour {

    private AudioSource m_AudioSource;

    private Slider xSlider;

    private Slider zSlider;

    private float x;

    private float z;

    private double oldWindPower;

    private static float HIGH_LEVEL = 30.0f;
    private static float MID_LEVEL = 15.0f;
    private static float LOW_LEVEL = 3.0f;

    //  [SerializeField]    private AudioClip lowSound;           // the sound played on low wind
    //  [SerializeField]    private AudioClip midSound;
    //  [SerializeField]    private AudioClip highSound;
    void Start () {
        x = 8;
        z = 0;
        oldWindPower = System.Math.Sqrt((x * x) + (z * z));
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.loop = true;
        m_AudioSource.pitch = 0.40f;
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

        double windPower = System.Math.Sqrt((x * x) + (z * z));
        
        if (changeSound(windPower))
        {
            m_AudioSource.Stop();
            if (windPower > LOW_LEVEL)
            {        
                if (windPower > HIGH_LEVEL)
                {
                    m_AudioSource.pitch = 1.5f;
                }
                else if (windPower > MID_LEVEL)
                {
                    m_AudioSource.pitch = 0.80f;
                }
                else
                {
                    m_AudioSource.pitch = 0.40f;
                }
            }
            else
            {
                m_AudioSource.pitch = 0;
            }
            m_AudioSource.Play();
            oldWindPower = windPower;
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

    private bool changeSound(double windPower)
    {
        int old_group = 0;
        int current_group = 0;
        if (windPower != oldWindPower)
        {
            if (windPower > LOW_LEVEL)
            {
                if (windPower > HIGH_LEVEL)
                {
                    current_group = 3;
                }
                else if (windPower > MID_LEVEL)
                {
                    current_group = 2;
                }
                else
                {
                    current_group = 1;
                }
            }
            else
            {
                current_group = 0;
            }

            if (oldWindPower > LOW_LEVEL)
            {
                if (oldWindPower > HIGH_LEVEL)
                {
                    old_group = 3;
                }
                else if (oldWindPower > MID_LEVEL)
                {
                    old_group = 2;
                }
                else
                {
                    old_group = 1;
                }
            }
            else
            {
                old_group = 0;
            }

            if (old_group != current_group)
            {
                return true;
            }
        }
        return false;
    }
}
