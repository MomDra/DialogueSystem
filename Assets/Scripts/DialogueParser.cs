using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public void ParseQuest(string _cSVFileName)
    {
        TextAsset csvData = Resources.Load<TextAsset>(_cSVFileName);
        string[] data = csvData.text.Split('\n');

        int numofQuest = data.Length / 6;

        for (int i = 0; i < numofQuest; ++i)
        {
            int no = int.Parse(data[i * 6 + 0].Split(',')[1]);
            string npc_name = data[i * 6 + 1].Split(',')[1];
            string mission = data[i * 6 + 2].Split(',')[1]; ;
            string reward = data[i * 6 + 3].Split(',')[1]; ;
            string description = data[i * 6 + 4].Split(',')[1];

            Dialogue[] beforeDialogues;
            Dialogue[] currDialogues;
            Dialogue[] afterDialogues;

            string dialogueCsvFileName = data[i * 6 + 5].Split(',')[1];
            ParseDialogue(dialogueCsvFileName, out beforeDialogues, out currDialogues, out afterDialogues);
            QuestSystem.Quest quest = new QuestSystem.Quest(no, npc_name, mission, reward, description, beforeDialogues, currDialogues, afterDialogues);
            QuestSystem.instance.AddQuest(quest);

            quest.PrintDebug();
        }
    }

    private void ParseDialogue(string _cSVFileName, out Dialogue[] beforeDialogues, out Dialogue[] currDialogues, out Dialogue[] afterDialogues)
    {
        List<Dialogue> beforeDialogueList = new List<Dialogue>();
        List<Dialogue> currDialogueList = new List<Dialogue>();
        List<Dialogue> afterDialogueList = new List<Dialogue>();

        _cSVFileName = _cSVFileName.Trim();

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

        beforeDialogues = beforeDialogueList.ToArray();
        currDialogues = currDialogueList.ToArray();
        afterDialogues = afterDialogueList.ToArray();
    }
}
