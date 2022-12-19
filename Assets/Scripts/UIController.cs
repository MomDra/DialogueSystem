using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // 여기가 controller이다!

    static UIController instance;
    public static UIController Instance { get => instance; }

    [SerializeField]
    GameObject dialogueWindow;

    [SerializeField]
    DialogueView view;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void EnableQuestWindow(int[] questNumbers)
    {
        view.EnableQuestWindow();

        foreach (int var in questNumbers)
        {
            view.AddQuest(QuestSystem.instance.GetQuest(var).Mission, var);
        }
    }

    public void EnableDialogueWindow(int questNum)
    {
        view.EnableDialougeWindow();

        QuestSystem.Quest quest = QuestSystem.instance.GetQuest(questNum);

        switch (quest.State)
        {
            case QuestSystem.QuestState.BEFORE:
                view.SetDialogues(quest.BeforeDialogues);
                break;
            case QuestSystem.QuestState.CURR:
                view.SetDialogues(quest.CurrDialogues);
                break;
            case QuestSystem.QuestState.AFTER:
                view.SetDialogues(quest.AfterDialogues);
                break;
        }
    }
}
