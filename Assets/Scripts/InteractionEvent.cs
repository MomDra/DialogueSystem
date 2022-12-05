using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionEvent : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    DialogueEvent dialogue;
    [SerializeField]
    int questNum;

    public Dialogue[] GetDialogue()
    {
        dialogue.dialogues = DatabaseManager.instance.GetDialogue(questNum);
        return dialogue.dialogues;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetDialogue();
        UIManager.Instance.EnableDialougeWindow(dialogue.dialogues);
    }
}
