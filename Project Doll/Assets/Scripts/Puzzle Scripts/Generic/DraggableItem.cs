using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
    // Generic MonoBehaviour Class for draggable items.
    
    // PRIVATE VARIABLES
    [SerializeField] private Canvas _canvas;
    private RectTransform _rectTransform;

    // PUBLIC VARAIABLES
    public bool lockXAxis, lockYAxis = false; // Locking either axis will make it so you can only drag the object along the other
    public bool enableMovement = true;

    public float xMin, xMax = 0.0f;
    public float yMin, yMax = 0.0f;

    void Awake() {
        _rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData) {
        
    }

    public void OnDrag(PointerEventData eventData) {
        if (enableMovement) {
            // If either lockAxis variable is true, then set the respective delta to 0 
            float xDelta = (lockXAxis) ? 0 : eventData.delta.x / _canvas.scaleFactor;  
            float yDelta = (lockYAxis) ? 0 : eventData.delta.y / _canvas.scaleFactor;

            float xPos = Mathf.Clamp(_rectTransform.anchoredPosition.x + xDelta, xMin, xMax);
            float yPos = Mathf.Clamp(_rectTransform.anchoredPosition.y + yDelta, yMin, yMax);
            _rectTransform.anchoredPosition = new Vector2(xPos, yPos);
        }

    }

    public void OnEndDrag(PointerEventData eventData) {

    }

    public void OnPointerDown(PointerEventData eventData){
        
    }
}
