using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Main : MonoBehaviour
{
    

    // Start is called before the first frame update
    public void GameStart()
    {
        Loading.LoadScene("GameScene");
        Debug.Log("게임 시작");
    }
    public void End()
    {
        Application.Quit();
    }
}
