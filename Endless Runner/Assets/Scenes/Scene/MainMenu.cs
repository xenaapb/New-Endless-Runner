using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1); // All of these examples loads 'Level_0'
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}