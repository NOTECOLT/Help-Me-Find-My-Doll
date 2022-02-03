using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeysComplete : MonoBehaviour {
    private int _keyCount = 0;
    public UnityEvent winningFunction;
    public void UpdateKeys() {
        _keyCount += 1;
        if (_keyCount == 4) {
            winningFunction.Invoke();
        }
    }
}
