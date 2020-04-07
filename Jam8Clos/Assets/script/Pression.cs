using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pression : MonoBehaviour
{
    public int ordre;

    // Start is called before the first frame update
    void Start()
    {
        if (ordre > GameManager.instance.LastPress)
        {

            GameManager.instance.LastPress = ordre;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.VerifPression(ordre);
        }
    }
}
