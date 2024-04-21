using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailScene : MonoBehaviour
{
    public GameObject gameoverText;

    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GoExit()
    {
        Application.Quit();
    }
}
