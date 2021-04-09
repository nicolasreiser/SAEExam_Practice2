using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogRunner : MonoBehaviour
{
    [SerializeField] DialogDisplayer dialogDisplayer;

    private void Start()
    {
        StartCoroutine(DialogRoutineTest());
    }

    private IEnumerator DialogRoutineTest()
    {
        Debug.Log("Running Test");
        yield return new WaitForSeconds(1);
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("Joker takes a deep breath, pauses to see if it's over.");

        yield return new WaitForSeconds(3);
        dialogDisplayer.SetText("Beat.");

        yield return new WaitForSeconds(2);
        dialogDisplayer.SetInterlocutor(Interlocutor.Character1);
        dialogDisplayer.SetName("JOKER");
        dialogDisplayer.SetText("is it just me, or is it getting crazier out there?");

        yield return new WaitForSeconds(4);
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("Despite the laughter, there's real pain in his eyes. Something broken in him.Looks like he hasn't slept in days.");

        yield return new WaitForSeconds(5);

        dialogDisplayer.SetInterlocutor(Interlocutor.Character2);
        dialogDisplayer.SetName("SOCIAL WORKER");
        dialogDisplayer.SetText("It's certainly tense. People are upset, they're struggling. Looking for work.The garbage strike seems like it's been going on forever.These are tough times.");

        yield return new WaitForSeconds(10);
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("");
    }

}
