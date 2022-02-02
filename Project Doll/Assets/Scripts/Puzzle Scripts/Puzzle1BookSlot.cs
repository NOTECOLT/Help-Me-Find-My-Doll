using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle1BookSlot : DroppableSlot {
    private int _bookCount = 0;
    private List<GameObject> _bookSlots = new List<GameObject>();
    void Start() {
        foreach (Transform child in transform) {
            _bookSlots.Add(child.gameObject);
        }
    }
    public override void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 90);
            _bookCount += 1;

            // Makes Book immovable after being dropped
            eventData.pointerDrag.GetComponent<DraggableItem>().enableMovement = false;
            eventData.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = false;

            // Makes book child of book slot transform
            eventData.pointerDrag.transform.SetParent(_bookSlots[_bookCount - 1].transform, false);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            
            EventFlagManager.Instance.FlagTickTrue("puzzle1/book" + _bookCount + "Drag");
        }
    }  
}
