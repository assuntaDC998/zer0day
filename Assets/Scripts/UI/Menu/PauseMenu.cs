using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    AudioSource musicTrack;
    List<AudioSource> masterSounds;

    private GameObject menu;

    private Button masterButton;
    private Button musicButton;

    private enum State
    {
        ON,
        OFF
    }

    private State musicState;
    private State masterState;

    [SerializeField] public Sprite musicOn;
    [SerializeField] public Sprite musicOff;
    [SerializeField] public Sprite masterOn;
    [SerializeField] public Sprite masterOff;

    private float masterVolume;
    private float musicVolume;
    
    // Start is called before the first frame update
    void Start()
    {
        //retrieves elements and components
        menu = GameObject.Find("PauseMenu");
        masterButton = GameObject.Find("MasterButton").GetComponent<Button>();
        musicButton = GameObject.Find("MusicButton").GetComponent<Button>();

        AudioSource [] audioSources = GameObject.Find("AudioManager").GetComponents<AudioSource>();
        musicTrack = audioSources[(int)Tracks.PAUSE_MUSIC_TRACK];
        masterSounds = new List<AudioSource>();
        masterSounds.Add(audioSources[(int)Tracks.MASTER_SOUND_1]);
        masterSounds.Add(audioSources[(int)Tracks.MASTER_SOUND_2]);

        masterVolume = PlayerPrefs.GetFloat("Master", 1); 
        musicVolume = PlayerPrefs.GetFloat("Music", 1);
    }

    public void ManageMusic() {        
        if (musicState == State.ON)
        {
            // turn down volume and change button sprite
            musicTrack.volume = 0;
            musicButton.GetComponent<Image>().sprite = musicOff;
            musicState = State.OFF;
        }
        else if (musicState == State.OFF) {
            // turn up volume and change button sprite
            musicTrack.volume = musicVolume;
            musicButton.GetComponent<Image>().sprite = musicOn;
            musicState = State.ON;
        }
    }

    public void ManageMaster() {
        if (masterState == State.ON)
        {
            foreach (AudioSource audio in masterSounds)
                audio.volume = 0;

            masterButton.GetComponent<Image>().sprite = masterOff;
            masterState = State.OFF;
        }
        else if (musicState == State.OFF)
        {
            foreach (AudioSource audio in masterSounds)
                audio.volume = masterVolume;

            masterButton.GetComponent<Image>().sprite = masterOn;
            masterState = State.ON;
        }
    }

    private void savePrefs()
    {
        //HANDLE PLAYER PREFS
        PlayerPrefs.SetFloat("Master", masterVolume);
        PlayerPrefs.SetFloat("Music", musicVolume);
    }

    public void Resume() {
        //TO COMPLETE: RESUME GAME
        Debug.Log("Menu is: " + menu != null);
        savePrefs();
        menu.SetActive(false);
    }


    public void Restart() {
        savePrefs();
        
        // TO COMPLETE
    }

    public void Exit()
    {
        savePrefs();
        //TO COMPLETE;
    }

}
