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
        timeRemaining = timeLimit;
        gameSessionManager = FindObjectOfType<GameSessionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsedPercentage = (1 - (timeRemaining / timeLimit))*100;
        Debug.Log("Time percentage: " + timeElapsedPercentage);
        Time.timeScale = timeScale;
        timeRemaining -= Time.deltaTime;
    }

    private void OnTimerEnd()
    {

    }
}
