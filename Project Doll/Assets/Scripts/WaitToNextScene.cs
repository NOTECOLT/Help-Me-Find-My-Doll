using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitToNextScene : MonoBehaviour {
    // Start is called before the first frame update
    public int time = 1;
    public UnityEvent doFunction;
    void Start() {
       StartCoroutine(WaitUntilNextScene());
    }

    IEnumerator WaitUntilNextScene() {
        print("start");
        yield return new WaitForSeconds(time);

        doFunction.Invoke();
        print("next");
    }
}
