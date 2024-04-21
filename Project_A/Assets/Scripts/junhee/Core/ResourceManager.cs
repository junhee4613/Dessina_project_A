using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;
using UnityEngine.AddressableAssets;

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
    public GameObject Instantiate(string key, Transform parent = null, bool pooling = false)
    {
        GameObject prefab = Load<GameObject>($"{key}");
        if (prefab == null)
        {
            Debug.LogError($"Failed to load prefab : { key}");
            return null;
        }
        if (pooling)
            return Managers.Pool.Pop(prefab);
        GameObject go = Object.Instantiate(prefab, parent);

        go.name = prefab.name;
        return go;
    }
    public void Destroy(GameObject go)
    {
        if (go == null) return;
        if (Managers.Pool.Push(go)) return;

        Object.Destroy(go);
    }
    public void LoadAsync<T>(string key, Action<T> callback = null) where T : Object
    {
        string load_key = key;
        if (key.Contains(".sprite"))
            load_key = $"{key}[{key.Replace(".sprite", "")}]";

        var async_operation = Addressables.LoadAssetAsync<T>(load_key);

        async_operation.Completed += (op) =>
        {
            if (_resources.TryGetValue(key, out Object resource))
            {
                callback?.Invoke(op.Result);
                return;
            }

            _resources.Add(key, op.Result);
            callback?.Invoke(op.Result);
        };
    }
    public void Load_all_async<T>(string lable, Action<string, int, int> callback) where T : Object
    {
        var op_handle = Addressables.LoadResourceLocationsAsync(lable, typeof(T));

        op_handle.Completed += (op) =>
        {
            int load_count = 0;

            int total_count = op.Result.Count;

            foreach (var result in op.Result)
            {
                if (result.PrimaryKey.Contains(".sprite"))
                {
                    LoadAsync<Sprite>(result.PrimaryKey, (obj) =>
                    {
                        load_count++;
                        callback?.Invoke(result.PrimaryKey, load_count, total_count);
                    });
                }
                else
                {
                    LoadAsync<T>(result.PrimaryKey, (obj) =>
                    {
                        load_count++;
                        callback?.Invoke(result.PrimaryKey, load_count, total_count);
                    });
                }
            }
        };
    }
}
