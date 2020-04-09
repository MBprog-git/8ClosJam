using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public float RandTimerUp;
    public float RandTimerDown;
    float Timer;
    public AudioClip[] Sfx;
    public GameObject[] Haut_Parleurs;
    AudioSource Source;

    // Start is called before the first frame update
    void Start()
    {
        
        Timer = Random.Range(RandTimerDown, RandTimerUp);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer -= Time.fixedDeltaTime;
        if (Timer < 0)
        {

            int i = Random.Range(0, Sfx.Length);
            int o = Random.Range(0, Haut_Parleurs.Length);
            
            Debug.Log(i +"Sfx");
            Debug.Log(o+"Hp");

            Source = Haut_Parleurs[o].GetComponent<AudioSource>();
            Source.PlayOneShot(Sfx[i]);

            

        Timer = Random.Range(RandTimerDown, RandTimerUp);
            Debug.Log(Timer);
        }
    }
}
