using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestScreen : MonoBehaviour
{

    public TMP_Text objectiveText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Quest als Parameter
    public void ShowQuest(Quest quest)
    {
        objectiveText.text = quest.QuestObjective;
    }

    public void FinishQuest(Quest quest)
    {
        objectiveText.text = ""; //oder string.Empty oder = null
        //icon aktivieren

    }
}
