using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
    public GameObject Canvas_Pause;

    public string thisScene;
    // Start is called before the first frame update

    public void Start()
    {
        Canvas_Pause.SetActive(false);
    }
    public void Pause()
    {
        thisScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 0f;
        Canvas_Pause.SetActive(true);
    }
    public void ReStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(thisScene);
        Canvas_Pause.SetActive(false);
    }

    public void Continue() 
    {
        Canvas_Pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void End() 
    {
        Application.Quit();
    }
}
