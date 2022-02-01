using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScript : MonoBehaviour
{
    public void TurnOn() {
        gameObject.GetComponent<TMP_Text>().enabled = true;
    }
}
