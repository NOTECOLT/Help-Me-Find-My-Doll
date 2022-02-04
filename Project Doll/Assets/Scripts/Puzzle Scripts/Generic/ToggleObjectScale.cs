using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleObjectScale : MonoBehaviour {
    // Toggles the position of an object between its current position and an additional position
    private Vector2 _startScale;
    public Vector2 endScale;
    public bool toggleScale = false;
    public UnityEvent onTrueFunction;
    public UnityEvent onFalseFunction;
    void Start() {
        _startScale = GetComponent<RectTransform>().localScale;
    }

    public void ToggleScale() {
        toggleScale = (toggleScale) ? false : true;
        GetComponent<RectTransform>().localScale = (toggleScale) ? endScale : _startScale;
        if (toggleScale)
            onTrueFunction.Invoke();
        else
            onFalseFunction.Invoke();
    }
    
}
