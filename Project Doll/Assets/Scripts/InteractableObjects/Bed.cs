using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactables
{
    [SerializeField] string endFlag = "dollCollected";
    [SerializeField] SceneLoader sceneLoader;
    // Start is called before the first frame update

    public void EndNight()
    {
        if (EventFlagManager.Instance.GetFlagValue(endFlag))
        {
            sceneLoader.LoadNextScene();
        }
        else
        {
            Debug.Log(EventFlagManager.Instance.GetFlagValue(endFlag));
            Debug.Log("No doll");
        }
        //EventFlagManager.Instance.FlagTickTrue("chairDrag");
    }
}
