using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFlagManager : MonoBehaviour {
    // SINGLETON PATTERN
    private static EventFlagManager _instance;
    public static EventFlagManager Instance { get {return _instance; } }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public event Action<string> onFlagTickTrue;
    public void FlagTickTrue(string flagName) {
        print("Flag Called: " + flagName);
        if (onFlagTickTrue != null)           
            onFlagTickTrue(flagName);
        else
            Debug.LogError("No Flag Listener with event name " + flagName);
            
    }
}
