using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameoverText;

    private bool isGameover;
    
    void Start()
    {
        isGameover = false;
    }

    
    void Update()
    {

    }

    public void EndGame()
    {
        print("game over ¿¬°á");
        isGameover = true;
        GameoverText.SetActive(true);

    }
}
