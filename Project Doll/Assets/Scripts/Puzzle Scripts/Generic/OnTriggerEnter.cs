using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnter : MonoBehaviour {
    // Script that for when an object enters a trigger
    public UnityEvent<Collider2D> onTriggerFunction;
    public string colliderTag = "PuzzleDragTrigger";
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == colliderTag) {
            onTriggerFunction.Invoke(other);
        }
    }
}
