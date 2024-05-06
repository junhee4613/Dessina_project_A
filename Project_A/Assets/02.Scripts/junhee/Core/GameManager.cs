using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public Air_data air_data = new Air_data();
    public bool game_over = false;
    public float player_hp = 1;
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
    public Current_pattern current_pattern = new Current_pattern();
    public List<Bullet_base_data> bullet_mode = new List<Bullet_base_data>();
    public float record_time;
    public bool game_start = false;
}
public class Air_data
{
    public float air_spawn_current_time;
    public List<Air_level> air_Levels = new List<Air_level>();
}

public class Air_level 
{
    public float simple_air;
    public float air_spawn_time;
}
public class Current_pattern
{
    public List<Json_data> level = new List<Json_data>();
   
    public int num;
    public float bullet_spawn_current_time;
}
public class Json_data
{
    public int bullet_mode;
    public float next_level_time;
}
public class Bullet_base_data
{
    public float bullet_0_spawn_time;
    public float bullet_1_spawn_time;
    public float bullet_2_spawn_time;
}


