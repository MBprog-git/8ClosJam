using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("GD Friendly")]
    [Space]

    public float speed;
    
   
    [Space]
    public float TimerFaisceau;

    public float TimerLettre;

    public float TimerJourNuit;
    [Space]
    public float SensitivityH;
    public float SensitivityV;
    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;

    public float LimiteCamDown=-90;
    public float LimiteCamUp=15;
    
        [Space]
    public float Gravity;
    public float FallSpeedMax;


    [Space]
    [Space]
    [Header("Public Manager")]
    public GameObject Cam;
    public GameObject Player;
   // public GameObject Cubetest;
   // public GameObject SphereTest;
    public GameObject faisceau;
    public GameObject Diode1;
    public GameObject Diode2;
    public GameObject Diode3;
    public GameObject Porte;
    public Image Paupiere;
    public Light Lumiere;
    public bool Jour = true;
    public bool FaisceauOK = false;
    public bool PressionOK = false;
    public bool LettreOK = false;
  //  public  int LastPress;

    // int currentPress;
    bool Open;
    float ChronoCycle;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public static GameManager instance;

    private List<CycleItem> _cycleItems = new List<CycleItem>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        foreach(CycleItem CI in Resources.FindObjectsOfTypeAll(typeof(CycleItem)))
        {
            _cycleItems.Add(CI);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        ChronoCycle = TimerJourNuit;
        //CycleDay();
/*        Diode1.GetComponent<Renderer>().material.color = Color.red;
        Diode2.GetComponent<Renderer>().material.color = Color.red;
        Diode3.GetComponent<Renderer>().material.color = Color.red;*/
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        //Camera
        if (Input.GetMouseButtonDown(0)) { 
            Cursor.lockState = CursorLockMode.Locked;
    }
        yaw += SensitivityH * Input.GetAxis("Mouse X");
        pitch -= SensitivityV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, LimiteCamDown, LimiteCamUp);
        Cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        Player.transform.eulerAngles = new Vector3(Player.transform.eulerAngles.x, yaw, Player.transform.eulerAngles.z);
        Cam.transform.position = new Vector3(Player.transform.position.x+OffsetX, Player.transform.position.y+OffsetY, Player.transform.position.z+OffsetZ);

        //Jour-Nuit
        if (ChronoCycle<0)
        {
            CycleDay();
        }
        else
        {
            ChronoCycle -= Time.deltaTime;
        }
        //clignement
        if (Paupiere.color.a > 0)
        {
            Paupiere.color = new Color(Paupiere.color.r,Paupiere.color.g,Paupiere.color.b,Paupiere.color.a - Time.deltaTime);
            
        }
        //Porte
        if(FaisceauOK && PressionOK && LettreOK && !Open)
        {
           Porte.GetComponent<Animation>().Play(Porte.GetComponent<Animation>().clip.name);
            Open = true;
        }
    }

    public void CycleDay()
    {
        Jour = !Jour;

        if (Jour)
        {
           /* SphereTest.SetActive(true);
            Cubetest.GetComponent<Animation>().Stop();*/

            foreach(CycleItem CI in _cycleItems)
            {
                CI.Cycle();
            }
            if (!FaisceauOK) { 
            faisceau.SetActive(true);
            }
           
            Lumiere.intensity = 7;

            
        }
        else
        {
            /* Cubetest.GetComponent<Animation>().Play(Cubetest.GetComponent<Animation>().clip.name);
             SphereTest.SetActive(false);*/
            foreach (CycleItem CI in _cycleItems)
            {
                CI.Cycle();
            }
            faisceau.SetActive(false);

            Lumiere.intensity = 4;

        }
        Paupiere.color = new Color(Paupiere.color.r, Paupiere.color.g, Paupiere.color.b, 1);
        ChronoCycle = TimerJourNuit;
    }

    /*public void VerifPression(int ordre)

    {
        if (ordre == currentPress + 1)
        {
            currentPress = ordre;
            if(currentPress == LastPress)
            {
                PressionOK = true;
                Diode2.GetComponent<Renderer>().material.color = Color.green;

            }
        }
        else
        {
            currentPress = 0;
        }

    }*/


    public void doExitGame()
    {
        Application.Quit();
    }
    public void MyLoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
     
    }
}
