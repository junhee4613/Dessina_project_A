using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers _instance;
    public static Managers instance { get { Init(); return _instance; } }
    private void Awake()
    {
        //Resource.
    }
    public static void Init()
    {
        if(_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            _instance = go.GetComponent<Managers>();
            DontDestroyOnLoad(go);
        }
    }

    public static ResourceManager Resource { get { return instance?._resources; } }
    public static GameManager GameManager { get { return instance?._game; } }
    public static PoolManager Pool { get { return instance?._pool; } }
    ResourceManager _resources = new ResourceManager();
    GameManager _game = new GameManager();
    PoolManager _pool = new PoolManager();
}
