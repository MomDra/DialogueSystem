using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionEvent : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    int[] questNumbers;

    public void OnPointerClick(PointerEventData eventData)
    {
        UIController.Instance.EnableQuestWindow(questNumbers);
    }
}
