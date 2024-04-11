using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string Message;

    public void Collect()
    {
        Debug.Log(Message);
        Destroy(gameObject);
    }
}
