using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSessionManager : MonoBehaviour
{
    [SerializeField] float[] timePeriodsByPercentage;
    [SerializeField] FOVProfiles[] fovProfiles;
    [SerializeField] Text timeText;
    [SerializeField] bool allowGameEnd = false;

    // Cached references
    TimeManager timeManager;
    FOV fov;
    SceneLoader sceneLoader;

    // variables
    int timeIndex;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        timeManager = FindObjectOfType<TimeManager>();
        fov = FindObjectOfType<FOV>();
        fov.SetFOVSettings(fovProfiles[0].GetFOV(), fovProfiles[0].GetViewDistance());
        timeIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CycleThroughFOVProfile();
        SetTimeText();
        End();
    }

    private void CycleThroughFOVProfile()
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

    private void SetTimeText()
    {
        timeText.text = Mathf.RoundToInt(timeManager.GetTimeElapsedPercentage()).ToString() + "%";
    }

    private void End()
    {
        if (timeManager.GetTimeElapsedPercentage() >= 100 && allowGameEnd)
        {
            sceneLoader.LoadGameOverScene();
        }
    }
}
