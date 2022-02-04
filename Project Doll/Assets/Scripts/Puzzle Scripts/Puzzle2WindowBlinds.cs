using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle2WindowBlinds : MonoBehaviour {
    [SerializeField] private ToggleObjectScale _window1;
    [SerializeField] private ToggleObjectScale _window2;
    public UnityEvent openCallFunction;
    public UnityEvent closeCallFunction;

    public void OutputWindowStatus() {
        if (_window1.toggleScale && _window2.toggleScale) {
            openCallFunction.Invoke();
        } else {
            closeCallFunction.Invoke();
        }
    }
}
