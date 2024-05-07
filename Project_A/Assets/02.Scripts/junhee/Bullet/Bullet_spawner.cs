using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using Random = UnityEngine.Random;

public class Bullet_spawner : MonoBehaviour
{
    float[] time = new float[3];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Managers.GameManager.game_start)
        {
            Level_method();
        }
    }
    public void Level_method()
    {
        switch (Managers.GameManager.current_pattern.level[Managers.GameManager.current_pattern.num].bullet_mode)
        {
            case 0:
                Level_0_mode();
                break;
            case 1:
                Level_1_mode();
                break;
            case 2:
                Level_2_mode();
                break;
            case 3:
                Level_0_mode();
                Level_1_mode();
                Level_2_mode();
                break;
        }
        if (Managers.GameManager.air_data.air_spawn_current_time >= Managers.GameManager.air_data.air_Levels[0].air_spawn_time)
        {
            Managers.Pool.Pop(Managers.Resource.Load<GameObject>("Air_ball")).transform.position = new Vector3(Random.Range(10, -10), Random.Range(3.5f, -3.5f), 0);
            Managers.GameManager.air_data.air_spawn_current_time = 0;
        }
        Managers.GameManager.air_data.air_spawn_current_time += Time.deltaTime;
        if (Managers.GameManager.current_pattern.level.Count - 1 > Managers.GameManager.current_pattern.num
            && Managers.GameManager.current_pattern.level[Managers.GameManager.current_pattern.num].next_level_time <= Managers.GameManager.record_time)
        {
            Managers.GameManager.current_pattern.num++;
        }
    }
    public void Level_0_mode()
    {
        if(Managers.GameManager.bullet_mode[0].bullet_0_spawn_time <= time[0])
        {
            time[0] = 0;
            GameObject temp = Managers.Pool.Pop(Managers.Resource.Load<GameObject>("Base_bullet"));
            temp.transform.position = Random_pos(Random.Range(0, 4));
            temp.SetActive(true);
            temp.transform.rotation = Quaternion.Euler(0, 90, 0);
            temp.transform.rotation = Quaternion.LookRotation(Managers.GameManager.Player.transform.position - temp.transform.position, Vector3.up);
        }
        time[0] += Time.deltaTime;
    }
    public void Level_1_mode()
    {
        if (Managers.GameManager.bullet_mode[0].bullet_1_spawn_time <= time[1])
        {
            time[1] = 0;
            GameObject temp = Managers.Pool.Pop(Managers.Resource.Load<GameObject>("Guided_bullet"));
            temp.transform.position = Random_pos(Random.Range(0, 4));
            temp.transform.rotation = Quaternion.Euler(0, 90, 0);
            temp.transform.rotation = Quaternion.LookRotation(Managers.GameManager.Player.transform.position - temp.transform.position, Vector3.up);
        }
        time[1] += Time.deltaTime;
    }
    public void Level_2_mode()
    {
        if (Managers.GameManager.bullet_mode[0].bullet_2_spawn_time <= time[2])
        {
            GameObject temp = Managers.Pool.Pop(Managers.Resource.Load<GameObject>("Barrage"));
            temp.transform.position = Random_pos(Random.Range(0, 4));
            temp.transform.rotation = Quaternion.Euler(0, 90, 0);
            temp.transform.rotation = Quaternion.LookRotation(Managers.GameManager.Player.transform.position - temp.transform.position, Vector3.up);
            time[2] = 0;
        }
        time[2] += Time.deltaTime;
    }
    public Vector3 Random_pos(int num)
    {
        switch (num)
        {
            case 0:
                Vector3 pos0 = new Vector3(Random.Range(15, -15), 9.5f, 0);
                return pos0;
            case 1:
                Vector3 pos1 = new Vector3(Random.Range(15, -15), -9.5f, 0);
                return pos1;
            case 2:
                Vector3 pos2 = new Vector3(15, Random.Range(9.5f, -9.5f), 0);
                return pos2;
            case 3:
                Vector3 pos3 = new Vector3(-15, Random.Range(9.5f, -9.5f), 0);
                return pos3;
            default:
                return Vector3.zero;
        }
    }
    /*public void Look_target(Transform bullet_pos, Vector3 target_pos)
    {
        Vector3 temp = new Vector3(bullet_pos.position.x - target_pos.x, bullet_pos.position.y - target_pos.y, bullet_pos.position.z - target_pos.z);
        bullet_pos.rotation = Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.Atan2(temp.x, temp.z), Mathf.Rad2Deg * Mathf.Atan2(temp.x, temp.y));
        Debug.Log(bullet_pos.rotation);
    }*/
}




