using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestInfoView : MonoBehaviour
{
    [SerializeField]
    GameObject questInfoWindow;

    [SerializeField]
    GameObject questTitleTextPrefab;

    List<GameObject> addedGameObject;

    bool isActive;

    // public void AddQuest(string )
    // {
    //     Transform imageTransform = questInfoWindow.GetComponentInChildren<VerticalLayoutGroup>().transform;
    //     GameObject textObject = Instantiate(questTitleTextPrefab, Vector3.zero, Quaternion.identity, imageTransform);
    //     textObject.GetComponent<TextMeshProUGUI>().text = questTitleTextPrefab;
    //     textObject.GetComponent<Button>().onClick.AddListener(() => OnClickQuestText(questNum));
    //     addedGameObject.Add(textObject);
    // }

    public void TogleQuestInfoWindow()
    {
        isActive = !isActive;
        questInfoWindow.SetActive(isActive);

        if (isActive)
        {
            Init();
        }
    }

    private void Init()
    {

    }
}
