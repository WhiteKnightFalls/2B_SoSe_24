using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogScreen dialogScreen;
    public DialogItem item;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartDialog()
    {
        dialogScreen.StartDialog(item); 
    }
    //setzt welches Dialog gestartet wird
    public void SetDialog(DialogItem newItem)
    {
        item = newItem;
    }
}
