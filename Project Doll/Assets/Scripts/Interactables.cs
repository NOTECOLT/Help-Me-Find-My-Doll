using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {
    // Script for Interactable objects

    // private VARIABLES
    [SerializeField] private string _interfaceName = "interface";

    public void ShowInterface() {
        if (Input.GetKeyDown(KeyCode.E))
            PuzzleInterfaceManager.Instance.ActivateInterface(_interfaceName);
    }
}
