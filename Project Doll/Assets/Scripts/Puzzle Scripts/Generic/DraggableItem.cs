using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DraggableItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
    // Generic MonoBehaviour Class for draggable items.
    
    // PRIVATE VARIABLES
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    protected RectTransform _rectTransform;

    // PUBLIC VARAIABLES
    public bool lockXAxis, lockYAxis = false; // Locking either axis will make it so you can only drag the object along the other
    public bool enableMovement = true;

    public float xMin, xMax = 0.0f;
    public float yMin, yMax = 0.0f;

    public UnityEvent<PointerEventData> onBeginDragFunction;
    public UnityEvent<PointerEventData> onEndDragFunction;


    protected virtual void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start() {
        _canvas = GetComponentInParent<Canvas>();
    }
    public virtual void OnBeginDrag(PointerEventData eventData) {
        if (enableMovement)
            onBeginDragFunction.Invoke(eventData);
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

    public virtual void OnEndDrag(PointerEventData eventData) {
        if (enableMovement)
            onEndDragFunction.Invoke(eventData);
    }

    public void OnPointerDown(PointerEventData eventData){
        
    }

    public void SetMovement(bool value) {
        enableMovement = value;
    }

    public void SetRaycastBlocking(bool value) {
        _canvasGroup.blocksRaycasts = value;
    }
}
