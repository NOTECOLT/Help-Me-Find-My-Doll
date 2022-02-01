using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadGameOverScene()
    {
        // Loads game over scene using build index
        SceneManager.LoadScene(1);
    }
}
