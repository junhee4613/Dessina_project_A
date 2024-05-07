using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class GameManager_SH : MonoBehaviour
{
    private static GameManager_SH instance;
    public static GameManager_SH Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject tempObj = GameObject.Find("GameManager");
                if (tempObj != null)
                {
                    instance = tempObj.GetComponent<GameManager_SH>();
                }
                else
                {
                    instance = new GameObject("GameManager").AddComponent<GameManager_SH>();
                }
            }
            return instance;
        }
    }


    
    public GameObject Canvas_Fail;
    public GameObject Canvas_Pause;
    public GameObject Canvas_Clear;

    public GameObject Player;

    public string thisScene;

    public Text timeText;
    public Text recordText;
    public GameObject NewRecord;
    public float bestTime;
    public bool isGameClear;

    [SerializeField] private float surviveTime;

    

    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;
        surviveTime = 0;
        Canvas_Pause.SetActive(false);
        Canvas_Fail.SetActive(false);
        Canvas_Clear.SetActive(false);
        bestTime = PlayerPrefs.GetFloat("BestTime");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameClear)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        }
    }

    public void ReStart()
    {
        surviveTime = 0f;
        isGameClear = false;
    }
    public void Clear()
    {
        isGameClear = true;
        bestTime = PlayerPrefs.GetFloat("BestTime");
        Canvas_Clear.SetActive(true);
        if (surviveTime < bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            NewRecord.SetActive(true);
        }
        else
        {
            NewRecord.SetActive(false);
        }

        recordText.text = "BestTime : " + (int)surviveTime;
    }
    public void Fail()
    {
        Canvas_Fail.SetActive(true);
    }

    public void Main()
    {
        Start();
        SceneManager.LoadScene("Main_scene");
        //Loading.LoadScene("Main_scene");
    }

    public void Pause()
    {
        Canvas_Pause.SetActive(true);
        thisScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Canvas_Pause.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void End()
    {
        SceneManager.LoadScene("Main_scene");
    }
}
