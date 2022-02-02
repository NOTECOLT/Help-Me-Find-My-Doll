using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickableItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    // Generic MonoBehaviour Class for items that are clickable.

    // PUBLIC VARIABLES
    public bool enableClicking = true;
    public UnityEvent<PointerEventData> OnPointerDownFunction;
    public UnityEvent<PointerEventData> OnPointerUpFunction;
    public virtual void OnPointerDown(PointerEventData eventData) {
        OnPointerDownFunction.Invoke(eventData);
    }
    public virtual void OnPointerUp(PointerEventData eventData) {
        OnPointerUpFunction.Invoke(eventData);
    }

    public void SetClicking(bool value) {
        enableClicking = value;
    }
}
