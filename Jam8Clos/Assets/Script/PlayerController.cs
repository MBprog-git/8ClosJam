using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;


    bool Avant;
    bool Reculer;
    bool Droite;
    bool Gauche;
 


     float speed;

  
    bool _Grounded;
    float Gravity;
    float SpeedFall;
    float SpeedFallMax;

    public Transform Respawn;
     

    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.instance.speed;
        Gravity = GameManager.instance.Gravity;
        SpeedFallMax = GameManager.instance.FallSpeedMax;
     

        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        
        /*
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
            transform.Rotate(transform.rotation.x, transform.rotation.y+ Rotaspeed*Time.deltaTime, transform.rotation.z,Space.World);
        }
        if (Gauche)
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y - Rotaspeed*Time.deltaTime, transform.rotation.z, Space.World);
        }*/


          //Move Velocity
          if (Avant)
          {
            transform.position += transform.forward * Time.deltaTime * speed;
           
          }
          if (Reculer)
          {
            transform.position -= transform.forward * Time.deltaTime * speed;
         
          }
          if (Droite)
          {
            transform.position += transform.right * Time.deltaTime * speed;
           
          }
          if (Gauche)
          {
              
            transform.position -= transform.right * Time.deltaTime * speed;
          }

        Gravitation(Time.fixedDeltaTime);

         /* if (Avant)
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

          }*/




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

    private void Gravitation(float DeltaTime)
    {
        if (_Grounded)
        {
            SpeedFall = 0;
        }
        else
        {
            SpeedFall -= Gravity * DeltaTime;
            if (SpeedFall < -SpeedFallMax)
            {
                SpeedFall = -SpeedFallMax;
            
            }
            rb.velocity = new Vector3(rb.velocity.x, SpeedFall, rb.velocity.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Respawn")
        {
            transform.position = Respawn.transform.position;
        }
        if(collision.gameObject.tag == "Scene")
        {
            _Grounded = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Scene")
        {
            _Grounded = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish" && GameManager.instance.Open)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }
}

      

