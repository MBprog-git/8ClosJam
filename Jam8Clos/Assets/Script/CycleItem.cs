using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleItem : MonoBehaviour
{
public enum Interaction_Type
    {
        Toggle,
        Animation,
        Teleport,
    }
    public Interaction_Type Interaction = Interaction_Type.Toggle;

    public Transform DayPoint;
    public Transform NightPoint;


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
            case Interaction_Type.Teleport:
                if(DayPoint == null || NightPoint == null)
                {
                    Debug.Log("PAS DE POINT A UN TELEPORT");
                    return;
                }
                if (transform.position == DayPoint.position)
                {
                    transform.position = NightPoint.position;
                }
                else
                {
                    transform.position = DayPoint.position;
                }
                    break;
        }
    }
}
