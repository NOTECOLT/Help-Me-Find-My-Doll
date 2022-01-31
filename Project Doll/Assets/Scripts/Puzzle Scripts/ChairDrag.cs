using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairDrag : DraggableItem {
    // private Rigidbody2D _rb;
    public GameObject victoryText;

    // void Start() {
    //     _rb.GetComponent<Rigidbody2D>();
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PuzzleDragTrigger") {
            enableMovement = false;
            victoryText.SetActive(true);
        }
    }
}
