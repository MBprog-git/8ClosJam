﻿using System.Collections;
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
    public float TimerJourNuit;
    [Space]
    public float SensitivityH;
    public float SensitivityV;
    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;


    [Space]
    [Space]
    [Header("Public Manager")]
    public bool Jour;
    float ChronoCycle;
    public GameObject camera;
    public GameObject Player;
    public GameObject Cubetest;
    public GameObject SphereTest;
    public Image Paupiere;
    public GameObject faisceau;
    public GameObject Diode1;
    public GameObject Diode2;
    public GameObject Diode3;
    public bool FaisceauOK = false;
    public bool PressionOK = false;
    public bool LettreOK = false;
    int currentPress;
    public  int LastPress;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public static GameManager instance;
    

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChronoCycle = TimerJourNuit;
        CycleDay();
        Diode1.GetComponent<Renderer>().material.color = Color.red;
        Diode2.GetComponent<Renderer>().material.color = Color.red;
        Diode3.GetComponent<Renderer>().material.color = Color.red;
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
        pitch = Mathf.Clamp(pitch, -90, 15);
        camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        Player.transform.eulerAngles = new Vector3(Player.transform.eulerAngles.x, yaw, Player.transform.eulerAngles.z);
        camera.transform.position = new Vector3(Player.transform.position.x+OffsetX, Player.transform.position.y+OffsetY, Player.transform.position.z+OffsetZ);

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
        if(FaisceauOK && PressionOK && LettreOK)
        {
            //Porte Ouverte
        }
    }

    public void CycleDay()
    {
        Jour = !Jour;

        if (Jour)
        {
            SphereTest.SetActive(true);
            Cubetest.GetComponent<Animation>().Stop();
            if (!FaisceauOK) { 
            faisceau.SetActive(true);
            }
           
            RenderSettings.ambientLight = new Color(10, 10, 10,1);

        }
        else
        { 
            Cubetest.GetComponent<Animation>().Play(Cubetest.GetComponent<Animation>().clip.name);
            SphereTest.SetActive(false);
            RenderSettings.ambientLight = new Color(0,0, 0,1);


            faisceau.SetActive(false);
        }
        Paupiere.color = new Color(Paupiere.color.r, Paupiere.color.g, Paupiere.color.b, 1);
        ChronoCycle = TimerJourNuit;
    }
    public void VerifPression(int ordre)
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
    }

    public void doExitGame()
    {
        Application.Quit();
    }
    public void MyLoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
     
    }
}
