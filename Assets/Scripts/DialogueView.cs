using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    [SerializeField]
    GameObject questWindow;

    [SerializeField]
    GameObject questTextPrefab;


    [SerializeField]
    GameObject dialogueWindow;
    Button[] dialogueWindowButtons;
    int dialoguesIndex;
    int contextIndex;
    Dialogue[] currDialogues;

    List<GameObject> addedGameObject;

    int currQuestNum;
    bool currQuestIsBefore;

    private void Awake()
    {
        addedGameObject = new List<GameObject>();

        dialogueWindowButtons = dialogueWindow.GetComponentsInChildren<Button>();
    }


    public void EnableQuestWindow()
    {
        dialogueWindow.SetActive(false);
        questWindow.SetActive(true);
    }

    public void EnableDialougeWindow()
    {
        questWindow.SetActive(false);
        dialogueWindow.SetActive(true);
    }

    public void EnableAcceptCloseButton()
    {
        dialogueWindowButtons[0].gameObject.SetActive(false);
        dialogueWindowButtons[1].gameObject.SetActive(true);
        dialogueWindowButtons[2].gameObject.SetActive(true);
    }

    public void EnableCloseButtonOnly()
    {
        dialogueWindowButtons[0].gameObject.SetActive(false);
        dialogueWindowButtons[1].gameObject.SetActive(true);
        dialogueWindowButtons[2].gameObject.SetActive(false);
    }

    public void EnableNextButton()
    {
        dialogueWindowButtons[0].gameObject.SetActive(true);
        dialogueWindowButtons[1].gameObject.SetActive(false);
        dialogueWindowButtons[2].gameObject.SetActive(false);
    }

    public void AddQuest(string questText, int questNum)
    {
        Transform imageTransform = questWindow.GetComponentInChildren<VerticalLayoutGroup>().transform;

        GameObject textObject = Instantiate(questTextPrefab, Vector3.zero, Quaternion.identity, imageTransform);
        textObject.GetComponent<TextMeshProUGUI>().text = questText;
        textObject.GetComponent<Button>().onClick.AddListener(() => OnClickQuestText(questNum));
        addedGameObject.Add(textObject);
    }

    public void SetDialogues(Dialogue[] dialogues)
    {
        currDialogues = dialogues;
        dialoguesIndex = 0;
        contextIndex = 0;
        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = $"{currDialogues[dialoguesIndex].name}: {currDialogues[dialoguesIndex].contexts[contextIndex]}";

        if (dialogues.Length <= 1 && dialogues[0].contexts.Length <= 1)
        {
            if (currQuestIsBefore)
            {
                EnableAcceptCloseButton();
            }
            else
            {
                EnableCloseButtonOnly();
            }

        }
        else
        {
            EnableNextButton();
        }
    }

    public void CloseQuestWindow()
    {
        QuestClear();
        questWindow.SetActive(false);
    }

    public void CloseDialogueWindow()
    {
        dialogueWindow.SetActive(false);
    }

    public void Next()
    {
        if (++contextIndex >= currDialogues[dialoguesIndex].contexts.Length)
        {
            contextIndex = 0;
            ++dialoguesIndex;
        }

        if (dialoguesIndex == currDialogues.Length - 1 && contextIndex == currDialogues[dialoguesIndex].contexts.Length - 1)
        {
            if (currQuestIsBefore)
            {
                EnableAcceptCloseButton();
            }
            else
            {
                EnableCloseButtonOnly();
            }
        }

        dialogueWindow.GetComponentInChildren<TextMeshProUGUI>().text = $"{currDialogues[dialoguesIndex].name}: {currDialogues[dialoguesIndex].contexts[contextIndex]}";
    }

    public void Accept()
    {
        UIController.Instance.AcceptQuest(currQuestNum);
        CloseDialogueWindow();
    }

    private void QuestClear()
    {
        foreach (GameObject var in addedGameObject)
        {
            Destroy(var);
        }

        addedGameObject.Clear();
    }

    public void OnClickQuestText(int questNum)
    {
        QuestClear();
        UIController.Instance.EnableDialogueWindow(questNum);
    }

    public void SetCurrQuestState(int questNum, bool isBefore)
    {
        currQuestNum = questNum;
        currQuestIsBefore = isBefore;
    }
}
