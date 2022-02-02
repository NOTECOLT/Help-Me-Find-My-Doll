using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle1BookDrag : DraggableItem {
    private CanvasGroup _canvasGroup;
 
    protected override void Awake() {
        base.Awake();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void OnBeginDrag(PointerEventData eventData) {
        if (enableMovement) {
            base.OnBeginDrag(eventData);
            _canvasGroup.blocksRaycasts = false;
        }
    }

    public override void OnEndDrag(PointerEventData eventData) {
        if (enableMovement) {
            base.OnEndDrag(eventData);
            _canvasGroup.blocksRaycasts = true;
        }
    }

}
