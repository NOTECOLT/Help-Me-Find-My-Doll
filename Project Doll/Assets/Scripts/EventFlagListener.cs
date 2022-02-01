using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventFlagListener : MonoBehaviour {
    void Start() {
        EventFlagManager.Instance.onFlagTickTrue += OnFlagTick;
    }

    public UnityEvent FlagFunction;
    public string flagNameRef;

    private void OnFlagTick(string flagName) {
        if (flagName == flagNameRef)
            FlagFunction.Invoke();
    }
}
