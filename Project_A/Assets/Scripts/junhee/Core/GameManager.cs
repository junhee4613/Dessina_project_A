using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public bool game_over = false;
    public float player_hp = 1;
    public float score = 0;
    GameObject player;
    public GameObject Player { 
        get 
        { 
            if(player == null)
            {
                player = GameObject.FindObjectOfType<Player_controller_junhee>().gameObject;
            }
            return player; 
        }
    }
}

