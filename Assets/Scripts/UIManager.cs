using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance { get => instance; }

    [SerializeField]
    GameObject dialogueWindow;

    TextMeshProUGUI text;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        text = dialogueWindow.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(text.name);
    }

    public void EnableDialougeWindow(Dialogue[] dialogues)
    {
        dialogueWindow.SetActive(true);
    }
}
