using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public enum Scenes
{
    Scene1,
    Scene2,
    Scene3,
    Scene4,
    Scene7,
    Scene9
}
public class DialogRunner : MonoBehaviour
{
    [SerializeField] DialogDisplayer dialogDisplayer;

    //task 2
    private bool continueScript;

    //task 3
    Queue<Speech> sentences;
    public SpeechList speechList;

    //task 4
    public Scenes sceneToPlay;
    List<string> fileLines;
    int currentLine;

    private void Start()
    {
        currentLine = 0;
        sentences = new Queue<Speech>();
        continueScript = false;
        LoadScriptFromFile(sceneToPlay);
        //dialogDisplayer.continueEvent.AddListener(DisplayNextSentence);
        dialogDisplayer.continueEvent.AddListener(DisplayNextLine);
        StartDialogue(speechList);

        //StartCoroutine(DialogRoutineTest());
    }

    private void processScript()
    {
        continueScript = true;
    }

    private void LoadScriptFromFile( Scenes SceneName)
    {
        string readFrimFilePath = Application.dataPath + "/Resources/" + "/Joker/" + SceneName.ToString() + ".txt";

        fileLines = File.ReadAllLines(readFrimFilePath).ToList();
    }
    private void StartDialogue( SpeechList speechList)
    {

        sentences.Clear();
        
        foreach(Speech s in speechList.Speeches )
        {
            sentences.Enqueue(s);
        }
    }
    public void DisplayNextLine()
    {
        
        if (fileLines[currentLine].Contains("<b>"))
        {
            // its the name of a character
            if(fileLines[currentLine].Contains("JOKER"))
            {
                dialogDisplayer.SetInterlocutor(Interlocutor.Character1);
                dialogDisplayer.SetImage(Images.joker);
                dialogDisplayer.SetName(fileLines[currentLine]);
            }
            else if (fileLines[currentLine].Contains("SOCIAL WORKER") ||
                fileLines[currentLine].Contains("KID") ||
                fileLines[currentLine].Contains("WOMAN") ||
                fileLines[currentLine].Contains("SOPHIE") ||
                fileLines[currentLine].Contains("MOM"))
            {
                dialogDisplayer.SetImage(Images.joker_mom);

                dialogDisplayer.SetInterlocutor(Interlocutor.Character2);
                dialogDisplayer.SetName(fileLines[currentLine]);
            }
            else
            {
                dialogDisplayer.SetInterlocutor(Interlocutor.None);
            }
            currentLine++;

            string text = "";

            while(!fileLines[currentLine].Equals(""))
            {
                text += fileLines[currentLine] + "\n";
                currentLine++;
            }
            
            dialogDisplayer.SetText(text);
            currentLine++;
        }
        else
        {
            dialogDisplayer.SetInterlocutor(Interlocutor.None);

            string text = "";

            while (!fileLines[currentLine].Equals(""))
            {
                text += fileLines[currentLine] + "\n";
                currentLine++;
            }

            dialogDisplayer.SetText(text);
            currentLine++;
        }
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
        }

        Speech speech = sentences.Dequeue();
        dialogDisplayer.SetInterlocutor(speech.interlocutor);
        dialogDisplayer.SetText(speech.script);
    }
    private void EndDialogue()
    {
        Debug.Log("Conversation finished");
    }
    private IEnumerator DialogRoutineTest()
    {
        yield return new WaitUntil( () => continueScript == true);
        continueScript = false;
        Debug.Log("Running Test");

        yield return new WaitUntil(() => continueScript == true);
        continueScript = false;
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("Joker takes a deep breath, pauses to see if it's over.");

        yield return new WaitUntil(() => continueScript == true);
        continueScript = false;
        dialogDisplayer.SetText("Beat.");

        yield return new WaitUntil(() => continueScript == true);
        continueScript = false;
        dialogDisplayer.SetInterlocutor(Interlocutor.Character1);
        dialogDisplayer.SetName("JOKER");
        dialogDisplayer.SetText("is it just me, or is it getting crazier out there?");

        yield return new WaitUntil(() => continueScript == true);
        continueScript = false;
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("Despite the laughter, there's real pain in his eyes. Something broken in him.Looks like he hasn't slept in days.");

        yield return new WaitUntil(() => continueScript == true);
        continueScript = false;
        dialogDisplayer.SetInterlocutor(Interlocutor.Character2);
        dialogDisplayer.SetName("SOCIAL WORKER");
        dialogDisplayer.SetText("It's certainly tense. People are upset, they're struggling. Looking for work.The garbage strike seems like it's been going on forever.These are tough times.");

        yield return new WaitUntil(() => continueScript == true);
        continueScript = false;
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("");
    }

}
