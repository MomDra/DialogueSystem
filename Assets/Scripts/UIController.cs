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

    TextMeshProUGUI text;
    Button nextButton;
    Button closeButton;


    Dialogue[] currDialogue;
    int dialogueIndex;
    int contextIndex;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        text = dialogueWindow.GetComponentInChildren<TextMeshProUGUI>();
        nextButton = dialogueWindow.GetComponentsInChildren<Button>()[0];
        closeButton = dialogueWindow.GetComponentsInChildren<Button>()[1];
        nextButton.onClick.AddListener(Next);
        closeButton.onClick.AddListener(Close);

        EnableNextButton();
    }

    public void EnableDialougeWindow(Dialogue[] dialogues)
    {
        currDialogue = dialogues;

        dialogueIndex = 0;
        contextIndex = 0;
        text.text = $"{currDialogue[0].name}: {currDialogue[0].contexts[0]}";
        dialogueWindow.SetActive(true);
        EnableNextButton();
    }

    private void Next()
    {
        if (++contextIndex >= currDialogue[dialogueIndex].contexts.Length)
        {
            contextIndex = 0;

            if (++dialogueIndex + 1 >= currDialogue.Length)
            {
                EnableCloseButton();
            }
        }

        text.text = $"{currDialogue[dialogueIndex].name}: {currDialogue[dialogueIndex].contexts[contextIndex]}";
    }

    private void EnableCloseButton()
    {
        nextButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }

    private void EnableNextButton()
    {
        nextButton.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(false);
    }

    private void Close()
    {
        dialogueWindow.SetActive(false);
    }
}
