using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleObjectPos : MonoBehaviour {
    // Toggles the position of an object between its current position and an additional position
    private Vector2 _startCoords;
    public Vector2 endCoords;
    public bool togglePos = false;
    public UnityEvent onTrueFunction;
    public UnityEvent onFalseFunction;
    void Start() {
        _startCoords = GetComponent<RectTransform>().anchoredPosition;
    }

    public void TogglePosition() {
        togglePos = (togglePos) ? false : true;
        GetComponent<RectTransform>().anchoredPosition = (togglePos) ? endCoords : _startCoords;
        if (togglePos)
            onTrueFunction.Invoke();
        else
            onFalseFunction.Invoke();
    }
    
}
