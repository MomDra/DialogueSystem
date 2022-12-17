using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem instance;


    // 여기가 모델이라고 해보자

    public class Quest
    {
        int no;
        string npc_name;
        string mission;
        string reward;
        string description;
        Dialogue[] beforeDialogues;
        Dialogue[] currDialogues;
        Dialogue[] afterDialogues;

        public int No { get => no; }
        public string Npc_name { get => npc_name; }
        public string Mission { get => mission; }
        public string Reward { get => reward; }
        public string Description { get => description; }
        public Dialogue[] Dialogues { get => beforeDialogues; }

        public Quest(int no, string npc_name, string mission, string reward, string description, Dialogue[] beforeDialogues, Dialogue[] currDialogues, Dialogue[] afterDialogues)
        {
            this.no = no;
            this.npc_name = npc_name;
            this.mission = mission;
            this.reward = reward;
            this.description = description;
            this.beforeDialogues = beforeDialogues;
            this.currDialogues = currDialogues;
            this.afterDialogues = afterDialogues;
        }

        public void PrintDebug()
        {
            Debug.Log("no: " + no);
            Debug.Log("npc_name: " + npc_name);
            Debug.Log("mission: " + mission);
            Debug.Log("Reward: " + reward);
            Debug.Log("description: " + description);
            Debug.Log("beforeDialogues: ");
            for (int i = 0; i < beforeDialogues.Length; ++i)
            {
                for (int j = 0; j < beforeDialogues[i].contexts.Length; ++j)
                {
                    Debug.Log(beforeDialogues[i].contexts[j]);
                }
            }

            Debug.Log("currDialogues: ");
            for (int i = 0; i < currDialogues.Length; ++i)
            {
                for (int j = 0; j < currDialogues[i].contexts.Length; ++j)
                {
                    Debug.Log(currDialogues[i].contexts[j]);
                }
            }

            Debug.Log("afterDialogues: ");
            for (int i = 0; i < afterDialogues.Length; ++i)
            {
                for (int j = 0; j < afterDialogues[i].contexts.Length; ++j)
                {
                    Debug.Log(afterDialogues[i].contexts[j]);
                }
            }
        }
    }

    Dictionary<int, Quest> currQuestDic = new Dictionary<int, Quest>();
    Dictionary<int, Quest> beforeQuestDic = new Dictionary<int, Quest>();
    Dictionary<int, Quest> afterQuestDic = new Dictionary<int, Quest>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }


    public void AddQuest(Quest quest)
    {

    }
}
