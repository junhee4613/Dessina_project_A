using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Managers : MonoBehaviour
{
    static Managers _instance;
    public static Managers instance { get { Init(); return _instance; } }
    private void Awake()
    {
        Resource.Load_all_async<Object>("PreLoad", (key, count, totalcount) => 
        {
            if(count == totalcount)
            {
                Init();
                GameManager.air_data.air_Levels = JsonConvert.DeserializeObject<List<Air_level>>(Managers.Resource.Load<TextAsset>("Air_json_data").text);
                GameManager.bullet_mode = JsonConvert.DeserializeObject<List<Bullet_base_data>>(Managers.Resource.Load<TextAsset>("Bullet_spawn_time_data").text);
                GameManager.current_pattern.level = JsonConvert.DeserializeObject<List<Json_data>>(Managers.Resource.Load<TextAsset>("Next_level_time_data").text);
                GameManager.game_start = true;
            }
        });
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
            UI.Init();
        }
    }
    private void Update()
    {
        if (!GameManager.game_over)
        {
            GameManager.record_time += Time.deltaTime;
            UI.record_time_text.text = "Time : " + Mathf.FloorToInt(GameManager.record_time);
        }
    }

    public static ResourceManager Resource { get { return instance?._resources; } }
    public static GameManager GameManager { get { return instance?._game; } }
    public static PoolManager Pool { get { return instance?._pool; } }
    public static UIManager UI { get { return instance?._ui; } }
    public static CameraManager CM { get { return instance?._cm; } }
    ResourceManager _resources = new ResourceManager();
    GameManager _game = new GameManager();
    PoolManager _pool = new PoolManager();
    UIManager _ui = new UIManager();
    CameraManager _cm = new CameraManager();
}
