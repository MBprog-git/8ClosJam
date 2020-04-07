using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;


    bool Avant;
    bool Reculer;
    bool Droite;
    bool Gauche;
 


    public float speed;
    public float maxSpeed;
    public float frottement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {



        //Move Velo
        if (Avant)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + speed * Time.fixedTime);
        }
        if (Reculer)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + speed * Time.fixedTime * -1);
        }
        if (Droite)
        {
            rb.velocity = new Vector3(rb.velocity.x + speed * Time.fixedTime, rb.velocity.y, rb.velocity.z);
        }
        if (Gauche)
        {
            rb.velocity = new Vector3(rb.velocity.x + speed * Time.fixedTime * -1, rb.velocity.y, rb.velocity.z);
        }

        //Maxspeed
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.z > maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        }
        if (rb.velocity.z < -maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);
        }

        //Frottement
        if (!Gauche && !Droite)
        {
            if (rb.velocity.x < -0.5f)
            {
                rb.velocity = new Vector3(rb.velocity.x + frottement * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            }
            if (rb.velocity.x > 0.5f)
            {
                rb.velocity = new Vector3(rb.velocity.x - frottement * Time.deltaTime, rb.velocity.y, rb.velocity.z);
            }
            if (rb.velocity.x > -0.5f && rb.velocity.x < 0.5f)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }

        }
        if (!Avant && !Reculer)
        {
            if (rb.velocity.z < -0.5f)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + frottement * Time.deltaTime);
            }
            if (rb.velocity.z > 0.5f)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z - frottement * Time.deltaTime);
            }
            if (rb.velocity.z > -0.5f && rb.velocity.z < 0.5f)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            }

        }




    }

    // Update is called once per frame
    void Update()
    {
        //Inputs Move


       

            if (Input.GetKey(KeyCode.Z))
            {
                Avant = true;
            }
            else
            {
                Avant = false;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                Gauche = true;
            }
            else
            {
                Gauche = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Reculer = true;
            }
            else
            {
                Reculer = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Droite = true;
            }
            else
            {
                Droite = false;
            }
        


    }
}

      

