using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {
    [SerializeField] KeyCode[] key;
    [SerializeField] string[] functionNames; 
    // Script for Interactable objects

    // private VARIABLES
    // [SerializeField] private string _interfaceName = "interface";

    public void OnAction() {
        for (int i = 0; i < key.Length; i++)
        {
            if (Input.GetKeyUp(key[i]))
            {
                gameObject.SendMessage(functionNames[i]);
            }
        }
    }
}
