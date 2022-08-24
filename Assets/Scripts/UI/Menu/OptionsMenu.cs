using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using System;

public class OptionsMenu : MonoBehaviour
{

    List<string> languages = new List<string>{"English","Italiano"};
    List<string> resolutions = new List<string> { "854x480", "1280x720", "1600x900", "1920x1080" };

    public float sfx;
    public float master;
    public float music;

    int languageindex;
    int resolutionindex;
    public string resolutionValue;
    public string language;

    public bool fullScreenValue;

    TextMeshProUGUI selLanguage;
    TextMeshProUGUI resolution;
    CanvasScaler canvasScaler;
    Slider musicSlider;
    Slider masterSlider;
    Slider sfxSlider;
    Toggle fullScreen;

    AudioSource track;

    void Start()
    {
        selLanguage = GameObject.Find("SelLanguage").GetComponent<TextMeshProUGUI>();
        resolution = GameObject.Find("SelRes").GetComponent<TextMeshProUGUI>();
        canvasScaler = GameObject.Find("Canvas").gameObject.GetComponent<CanvasScaler>();
        musicSlider = GameObject.Find("Music slider").gameObject.GetComponent<Slider>();
        masterSlider = GameObject.Find("Master slider").gameObject.GetComponent<Slider>();
        sfxSlider = GameObject.Find("Sfx slider").gameObject.GetComponent<Slider>();
        fullScreen = GameObject.Find("Toggle").GetComponent<Toggle>();
        track = GameObject.Find("AudioManager").GetComponents<AudioSource>()[(int)Tracks.MENU_MUSIC_TRACK];

        // Load Player prefs
        sfx = PlayerPrefs.GetFloat("Sfx", 1);
        master = PlayerPrefs.GetFloat("Master", 1);
        music = PlayerPrefs.GetFloat("Music", 1);
        language = PlayerPrefs.GetString("Language", "English");
        languageindex = PlayerPrefs.GetInt("Lindex", 0);
        resolutionindex = PlayerPrefs.GetInt("Rindex", 3);
        resolutionValue = PlayerPrefs.GetString("Resolution", "1920x1080");
        fullScreenValue = (PlayerPrefs.GetInt("FullScreen", 1) == 1 ? true : false);

        // Set Init value
        sfxSlider.value = sfx;        
        musicSlider.value = music;
        masterSlider.value = master;
        selLanguage.text = language;

        string[] res = resolutionValue.Split('x');
        resolution.text = resolutions[resolutionindex];
        canvasScaler.referenceResolution = new Vector2(Int32.Parse(res[0]), Int32.Parse(res[1]));

        fullScreen.isOn = fullScreenValue;

    }

    public void Back() {
        // Save changed Prefs
        PlayerPrefs.SetFloat("Sfx", sfx);
        PlayerPrefs.SetFloat("Master", master);
        PlayerPrefs.SetFloat("Music", music);
        PlayerPrefs.SetString("Language", languages[languageindex]);
        PlayerPrefs.SetInt("Lindex", languageindex);
        PlayerPrefs.SetInt("Rindex", resolutionindex);
        PlayerPrefs.SetString("Resolution", resolutionValue);
        PlayerPrefs.SetInt("FullScreen", fullScreenValue ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ManageSfxVolume()
    {
        // TO COMPLETE
    }
    public void ManageMasterVolume()
    {
        // TO COMPLETE
    }

    public void ManageMusicVolume()
    {
        music = musicSlider.value;
        track.volume = music;
    }

    public void ChangeLanguageUp()
    {
        if (languageindex==(languages.Count()-1)){
            languageindex=0;
        }
        else{
            languageindex=(languageindex+1);
        }
        
        LocalizationManager.Language = languages[languageindex];
        selLanguage.text = languages[languageindex];
    }

    public void ChangeLanguageDown()
    {

        if (languageindex>0){
            languageindex=(languageindex-1);
        }
        else{
            languageindex=languages.Count()-1;
        }
        
        LocalizationManager.Language = languages[languageindex];
        selLanguage.text = languages[languageindex];
    }

    public void refreshResolution() {
        resolutionValue = resolutions[resolutionindex];
        string[] res = resolutionValue.Split('x');
        resolution.text = resolutionValue;
        int width = Int32.Parse(res[0]);
        int height = Int32.Parse(res[1]);
        canvasScaler.referenceResolution = new Vector2(width, height);
        Screen.SetResolution(width, height, fullScreenValue);
    }

    public void ChangeResolutionUp(){
        if (resolutionindex==(resolutions.Count()-1)){
            resolutionindex=0;
        }
        else{
            resolutionindex=(resolutionindex+1);
        }
        refreshResolution();
    }

    public void ChangeResolutionDown(){

        if (resolutionindex>0){
            resolutionindex=(resolutionindex-1);
        }
        else{
            resolutionindex=resolutions.Count()-1;
        }
        refreshResolution();
    }

    public void ToggleFullscreen(){
        Screen.fullScreen = fullScreen.isOn;
        fullScreenValue = fullScreen.isOn;
    }

  
}
