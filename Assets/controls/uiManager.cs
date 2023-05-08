using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class uiManager : MonoBehaviour
{


    public void playGame()
    {
        SceneManager.LoadScene("testStage", LoadSceneMode.Single);


    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
