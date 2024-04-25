using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class DialogScreen : MonoBehaviour
{
    private DialogItem _currentItem;
    
    public TMP_Text textBox;
    public GameObject container;
    public List<GameObject> buttons;
         
    // Start is called before the first frame update
    void Start()
    {
        EndDialog();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialog(DialogItem item)
    {
        //wie viele dialogoptionen gibt es und wie viele buttons müssen eingeblendet werden
        container.SetActive(true);
        textBox.text = item.text;
        //for-Schleife mit 3 buttons 0-2
        /*button mit index 0 wird aktiviert,  wird im child compomnent
         die textvariable gesucht
         text aus options wird übernommen und ausgeführt 
         alles bis 2 erreicht wird
        */
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < item.options.Count)
            {
                buttons[i].SetActive(true);
                buttons[i].GetComponentInChildren<TMP_Text>().text = item.options[i].text;
            }
            else
            {
                buttons[i].SetActive(false);
            }
        }

        _currentItem = item;
    }

    public void EndDialog()
    {
        container.SetActive(false);
    }

    public void ChooseOption(int index)
    {
        DialogOption option = _currentItem.options[index];
        //Invoke=Auslösen
        option.onOptionSelected.Invoke();

        if (option.nextDialog != null)
        {
            StartDialog(option.nextDialog);
        }
        else
        {
            EndDialog();
        }
    }
}
