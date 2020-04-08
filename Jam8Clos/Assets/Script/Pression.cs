using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pression : MonoBehaviour
{

    public GameObject plaque_1;
    public GameObject plaque_2;
    public GameObject plaque_3;
    public GameObject verrou;

    public bool bool_plaque_1;
    public bool bool_plaque_2;
    public bool bool_plaque_3;

    public bool pressed_plaque_1;
    public bool pressed_plaque_2;
    public bool pressed_plaque_3;

    private int cpt = 0;
    public float timeAfterFail = 0.0f;

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
            if (bool_plaque_1 && bool_plaque_2 && bool_plaque_3)
            {
                verrou.SetActive(true);
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
                    cpt++;
                }
                else if (cpt == 1 && other.gameObject == plaque_2 && !pressed_plaque_2)
                {
                    pressed_plaque_2 = true;
                    bool_plaque_2 = true;
                    cpt++;
                }
                else if (cpt == 2 && other.gameObject == plaque_3 && !pressed_plaque_3)
                {
                    pressed_plaque_3 = true;
                    bool_plaque_3 = true;
                    cpt++;
                }
                else
                {
                    if (other.gameObject == plaque_1 && cpt != 0 && !pressed_plaque_1)
                    {
                        pressed_plaque_1 = true;
                        bool_plaque_1 = false;
                        cpt++;
                    }
                    else if (other.gameObject == plaque_2 && cpt != 1 && !pressed_plaque_2)
                    {
                        pressed_plaque_2 = true;
                        bool_plaque_2 = false;
                        cpt++;
                    }
                    else if (other.gameObject == plaque_3 && cpt != 2 && !pressed_plaque_3)
                    {
                        pressed_plaque_3 = true;
                        bool_plaque_3 = false;
                        cpt++;
                    }
                }
            }
        }
    }
}
