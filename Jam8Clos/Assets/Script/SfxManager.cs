using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public float RandTimerUp;
    public float RandTimerDown;
    float Timer;
    public List<AudioClip> Sfx;
    AudioSource Source;

    // Start is called before the first frame update
    void Start()
    {
        Source = GetComponent<AudioSource>();
        Timer = Random.Range(RandTimerDown, RandTimerUp);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer -= Time.fixedDeltaTime;
        if (Timer < 0)
        {
            int i = Random.Range(0, Sfx.Count);
            Debug.Log(i);

            Source.PlayOneShot(Sfx[i]);

            

        Timer = Random.Range(RandTimerDown, RandTimerUp);
        }
    }
}
