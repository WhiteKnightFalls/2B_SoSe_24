using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogOption : MonoBehaviour
{
    public string text;
    public DialogItem nextDialog;


    public UnityEvent onOptionSelected;


}
