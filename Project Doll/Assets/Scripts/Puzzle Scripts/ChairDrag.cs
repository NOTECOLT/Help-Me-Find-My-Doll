using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairDrag : DraggableItem {
    public GameObject victoryText;

    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PuzzleDragTrigger") {
            enableMovement = false;
            EventFlagManager.Instance.FlagTickTrue("chairDrag");
        }
    }
}
