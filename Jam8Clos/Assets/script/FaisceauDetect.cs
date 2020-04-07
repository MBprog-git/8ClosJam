using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaisceauDetect : MonoBehaviour
{
float timer;
float Temps;

    // Start is called before the first frame update
    void Start()
    {
        Temps = GameManager.instance.TimerFaisceau;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            timer = Temps;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" && GameManager.instance.Jour)
        {
           timer -= Time.deltaTime;
            if (timer < 0)
            {
                GameManager.instance.FaisceauOK = true;
            }
        }
        else
        {
            timer = Temps;
        }
    }
}
