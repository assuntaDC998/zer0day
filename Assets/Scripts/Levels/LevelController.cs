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

    //[HideInInspector] public SessionController sc;
    // HUD 
    public GameObject infoCanvas;

    // Handle downloaded data
    [HideInInspector] public ProgressBar levelCompletionBar;
    [HideInInspector] public float downloadedData;

    [HideInInspector] public ProgressBar locBar;
    [HideInInspector] public float loc;

    // Handle coins level
    [HideInInspector] public GameObject coinsText;
    [HideInInspector] public int coins;

    // Handle events and modifiers
    //[HideInInspector] public ModifierJsonMap levelsjson;
    [HideInInspector] public LevelsJsonMap levels;

    [HideInInspector] public ModifierJsonMap modifiersjson;
    [HideInInspector] public EventJsonMap events;

    [SerializeField]
    public int currentLevelID;

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

            // init starting level coins from Json
            coins = levels.GetLevelByID(currentLevelID).initialCoins;
            coinsText = GameObject.FindWithTag("Coins");

            // reset data and loc 
            levelCompletionBar = GameObject.FindWithTag("LevelBar").GetComponent<ProgressBar>();
            locBar = GameObject.FindWithTag("LocBar").GetComponent<ProgressBar>();
            downloadedData = 0;
            loc = 0;
            levelCompletionBar.current = 0;
            locBar.current = 0;
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
            // Show coins amount
            coinsText.GetComponent<TextMeshProUGUI>().text = coins.ToString();
            
            // Update data and loc bar
            levelCompletionBar.current = ((int)(downloadedData / levelCompletionBar.maximum));
            locBar.current = ((int)(downloadedData / locBar.maximum));

        }
        else { 
            // EXIT LEVEL
         }        
    }


    public bool isLevelCompleted() {

        if (downloadedData >= levels.GetLevelByID((int)currentLevelID).targetGB)
            return true;
        
        return false;
    }

    public void ParametersReset()
    {
       //TO DO
    }
}
