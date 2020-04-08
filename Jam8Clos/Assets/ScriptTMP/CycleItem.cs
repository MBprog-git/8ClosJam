using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleItem : MonoBehaviour
{
public enum Interaction_Type
    {
        Toggle,
        Animation,
    }
    public Interaction_Type Interaction = Interaction_Type.Toggle;


    public void Cycle()
    {
        switch (Interaction)
        {
            case Interaction_Type.Toggle:
                gameObject.SetActive(!gameObject.activeSelf);
                break;   
            case Interaction_Type.Animation:

                if (GetComponent<Animation>().isPlaying)
                {
                    GetComponent<Animation>().Stop();
                }
                else
                {
                    GetComponent<Animation>().Play(GetComponent<Animation>().clip.name);
                }


                break;
        }
    }
}
