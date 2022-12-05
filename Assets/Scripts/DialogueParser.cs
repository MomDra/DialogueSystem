using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName, out int _questNum)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split('\n');

        int questNum = int.Parse(data[1].Split(',')[0]);

        for (int i = 4; i < data.Length;)
        {
            string[] row = data[i].Split(',');
            Dialogue dialogue = new Dialogue();
            dialogue.name = row[0];
            List<string> dialougeTexts = new List<string>();

            Debug.Log(dialogue.name);

            do
            {
                dialougeTexts.Add(row[1]);
                Debug.Log(row[1]);

                ++i;
                if (i >= data.Length) break;

                row = data[i].Split(',');
            } while (row[0] == dialogue.name);

            dialogue.contexts = dialougeTexts.ToArray();
            dialogueList.Add(dialogue);
        }

        _questNum = questNum;
        return dialogueList.ToArray();
    }
}
