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
    public Dictionary<string, GameObject> score_objs_pool = new Dictionary<string, GameObject>();
    public GameObject[] score_objs;
    public int probability;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(air_drop_instance_time <= time)
        {
            time = 0;
            int num = Random.Range(1, probability);
            /*if(num == 1)
            {
                foreach (var item in score_objs_pool)
                {
                    if (item.Key[score_objs[0].gameObject.name])
                }
                GameObject.Instantiate(score_objs)
            }
            else
            {

            }*/
        }
        else
        {
            time += Time.deltaTime;
        }
    }

}
