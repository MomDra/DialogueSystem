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

    public void GetDialogue()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetDialogue();
        UIController.Instance.EnableDialougeWindow(dialogue.dialogues);
    }
}
