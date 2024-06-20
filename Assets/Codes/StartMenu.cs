using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   public static EventInstance _musicInstance;

    public EventReference musicEvent;
    // Start is called before the first frame update
    void Start()
    {
        if (!_musicInstance.hasHandle())
        {
            //spielt sound noch nicht ab, erstellt nur instance
            _musicInstance = RuntimeManager.CreateInstance(musicEvent);
            _musicInstance.start();
        }
    }

    public void StartGame(){
        //Name des Parameters, Muisk wird gewechselt von scene to level
        _musicInstance.setParameterByNameWithLabel("Scene", "Level");
        SceneManager.LoadScene(1);
    }

    public void MuteAudio(bool muted)
    {
        RuntimeManager.MuteAllEvents(muted);
    }
}
