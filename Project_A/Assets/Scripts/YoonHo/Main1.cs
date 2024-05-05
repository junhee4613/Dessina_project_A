using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Main1 : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            SceneManager.LoadScene("GameScene2");
        }

        if (Input.GetKey(KeyCode.E))
        {
            // UnityEditor.EditorApplication.isPlaying = false;
            // Application.Quit();
           
        }
    }



}
