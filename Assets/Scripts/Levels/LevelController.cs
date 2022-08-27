using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class LevelController : MonoBehaviour
{

    [HideInInspector] public static LevelController lc;
    [HideInInspector] public int currentLevelID;

    //[HideInInspector] public SessionController sc;
    // HUD 
    public GameObject infoCanvas;

    // Handle downloaded data
    [HideInInspector] public GameObject levelCompletionBar;
    [HideInInspector] public float downloadedData;

    // Handle coins level
    [HideInInspector] public GameObject coinsText;
    [HideInInspector] public int coins;

    // Handle events and modifiers
    [HideInInspector] public ModifierJsonMap levelsjson;
    [HideInInspector] public LevelsJsonMap levels;

    [HideInInspector] public ModifierJsonMap modifiersjson;
    [HideInInspector] public EventJsonMap events;


    private void Awake()
    {
        int currentSceneID = SceneManager.GetActiveScene().buildIndex;
        // Read level configuration

        string featuresFile = new StreamReader("Assets/PushToData/Levels/levels.json").ReadToEnd();
        levels = JsonUtility.FromJson<LevelsJsonMap>(featuresFile);

        if (lc == null && currentSceneID != 0)
        {
            lc = this;
            DontDestroyOnLoad(gameObject);

            //sessionController = GameObject.FindWithTag("SessionController");
            //sc = sessionController.GetComponent<SessionController>();

            // READ INIT COINS FROM FILE
            coins = 0;
            currentLevelID = 1;

        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void ModifyCoin(int amount) {
        coins += amount;
    }

    public void ModifyDataToComplete(int amount)
    {
        downloadedData += amount;
    }

    public void CheckSceneType()
    {
        //If current scene doesn't cointain "level" substring must be destroyed
        if (!SceneManager.GetActiveScene().name.ToString().Contains("Level"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLevelCompleted())
        {
            

        }
        else { 
            // EXIT LEVEL

            //compromissionbar=sum(compr_i)/n
        }        
    }


    public bool isLevelCompleted() {

        if (downloadedData >= levels.getLevelbyID(currentLevelID).dataToComplete)
            return true;
        
        return false;
    }

    public void ParametersReset()
    {
       //TO DO
    }
}
