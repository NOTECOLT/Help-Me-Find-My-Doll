using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float timeLimit = 30f;
    [SerializeField] [Range(0, 20)] float timeScale = 1f;

    // Variables
    [SerializeField] float timeRemaining; // serialized for debug purposes
    float timeElapsedPercentage;

    // Cached references
    GameSessionManager gameSessionManager;
    

    // Start is called before the first frame update
    void Start()
    {
        // Cached reference setup
        gameSessionManager = FindObjectOfType<GameSessionManager>();

        timeRemaining = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
        CalculateTimeRemaining();
    }

    private void CalculateTimeRemaining()
    {
        // Calculates time percentage until time limit
        timeElapsedPercentage = (1 - (timeRemaining / timeLimit)) * 100;
        //Debug.Log("Time percentage: " + timeElapsedPercentage);
        timeRemaining -= Time.deltaTime;
    }

    public float GetTimeElapsedPercentage()
    {
        return timeElapsedPercentage;
    }
}
