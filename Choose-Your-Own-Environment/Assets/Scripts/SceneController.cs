using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController {
    public static void LoadLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

    public static void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public static void LoadEndScene()
    {
        SceneManager.LoadScene("End");
    }

    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static int ActiveScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
