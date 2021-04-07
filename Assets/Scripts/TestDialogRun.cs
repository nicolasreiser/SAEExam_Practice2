using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogRun : MonoBehaviour
{
    [SerializeField] DialogDisplayer dialogDisplayer;

    private void Start()
    {
        StartCoroutine(DialogRoutine());
    }

    private IEnumerator DialogRoutine()
    {
        Debug.Log("Run Test");
        yield return new WaitForSeconds(1);
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("DESCRIPTION");

        yield return new WaitForSeconds(1);

        dialogDisplayer.SetInterlocutor(Interlocutor.Character1);
        dialogDisplayer.SetName("Character1");
        dialogDisplayer.SetText("Hi i'm character 1");

        yield return new WaitForSeconds(1);

        dialogDisplayer.SetInterlocutor(Interlocutor.Character2);
        dialogDisplayer.SetName("Character2");
        dialogDisplayer.SetText("Hi i'm character 2");

        yield return new WaitForSeconds(1);
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("DESCRIPTION");
    }

}
