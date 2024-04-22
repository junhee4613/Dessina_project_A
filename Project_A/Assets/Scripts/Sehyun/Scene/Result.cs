using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public GameObject gameoverText;
    public GameObject Canvas_Fail;
    // Start is called before the first frame update

    private void Start()
    {
        Canvas_Fail.SetActive(true);
    }
    public void GoToGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
        Canvas_Fail.SetActive(false);
    }
    public void GoExit()
    {
        Application.Quit();
    }
}
