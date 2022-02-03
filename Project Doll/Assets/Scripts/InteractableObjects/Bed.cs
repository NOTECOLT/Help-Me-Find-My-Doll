using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactables
{
    // Start is called before the first frame update
    public void EndNight()
    {
        if (EventFlagManager.Instance.GetFlagValue("dollCollected"))
        {
            Debug.Log("Epic");
        }
        else
        {
            Debug.Log(EventFlagManager.Instance.GetFlagValue("dollCollected"));
            Debug.Log("No doll");
        }
        //EventFlagManager.Instance.FlagTickTrue("chairDrag");
    }
}
