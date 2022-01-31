using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float timeLimit = 30f;
    [SerializeField] [Range(0, 20)] float timeScale = 1f;
    [SerializeField] bool allowGameEnd = false;

    // Variables
    [SerializeField] float timeRemaining; // serialized for debug purposes
    float timeElapsedPercentage;

    // Cached references
    GameSessionManager gameSessionManager;
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit;
        gameSessionManager = FindObjectOfType<GameSessionManager>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
        OnTimerEnd();
    }

    private void OnTimerEnd()
    {
        // variables on time
        timeElapsedPercentage = (1 - (timeRemaining / timeLimit)) * 100;
        //Debug.Log("Time percentage: " + timeElapsedPercentage);
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0 && allowGameEnd)
        {
            sceneLoader.LoadGameOverScene();
        }
    }

    public float GetTimeElapsedPercentage()
    {
        return timeElapsedPercentage;
    }
}
