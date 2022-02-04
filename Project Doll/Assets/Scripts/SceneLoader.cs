using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadGameOverScene()
    {
        // Loads game over scene using build index
        SceneManager.LoadScene(2);
    }

    public void LoadNextScene()
    {
        // Loads next sceme
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        // Loads next sceme
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        // Loads next sceme
        Application.Quit();
    }

}
