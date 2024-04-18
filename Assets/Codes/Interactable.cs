using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private MeshRenderer _renderer;
    
    public DialogScreen dialogScreen;
    public DialogItem item;

    public Material normalMaterial;
    public Material highlightMaterial;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void Interact()
    {
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
}
