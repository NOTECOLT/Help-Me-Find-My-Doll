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
        if (enableClicking)
            OnPointerDownFunction.Invoke(eventData);
    }
    public virtual void OnPointerUp(PointerEventData eventData) {
        if (enableClicking) {
            print(enableClicking);
            OnPointerUpFunction.Invoke(eventData);
        }
            
    }

    public void SetClicking(bool value) {
        enableClicking = value;
    }
}
