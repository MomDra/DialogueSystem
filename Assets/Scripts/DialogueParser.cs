using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public QuestSystem.Quest ParseQuest(string _cSVFileName)
    {
        TextAsset csvData = Resources.Load<TextAsset>(_cSVFileName);
        string[] data = csvData.text.Split('\n');

        int no = int.Parse(data[0].Split(',')[1]);
        string npc_name = data[1].Split(',')[1];
        string mission = data[2].Split(',')[1]; ;
        string reward = data[3].Split(',')[1]; ;
        string description = data[4].Split(',')[1];

        Dialogue[] beforeDialogues;
        Dialogue[] currDialogues;
        Dialogue[] afterDialogues;

        string dialogueCsvFileName = data[5].Split(',')[1];
        ParseDialogue(dialogueCsvFileName, out beforeDialogues, out currDialogues, out afterDialogues);

        return new QuestSystem.Quest(no, npc_name, mission, reward, description, beforeDialogues, currDialogues, afterDialogues);
    }

    public void ParseDialogue(string _cSVFileName, out Dialogue[] beforeDialogues, out Dialogue[] currDialogues, out Dialogue[] afterDialogues)
    {
        List<Dialogue> beforeDialogueList = new List<Dialogue>();
        List<Dialogue> currDialogueList = new List<Dialogue>();
        List<Dialogue> afterDialogueList = new List<Dialogue>();
        TextAsset csvData = Resources.Load<TextAsset>(_cSVFileName);

        string[] data = csvData.text.Split('\n');

        int numBeforeQuest = int.Parse(data[1].Split(',')[1]);

        for (int i = 3; i < numBeforeQuest + 3;)
        {
            string[] row = data[i].Split(',');
            Dialogue dialogue = new Dialogue();
            dialogue.name = row[0];
            List<string> dialogueText = new List<string>();

            do
            {
                dialogueText.Add(row[1]);
                ++i;
                if (i >= numBeforeQuest + 3) break;

                row = data[i].Split(',');
            } while (row[0] == dialogue.name);

            dialogue.contexts = dialogueText.ToArray();
            beforeDialogueList.Add(dialogue);
        }

        int numCurrQuest = int.Parse(data[numBeforeQuest + 3].Split(',')[1]);

        for (int i = numBeforeQuest + 4; i < numBeforeQuest + 4 + numCurrQuest;)
        {
            string[] row = data[i].Split(',');
            Dialogue dialogue = new Dialogue();
            dialogue.name = row[0];
            List<string> dialogueText = new List<string>();

            do
            {
                dialogueText.Add(row[1]);
                ++i;
                if (i >= numBeforeQuest + 4 + numCurrQuest) break;

                row = data[i].Split(',');
            } while (row[0] == dialogue.name);

            dialogue.contexts = dialogueText.ToArray();
            currDialogueList.Add(dialogue);
        }

        int numAfterQuest = int.Parse(data[numBeforeQuest + 4 + numCurrQuest].Split(',')[1]);

        for (int i = numBeforeQuest + 5 + numCurrQuest; i < numBeforeQuest + 5 + numCurrQuest + numAfterQuest;)
        {
            string[] row = data[i].Split(',');
            Dialogue dialogue = new Dialogue();
            dialogue.name = row[0];
            List<string> dialogueText = new List<string>();

            do
            {
                dialogueText.Add(row[1]);
                ++i;
                if (i >= numBeforeQuest + 5 + numCurrQuest + numAfterQuest) break;

                row = data[i].Split(',');
            } while (row[0] == dialogue.name);

            dialogue.contexts = dialogueText.ToArray();
            afterDialogueList.Add(dialogue);
        }

        // for (int i = 4; i < data.Length;)
        // {
        //     string[] row = data[i].Split(',');
        //     Dialogue dialogue = new Dialogue();
        //     dialogue.name = row[0];
        //     List<string> dialougeTexts = new List<string>();

        //     Debug.Log(dialogue.name);

        //     do
        //     {
        //         dialougeTexts.Add(row[1]);
        //         Debug.Log(row[1]);

        //         ++i;
        //         if (i >= data.Length) break;

        //         row = data[i].Split(',');
        //     } while (row[0] == dialogue.name);

        //     dialogue.contexts = dialougeTexts.ToArray();
        //     dialogueList.Add(dialogue);
        // }

        beforeDialogues = beforeDialogueList.ToArray();
        currDialogues = currDialogueList.ToArray();
        afterDialogues = afterDialogueList.ToArray();
    }
}
