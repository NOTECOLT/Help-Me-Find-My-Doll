using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    [SerializeField] private string _interfaceName = "interface";

    public void ShowInterface()
    {
        if (Input.GetKeyUp(KeyCode.E) && !PuzzleInterfaceManager.Instance.hasActiveInterface)
            PuzzleInterfaceManager.Instance.ActivateInterface(_interfaceName);
    }

    public void ChangeCurrentInterface(string interfaceName) {
        _interfaceName = interfaceName;
    }
}

