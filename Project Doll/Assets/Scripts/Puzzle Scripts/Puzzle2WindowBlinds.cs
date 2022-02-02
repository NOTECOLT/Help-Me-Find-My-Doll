using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle2WindowBlinds : MonoBehaviour {
    [SerializeField] private ToggleObjectPos _window1;
    [SerializeField] private ToggleObjectPos _window2;
    public UnityEvent openCallFunction;
    public UnityEvent closeCallFunction;

    public void OutputWindowStatus() {
        if (_window1.togglePos && _window2.togglePos) {
            openCallFunction.Invoke();
        } else {
            closeCallFunction.Invoke();
        }
    }
}
