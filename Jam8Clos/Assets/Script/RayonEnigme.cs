using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayonEnigme : MonoBehaviour
{
    float timer;
    float Temps;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lettre")
        {
            timer = Temps;
        }
    }
    
    
    public List<GameObject> Light;
    public GameObject[] Lettre;
    public GameObject Verrou;
    public int cpt = 0;

    public bool Lettre_1 = false;
    public bool Lettre_2 = false;
    public bool Lettre_3 = false;
    private bool Comfirm_Lettre_1 = false;
    private bool Comfirm_Lettre_2 = false;
    private bool Comfirm_Lettre_3 = false;

    private void Start()
    {
        Temps = GameManager.instance.TimerLettre;
        Lettre_1 = false;
        Lettre_2 = false;
        Lettre_3 = false;
    }
    void Update()
    {
        if (cpt == 3)
        {
            if (Lettre_1 & Lettre_2 & Lettre_3)
            {
                GameManager.instance.LettreOK = true;
                GameManager.instance.Diode3.GetComponent<Renderer>().material.color = Color.green;
                GameManager.instance.Diode3.SetActive(false);
            }
            else
            {
                Lettre_1 = false;
                Lettre_2 = false;
                Lettre_3 = false;
                Comfirm_Lettre_1 = false;
                Comfirm_Lettre_2 = false;
                Comfirm_Lettre_3 = false;
                cpt = 0;
                Light.Clear();
            }
            
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Lettre")
        {
            
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                Debug.Log("fin timer");

                if (cpt < 3)
                {

                    Debug.Log("choix Lettre");
                    if (other.gameObject == Lettre[0] || other.gameObject == Lettre[1] || other.gameObject == Lettre[2] && !Comfirm_Lettre_1)
                    {
                        Debug.Log("Lettre1");
                        Lettre_1 = true;
                        Comfirm_Lettre_1 = true;
                        cpt++;
                    }
                    else if (other.gameObject == Lettre[0] || other.gameObject == Lettre[1] || other.gameObject == Lettre[2] && !Comfirm_Lettre_2)
                    {
                        Debug.Log("Lettre2");
                        Lettre_2 = true;
                        Comfirm_Lettre_2 = true;
                        cpt++;
                    }
                    else if (other.gameObject == Lettre[0] || other.gameObject == Lettre[1] || other.gameObject == Lettre[2] && !Comfirm_Lettre_3)
                    {
                        Debug.Log("Lettre3");
                        Lettre_3 = true;
                        Comfirm_Lettre_3 = true;
                        cpt++;
                    }
                    else
                    {
                        if (other.gameObject == Lettre[3] || other.gameObject == Lettre[4] || other.gameObject == Lettre[5] || other.gameObject == Lettre[6] || other.gameObject == Lettre[7] && !Comfirm_Lettre_1)
                        {
                            Debug.Log("Lettreautre");
                            Lettre_1 = false;
                            Comfirm_Lettre_1 = true;
                            cpt++;
                        }
                        else if (other.gameObject == Lettre[3] || other.gameObject == Lettre[4] || other.gameObject == Lettre[5] || other.gameObject == Lettre[6] || other.gameObject == Lettre[7] && !Comfirm_Lettre_1 && !Comfirm_Lettre_2)
                        {
                            Debug.Log("Lettreautre");
                            Lettre_2 = false;
                            Comfirm_Lettre_2 = true;
                            cpt++;
                        }
                        else if (other.gameObject == Lettre[3] || other.gameObject == Lettre[4] || other.gameObject == Lettre[5] || other.gameObject == Lettre[6] || other.gameObject == Lettre[7] && !Comfirm_Lettre_1 && !Comfirm_Lettre_3)
                        {
                            Debug.Log("Lettreautre");
                            Lettre_3 = false;
                            Comfirm_Lettre_3 = true;
                            cpt++;
                        }

                    }
                }
               


            }
        }
        else
        {
            timer = Temps;
        }
        
    }
}
