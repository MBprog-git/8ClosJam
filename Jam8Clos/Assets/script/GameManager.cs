using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Space]
    [Header("GD Friendly")]
    [Space]

    public float TimerFaisceau;

    [Space]
    [Header("Public Manager ")]
    [Space]

    public static GameManager instance;
    public bool FaisceauOK = false;
    public bool PressionOK = false;
    int currentPress;
    public  int LastPress;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void VerifPression(int ordre)
    {
        if (ordre == currentPress + 1)
        {
            currentPress = ordre;
            if(currentPress == LastPress)
            {
                PressionOK = true;
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
