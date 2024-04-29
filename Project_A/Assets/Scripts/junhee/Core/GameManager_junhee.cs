using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_junhee : MonoBehaviour
{
    public static GameManager_junhee instance;
    public int player_hp;
    public bool game_over = false;
    public float air_drop_instance_time;
    float time;
    public float score;
    public List<GameObject> score_objs_pool = new List<GameObject>();
    public GameObject[] score_objs;
    public int probability;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        Air_instance();
    }
    public void Air_instance()
    {
        if (air_drop_instance_time <= time)
        {
            time = 0;
            int num = Random.Range(1, probability);
            if (num == 1)
            {
                foreach (var item in score_objs_pool)
                {
                    if (item.name == score_objs_pool[0].name)
                    {
                        if (item.activeSelf)
                        {
                            continue;
                        }
                        else
                        {
                            item.SetActive(true);
                            //item.transform.position = new Vector3(Random.Range(), Random.Range(), 0);
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {

            }
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
