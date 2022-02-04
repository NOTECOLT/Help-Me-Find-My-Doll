using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] private string _interfaceName = "interface";
    [SerializeField] bool hasDialogue;
    DialogueCaller dialogueCaller;
    

    public void Start()
    {
        dialogueCaller = GetComponent<DialogueCaller>();
    }

    public void ShowInterface()
    {
        if (Input.GetKeyUp(KeyCode.E) && !PuzzleInterfaceManager.Instance.hasActiveInterface)
        {
            if (hasDialogue)
            {
                dialogueCaller.ShowDialogue();
            }  
            PuzzleInterfaceManager.Instance.ActivateInterface(_interfaceName);
        }
    }


    public void ChangeCurrentInterface(string interfaceName) {
        _interfaceName = interfaceName;
    }


}

