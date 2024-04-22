using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailScene : MonoBehaviour
{
    public GameObject gameoverText;
    public GameObject Canvas_Fail;
    public string thisScene;

    private void Start()
    {
        Canvas_Fail.SetActive(false);
    }

    public void Over()
    {
        thisScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 0f;
        Canvas_Fail.SetActive(true);
    }
    public void GoToGame()
    {
        SceneManager.LoadSceneAsync(thisScene);
        Canvas_Fail.SetActive(false);
    }
    public void GoExit()
    {
        Application.Quit();
    }
}
