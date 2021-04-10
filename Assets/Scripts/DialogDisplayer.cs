using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;

public enum Interlocutor
{
    None,
    Character1,
    Character2
}
public enum Images
{
    joker,
    joker_mom
}

public class DialogDisplayer : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text descriptionText, characterText, character1Name, character2Name;
    [SerializeField] Image p1Image, p2Image;

    private Interlocutor interlocutor = (Interlocutor)(-1);

    public UnityEvent continueEvent;

    private void Start()
    {

        if(continueEvent == null)
        {
            continueEvent = new UnityEvent();
        }


        SetInterlocutor(Interlocutor.None);
        SetText("");

    }
    public void SetImage(Images image)
    {
        if(image == Images.joker)
        {
            byte[] path = File.ReadAllBytes(Application.dataPath + "/Sprites/" + "/Characters/" + image.ToString() + ".jpg");

            Texture2D tex = new Texture2D(2,2);
            tex.LoadImage(path);
            p1Image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0), 100);
        }
    }

    public void SetText(string text)
    {
        switch (interlocutor)
        {
            case Interlocutor.None:
                descriptionText.text = text;

                break;
            case Interlocutor.Character1:
            case Interlocutor.Character2:
                characterText.text = text;
                break;
        }
    }

    public void SetName(string name)
    {
        switch (interlocutor)
        {
            case Interlocutor.Character1:
                character1Name.text = name;
                break;

            case Interlocutor.Character2:
                character2Name.text = name;
                break;
        }
    }

    public void SetInterlocutor(Interlocutor i)
    {
        if (interlocutor == i)
            return;

        interlocutor = i;

        switch (i)
        {
            case Interlocutor.None:
                character1Name.enabled = false;
                character2Name.enabled = false;
                p1Image.enabled = false;
                p2Image.enabled = false;
                characterText.enabled = false;
                descriptionText.enabled = true;
                break;

            case Interlocutor.Character1:
                character1Name.enabled = true;
                character2Name.enabled = false;
                p1Image.enabled = true;
                p2Image.enabled = false;
                characterText.enabled = true;
                descriptionText.enabled = false;
                break;

            case Interlocutor.Character2:
                character1Name.enabled = false;
                character2Name.enabled = true;
                p1Image.enabled = false;
                p2Image.enabled = true;
                characterText.enabled = true;
                descriptionText.enabled = false;
                break;
        }
    }

    public void CallContinueEvents()
    {
        continueEvent.Invoke();
        Debug.Log("Continue Event Called");
    }
}
