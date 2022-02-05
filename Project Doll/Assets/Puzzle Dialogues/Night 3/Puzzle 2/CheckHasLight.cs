using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHasLight : MonoBehaviour
{
    public void CheckLightOnKey()
    {
        if(EventFlagManager.Instance.GetFlagValue("puzzle2/blindsClose") && EventFlagManager.Instance.GetFlagValue("puzzle2/mirrorWorldMove"))
        {
            EventFlagManager.Instance.FlagTickTrue("puzzle2/hasLight");
        }
    }
}
