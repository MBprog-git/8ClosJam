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
        PlayerSafe,
    }
    public Interaction_Type Interaction = Interaction_Type.Toggle;

    public Transform DayPoint;
    public Transform NightPoint;
    public Transform PlayerRepos;

    bool playerIn;
    GameObject Player;

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
                    Debug.Log("PAS DE POINT A UN OBJET TELEPORT");
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
            case Interaction_Type.PlayerSafe:
                if(PlayerRepos == null)
                {
                    Debug.Log("PAS DE PlayerRepos");
                    return;
                }
                if (playerIn)
                {
                    Player.transform.position = PlayerRepos.transform.position;
                }
                gameObject.SetActive(!gameObject.activeSelf);

                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIn = true;
            Player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIn = false;
           
        }
    }
}
