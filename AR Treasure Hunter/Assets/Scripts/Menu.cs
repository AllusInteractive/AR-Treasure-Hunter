using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Build Index:
    // 0 - Menu
    // 1 - Basic Portal Scene

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToBasicPortalScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
