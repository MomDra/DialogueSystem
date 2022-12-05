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
            int questNum;
            instance = this;
            DialogueParser theParser = GetComponent<DialogueParser>();
            Dialogue[] dialogues = theParser.Parse(csv_FileName, out questNum);

            dialougeDic.Add(questNum, dialogues);

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
