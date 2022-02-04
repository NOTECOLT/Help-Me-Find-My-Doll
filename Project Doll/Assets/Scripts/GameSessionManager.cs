using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSessionManager : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float[] timePeriodsByPercentage;
    [SerializeField] Text timeText;
    [SerializeField] bool allowGameEnd = false;
    [SerializeField] TimeManager timeManager;
    [SerializeField] SceneLoader sceneLoader;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        SetTimeText();
        End();
    }

    private void SetTimeText()
    {
        timeText.text = Mathf.RoundToInt(timeManager.GetTimeElapsedPercentage()).ToString() + "%";
    }

    private void End()
    {
        // Loads end scene after time limit
        if (timeManager.GetTimeElapsedPercentage() >= 100 && allowGameEnd)
        {
            sceneLoader.LoadGameOverScene();
        }
    }
}
