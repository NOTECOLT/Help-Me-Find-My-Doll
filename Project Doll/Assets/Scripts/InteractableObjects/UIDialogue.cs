using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogue : Interactables
{
    [SerializeField] FloatingTextManagerUI floatingTextManagerUI;

    [TextArea(3, 5)]
    [SerializeField] string[] dialogue;
    [SerializeField] float textDuration = 2f;

    public void OnInteract()
    {
        floatingTextManagerUI.ShowText(textDuration);
    }
}
