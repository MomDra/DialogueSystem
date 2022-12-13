using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{

    // 여기가 모델이라고 해보자

    public class Quest
    {
        int no;

        DialogueEvent dialogueEvent;
    }

    List<Quest> currQuestList = new List<Quest>();

    void Start()
    {

    }

    void Update()
    {

    }


    public void AddQuest(Quest quest)
    {
        currQuestList.Add(quest);
    }
}
