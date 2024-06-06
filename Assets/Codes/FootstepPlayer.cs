using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

//Footstep Script muss in den Root vom Player und Footstep sfx in Event
public class FootstepPlayer : MonoBehaviour
{
    //2 Möglichkeiten 
    // event path
    // public string atmoEventPath;
    // event reference 
    public EventReference footstepEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayFootstep()
    {
        //spielt event einmal ab
        RuntimeManager.PlayOneShot(footstepEvent, transform.position);
    }
}
