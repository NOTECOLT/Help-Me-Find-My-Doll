using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FanBox : MonoBehaviour {
    private List<int> _refCombo = new List<int>() {4, 3, 2, 1};
    public List<int> currentCombo = new List<int>();
    public List<Vector3> rotationList = new List<Vector3>(5);

    public UnityEvent completionFunction;

    public void UpdateCombo(int value) {
        currentCombo.Add(value);
        if (value != _refCombo[currentCombo.Count - 1]) {
            print(_refCombo[currentCombo.Count - 1]);
            currentCombo.Clear();
        }

        GetComponent<RectTransform>().localRotation = Quaternion.Euler(rotationList[value]);

        if (currentCombo.Count == 4)
            completionFunction.Invoke();
    }
}
