using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;
using TMPro;


public class MainMenu : MonoBehaviour
{

    void Start()
    {
        string language = PlayerPrefs.GetString("Language", "English");
        LocalizationManager.Read();
        LocalizationManager.Language = language;

        AudioSource track = GameObject.Find("AudioManager").GetComponents<AudioSource>()[(int)Tracks.MENU_MUSIC_TRACK];
        float music = PlayerPrefs.GetFloat("Music", 1);
        track.volume = music;

    }

    public void Continue()
    {
        
    }

    public void PlayGame()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

}
