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
    DialogueView dialogueView;

    [SerializeField]
    QuestInfoView questInfoView;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TogleQuestInfoWindow();
        }
    }

    public void EnableQuestWindow(int[] questNumbers)
    {
        dialogueView.EnableQuestWindow();

        foreach (int var in questNumbers)
        {
            dialogueView.AddQuest(QuestSystem.instance.GetQuest(var).Mission, var);
        }
    }

    public void EnableDialogueWindow(int questNum)
    {
        dialogueView.EnableDialougeWindow();

        QuestSystem.Quest quest = QuestSystem.instance.GetQuest(questNum);

        switch (quest.State)
        {
            case QuestSystem.QuestState.BEFORE:
                dialogueView.SetCurrQuestState(questNum, true);
                dialogueView.SetDialogues(quest.BeforeDialogues);
                break;
            case QuestSystem.QuestState.CURR:
                dialogueView.SetCurrQuestState(questNum, false);
                dialogueView.SetDialogues(quest.CurrDialogues);
                break;
            case QuestSystem.QuestState.AFTER:
                dialogueView.SetCurrQuestState(questNum, false);
                dialogueView.SetDialogues(quest.AfterDialogues);
                break;
        }
    }

    public void AcceptQuest(int questNum)
    {
        QuestSystem.instance.QuestAccept(questNum);
    }




    // QuestInfoWindow 관련은 여기 밑에

    public void TogleQuestInfoWindow()
    {
        bool isActive = questInfoView.TogleQuestInfoWindow();

        if (isActive)
        {
            int[] arr = QuestSystem.instance.GetAcceptedQuest();
            string[] arr2 = new string[arr.Length];

            for (int i = 0; i < arr.Length; ++i)
            {
                arr2[i] = QuestSystem.instance.GetQuest(arr[i]).Mission;
            }

            questInfoView.Init(arr, arr2);
        }
    }

    public void EnableQuestInfoWindow(int questNum)
    {
        questInfoView.EnableQuestInfoWindow();
        questInfoView.SetQuest(QuestSystem.instance.GetQuest(questNum));
    }
}
