using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialChairDrag : DraggableItem {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PuzzleDragTrigger") {
            enableMovement = false;
            EventFlagManager.Instance.FlagTickTrue("tutorial/chairDrag");
        }
    }
}
