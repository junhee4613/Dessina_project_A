using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public GameObject GameoverText;
    public GameObject TimeoverText;
    public GameObject TimeRadyText;
    public GameObject ClearText;
    public float GameTime;
    public Text Text;


    private bool isGameover;
    private bool isClear;
    
    void Start()
    {
        isGameover = false;
        isClear = false;
    }

    
    void Update()
    {
        GameTime -= Time.deltaTime;
        Text.text = "Time : " + (int)GameTime;

        if (GameTime <= 0)
        {
            TimeoverText.SetActive(true);
            Debug.Log("시간이 종류 되었습니다.");
            Text.gameObject.SetActive(false);
            TimeRadyText.gameObject.SetActive(false);


        }

        if(GameTime <= 10)
        {
            TimeRadyText.SetActive(true);
       

        }

        if (isGameover | isClear)
        {
            Text.gameObject.SetActive(false);
            TimeRadyText.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene2");
        }

        if(Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("MainScene2");
        }

    }
    public void GameOver()
    {
        isGameover = true;
        GameoverText.SetActive(true);
    }
    
    public void Clear()
    {
        isClear = true;
        ClearText.SetActive(true);
    }
}
