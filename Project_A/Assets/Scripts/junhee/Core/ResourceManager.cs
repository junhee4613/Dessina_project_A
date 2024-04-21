using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Dictionary<string, Object> _resources = new Dictionary<string, Object>();

    public T Load<T>(string key) where T : Object
    {
        if(_resources.TryGetValue(key, out Object resource))
        {
            return resource as T;
        }
        if(typeof(T) == typeof(Sprite))
        {
            key = key + ".sprite";
            if(_resources.TryGetValue(key, out Object temp))
            {
                return temp as T;
            }
        }
        return null;
    }
    /*public GameObject Instantiate(string key, Transform parent = null, bool pooling = false)
    {
        GameObject prefab = Load<GameObject>($"{key}");
        if(prefab == null)
        {
            Debug.LogError($"Failed to load prefab : { key}");
            return null;
        }
        if (pooling)
            return Managers.Pool.Pop(prefab);
    }*/
}
