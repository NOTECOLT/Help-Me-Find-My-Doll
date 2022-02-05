using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    [SerializeField] float transitionTime = 1f;

    public void LoadGameOverScene()
    {
        // Loads game over scene using build index
        SceneManager.LoadScene(5);
    }

    public void LoadNextScene()
    {
        // Loads next sceme
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadLevelCoroutine(SceneManager.GetActiveScene().buildIndex + 1));
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

    IEnumerator LoadLevelCoroutine(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        // Wait for animation
        yield return new WaitForSeconds(transitionTime);

        // Load
        SceneManager.LoadScene(levelIndex);
    }
}
