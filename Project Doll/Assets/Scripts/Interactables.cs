using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactables : MonoBehaviour {

    // Script for Interactable objects

    // private VARIABLES
    [SerializeField] private KeyCode[] _key = new KeyCode[] {KeyCode.E};
    [SerializeField] private UnityEvent[] _functions; 

    public void OnAction() {
        for (int i = 0; i < _key.Length; i++) {
            if (Input.GetKeyUp(_key[i]) && !PuzzleInterfaceManager.Instance.hasActiveInterface) {
                _functions[i].Invoke();
            }
        }
    }
}
