using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollect()
    {
        EventFlagManager.Instance.FlagTickTrue("dollCollected");
        Debug.Log(EventFlagManager.Instance.GetFlagValue("dollCollected"));
        //Destroy(gameObject);
    }
}
