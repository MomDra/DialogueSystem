using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{

    public static DatabaseManager instance;

    [SerializeField]
    string csv_FileName;


    Dictionary<int, Dialogue[]> dialougeDic = new Dictionary<int, Dialogue[]>();

    public static bool isFinish = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DialogueParser theParser = GetComponent<DialogueParser>();
            QuestSystem.Quest abc = theParser.ParseQuest(csv_FileName);

            isFinish = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Dialogue[] GetDialogue(int questNum)
    {
        return dialougeDic[questNum];
    }
}
