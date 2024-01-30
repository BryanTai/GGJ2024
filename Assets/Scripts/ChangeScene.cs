using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject credits;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits?.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
