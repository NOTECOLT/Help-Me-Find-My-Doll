using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Puzzle Dialogue", fileName = "Puzzle Dialogue")]
public class DialogueScriptableObject : ScriptableObject
{
    [TextArea(3, 5)]
    [SerializeField] string[] dialogue;
    [SerializeField] string[] flagsToCheck;
    [SerializeField] bool[] ifShowOnTrue;
    [SerializeField] string isAccomplishedFlag;
    [SerializeField] bool[] nextDialogueAutomatically;
    // Start is called before the first frame update
    
    public string[] GetDefaultDialogue()
    {
        return dialogue;
    }

    public string GetIsAccomplishedFlag()
    {
        return isAccomplishedFlag;
    }

    public void QueueText()
    {
        FindObjectOfType<FloatingTextManagerUI>().ClearQueue();
        for (int i = 0; i < dialogue.Length; i++)
        {
            bool doCheck = EventFlagManager.Instance.GetFlagValue(flagsToCheck[i]);

            if(ifShowOnTrue[i] == doCheck)
            {
                // Debug.Log("queue");
                FindObjectOfType<FloatingTextManagerUI>().QueueText(dialogue[i]);
            }
        }
    }
}
