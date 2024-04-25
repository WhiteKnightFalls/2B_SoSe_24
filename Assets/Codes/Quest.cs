using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{ 
    private QuestScreen questScreen;
    public string QuestObjective;
    public bool completed;
    public UnityEvent onCompleted;
    void Start()
    {
        //sehr vorsichtig benutzen: Unity sucht gesamte Szene durch -> wenn sehr viele Objekte und Komponente dann dauert es lange
        //niemals in update
        questScreen = FindFirstObjectByType<QuestScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuest()
    {
        if (completed)
        {
            return;
        }
        //QuestScreen den Text geben
        questScreen.ShowQuest(this);
    }

    public void EndQuest()
    {
        //nachgucken ob quest schon gestartet wurde -> nichts tun
        if(completed)
        {
            return;
        }

        questScreen.FinishQuest(this);
        completed = true;
        onCompleted.Invoke();
    }
}
