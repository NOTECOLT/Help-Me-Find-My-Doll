using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairDrag : DraggableItem {
    [SerializeField] private string _flagName = "chairDrag";
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PuzzleDragTrigger") {
            enableMovement = false;
            EventFlagManager.Instance.FlagTickTrue(_flagName);
        }
    }
}
