using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCaller : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] DialogueScriptableObject dialogueObject;
    [SerializeField] FloatingTextManagerUI floatingTextManagerUI;

    // Start is called before the first frame update
    public void ShowDialogue()
    {
        dialogueObject.QueueText();
        floatingTextManagerUI.ShowText(2f);
    }
}
