using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayonEnigme : MonoBehaviour
{
    public Material c;
    public List<GameObject> Light;
    public GameObject[] Lettre;
    public GameObject Verrou;
    public int cpt = 0;

    private bool Lettre_1 = false;
    private bool Lettre_2 = false;
    private bool Lettre_3 = false;
    private bool Comfirm_Lettre_1 = false;
    private bool Comfirm_Lettre_2 = false;
    private bool Comfirm_Lettre_3 = false;

    private void Start()
    {
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
                Verrou.SetActive(true);
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

    private void OnTriggerEnter(Collider other)
    {
        if (cpt < 3)
        {
            if(other.gameObject == Lettre[0] && !Comfirm_Lettre_1)
            {
                Check();
                Lettre_1 = true;
                Comfirm_Lettre_1 = true;
                cpt++;
            }
            else if (other.gameObject == Lettre[1] && !Comfirm_Lettre_2)
            {
                Lettre_2 = true;
                Comfirm_Lettre_2 = true;
                cpt++;
            }
            else if ( other.gameObject == Lettre[2] && !Comfirm_Lettre_3)
            {
                Lettre_3 = true;
                Comfirm_Lettre_3 = true;
                cpt++;
            }
            else
            {
                if(other.gameObject == Lettre[3] || other.gameObject == Lettre[4] || other.gameObject == Lettre[5] || other.gameObject == Lettre[6] || other.gameObject == Lettre[7] && !Comfirm_Lettre_1)
                {
                    Lettre_1 = false;
                    Comfirm_Lettre_1 = true;
                    cpt++;
                }
                else if(other.gameObject == Lettre[3] || other.gameObject == Lettre[4] || other.gameObject == Lettre[5] || other.gameObject == Lettre[6] || other.gameObject == Lettre[7] && !Comfirm_Lettre_1 && !Comfirm_Lettre_2)
                {
                    Lettre_2 = false;
                    Comfirm_Lettre_2 = true;
                    cpt++;
                }
                else if (other.gameObject == Lettre[3] || other.gameObject == Lettre[4] || other.gameObject == Lettre[5] || other.gameObject == Lettre[6] || other.gameObject == Lettre[7] && !Comfirm_Lettre_1 && !Comfirm_Lettre_3)
                {
                    Lettre_3 = false;
                    Comfirm_Lettre_3 = true;
                    cpt++;
                }
                
            }
        }
    }

    IEnumerator Check()
    {

        yield return new WaitForSeconds(2f);

    }
}
