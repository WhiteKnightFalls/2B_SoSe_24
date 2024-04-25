using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private MeshRenderer _renderer;
    
    public DialogScreen dialogScreen;
    public DialogItem item;

    public Material normalMaterial;
    public Material highlightMaterial;

    public UnityEvent onInteracted;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void Interact()
    {
        onInteracted.Invoke();
        dialogScreen.StartDialog(item);    
    }

    public void Highlight()
    {
        _renderer.material = highlightMaterial;
    }

    public void DeHighlight()
    {
        _renderer.material = normalMaterial;
    }
    //setzt welches Dialog gestartet wird
    public void SetDialog(DialogItem newDialog)
    {
        item = newDialog;
    }
}
