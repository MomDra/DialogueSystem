using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestInfoView : MonoBehaviour
{
    [SerializeField]
    GameObject questInfoListWindow;

    [SerializeField]
    GameObject questInfoWindow;


    [SerializeField]
    GameObject questTitleTextPrefab;

    List<GameObject> addedGameObject = new List<GameObject>();

    bool isActive;

    // public void AddQuest(string )
    // {
    //     Transform imageTransform = questInfoWindow.GetComponentInChildren<VerticalLayoutGroup>().transform;
    //     GameObject textObject = Instantiate(questTitleTextPrefab, Vector3.zero, Quaternion.identity, imageTransform);
    //     textObject.GetComponent<TextMeshProUGUI>().text = questTitleTextPrefab;
    //     textObject.GetComponent<Button>().onClick.AddListener(() => OnClickQuestText(questNum));
    //     addedGameObject.Add(textObject);
    // }

    public void EnableQuestInfoWindow()
    {
        questInfoListWindow.SetActive(false);
        questInfoWindow.SetActive(true);
    }

    public bool TogleQuestInfoWindow()
    {
        isActive = !isActive;
        questInfoListWindow.SetActive(isActive);
        questInfoWindow.SetActive(false);

        if (!isActive) Clear();

        return isActive;
    }

    public void Init(int[] questNums, string[] questMissions)
    {
        for (int i = 0; i < questNums.Length; ++i)
        {
            Transform imageTransform = questInfoListWindow.GetComponentInChildren<VerticalLayoutGroup>().transform;
            GameObject textObject = Instantiate(questTitleTextPrefab, Vector3.zero, Quaternion.identity, imageTransform);
            textObject.GetComponent<TextMeshProUGUI>().text = questMissions[i];
            int num = questNums[i];
            textObject.GetComponent<Button>().onClick.AddListener(() => OnClickQuestInfoText(num));
            addedGameObject.Add(textObject);
        }

    }

    private void OnClickQuestInfoText(int questNum)
    {
        Clear();
        UIController.Instance.EnableQuestInfoWindow(questNum);
    }

    private void Clear()
    {
        foreach (GameObject var in addedGameObject)
        {
            Destroy(var);
        }

        addedGameObject.Clear();
    }

    public void SetQuest(QuestSystem.Quest quest)
    {
        string text = string.Format($"NPC: {quest.Mission}\n\n퀘스트 요약: {quest.Mission}\n\n보상: {quest.Reward}\n\n임무 설명: {quest.Description}\n");

        questInfoWindow.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
}
