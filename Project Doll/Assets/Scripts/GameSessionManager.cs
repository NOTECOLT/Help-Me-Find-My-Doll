using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    [SerializeField] float[] timePeriodsByPercentage;
    [SerializeField] FOVProfiles[] fovProfiles;

    // Cached references
    TimeManager timeManager;
    FOV fov;
    // variables
    int timeIndex;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        fov = FindObjectOfType<FOV>();
        fov.SetFOVSettings(fovProfiles[0].GetFOV(), fovProfiles[0].GetViewDistance());
        timeIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIndex < (timePeriodsByPercentage.Length))
        {
            if ((timeManager.GetTimeElapsedPercentage() >= timePeriodsByPercentage[timeIndex]))
            {
                fov.SetFOVSettings(fovProfiles[timeIndex].GetFOV(), fovProfiles[timeIndex].GetViewDistance());
                timeIndex++;
            }
        }
        
    }
}
