using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogRunner : MonoBehaviour
{
    [SerializeField] DialogDisplayer dialogDisplayer;

    private bool continueScript;

    Queue<Speech> sentences;

    public SpeechList speechList;

    private void Start()
    {
        sentences = new Queue<Speech>();
        continueScript = false;
        dialogDisplayer.continueEvent.AddListener(DisplayNextSentence);
        StartDialogue(speechList);

        //StartCoroutine(DialogRoutineTest());
    }

    private void processScript()
    {
        continueScript = true;
    }

    private void StartDialogue( SpeechList speechList)
    {

        sentences.Clear();
        
        foreach(Speech s in speechList.Speeches )
        {
            sentences.Enqueue(s);
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
