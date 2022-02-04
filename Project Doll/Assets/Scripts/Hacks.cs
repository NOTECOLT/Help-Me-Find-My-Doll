using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacks : MonoBehaviour
{
    [SerializeField] bool hacksOn = false;
    // Start is called before the first frame update
    public void HacksOn()
    {
        if (hacksOn)
        {
            Debug.Log("hacks are on");
            EventFlagManager.Instance.FlagTickTrue("puzzle1/keyAGet");
            

            EventFlagManager.Instance.FlagTickTrue("puzzle2/keyBGet");
            EventFlagManager.Instance.FlagTickTrue("puzzle3/keyCGet");
            EventFlagManager.Instance.FlagTickTrue("puzzle4/keyDGet");

            Debug.Log(EventFlagManager.Instance.GetFlagValue("puzzle1/keyAGet"));
        }
        
    }

}
