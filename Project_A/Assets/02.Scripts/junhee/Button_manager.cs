using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_manager : MonoBehaviour
{
    public void Hyuntae_game()
    {
        SceneManager.LoadScene("Hyun_tae_game");
    }
    public void Sehyun_game()
    {
        SceneManager.LoadScene("Se_hyun_game");
    }
    public void Yoongo_game() 
    {
        SceneManager.LoadScene("Yoon_ho_game");
    }
    public void Junhee_game()
    {
        SceneManager.LoadScene("junhee_game");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
