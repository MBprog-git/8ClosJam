using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pression : MonoBehaviour
{

    public GameObject plaque_1;
    public GameObject plaque_2;
    public GameObject plaque_3;

    private bool bool_plaque_1;
    private bool bool_plaque_2;
    private bool bool_plaque_3;

    private bool pressed_plaque_1;
    private bool pressed_plaque_2;
    private bool pressed_plaque_3;

    public Material illumination;
    public Material standard;

    private int cpt = 0;
    private float timeAfterFail = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        bool_plaque_1 = false;
        bool_plaque_2 = false;
        bool_plaque_3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cpt == 3)
        {
            if (bool_plaque_1 && bool_plaque_2 && bool_plaque_3 && GameManager.instance.PressionOK)
            {
                GameManager.instance.PressionOK = true;
                GameManager.instance.Diode1.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                bool_plaque_1 = false;
                bool_plaque_2 = false;
                bool_plaque_3 = false;

                pressed_plaque_1 = false;
                pressed_plaque_2 = false;
                pressed_plaque_3 = false;
                cpt = 0;
                timeAfterFail = 3.0f;

                plaque_1.GetComponent<Renderer>().material = standard;
                plaque_2.GetComponent<Renderer>().material = standard;
                plaque_3.GetComponent<Renderer>().material = standard;
                plaque_1.GetComponent<Light>().enabled = false;
                plaque_2.GetComponent<Light>().enabled = false;
                plaque_3.GetComponent<Light>().enabled = false;
            }
        }
        if (timeAfterFail >= 0)
        {
            timeAfterFail -= Time.deltaTime;
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (timeAfterFail < 0)
        {
            if (cpt < 3)
            {
                if (cpt == 0 && other.gameObject == plaque_1 && !pressed_plaque_1)
                {
                    pressed_plaque_1 = true;
                    bool_plaque_1 = true;
                    plaque_1.GetComponent<Light>().enabled = true;
                    plaque_1.GetComponent<Renderer>().material = illumination;
                    cpt++;
                }
                else if (cpt == 1 && other.gameObject == plaque_2 && !pressed_plaque_2)
                {
                    pressed_plaque_2 = true;
                    bool_plaque_2 = true;
                    plaque_2.GetComponent<Light>().enabled = true;
                    plaque_2.GetComponent<Renderer>().material = illumination;
                    cpt++;
                }
                else if (cpt == 2 && other.gameObject == plaque_3 && !pressed_plaque_3)
                {
                    pressed_plaque_3 = true;
                    bool_plaque_3 = true;
                    plaque_3.GetComponent<Light>().enabled = true;
                    plaque_3.GetComponent<Renderer>().material = illumination;
                    cpt++;
                }
                else
                {
                    if (other.gameObject == plaque_1 && cpt != 0 && !pressed_plaque_1)
                    {
                        pressed_plaque_1 = true;
                        bool_plaque_1 = false;
                        plaque_1.GetComponent<Light>().enabled = true;
                        plaque_1.GetComponent<Renderer>().material = illumination;
                        cpt++;
                    }
                    else if (other.gameObject == plaque_2 && cpt != 1 && !pressed_plaque_2)
                    {
                        pressed_plaque_2 = true;
                        bool_plaque_2 = false;
                        plaque_2.GetComponent<Light>().enabled = true;
                        plaque_2.GetComponent<Renderer>().material = illumination;
                        cpt++;
                    }
                    else if (other.gameObject == plaque_3 && cpt != 2 && !pressed_plaque_3)
                    {
                        pressed_plaque_3 = true;
                        bool_plaque_3 = false;
                        plaque_3.GetComponent<Light>().enabled = true;
                        plaque_3.GetComponent<Renderer>().material = illumination;
                        cpt++;
                    }
                }
            }
        }
    }
}
