using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

class Pool
{
    GameObject _prefabs;
    IObjectPool<GameObject> _pool;

    Transform _root;
    Transform Root
    {
        get
        {
            if(_root == null)
            {
                GameObject go = new GameObject() { name = $"@{_prefabs.name}Pool" };
                _root = go.transform;
            }
            return _root;
        }
    }
    public Pool(GameObject prefab)
    {
        _prefabs = prefab;
        _pool = new ObjectPool<GameObject>(OnCreate, OnGet);
    }
    public void Push(GameObject go)
    {
        if (go.activeSelf)
            _pool.Release(go);
    }
    public GameObject Pop()
    {
        return _pool.Get();
    }
    GameObject OnCreate()
    {
        GameObject go = GameObject.Instantiate(_prefabs);
        go.transform.SetParent(Root);
        go.name = _prefabs.name;
        return go;
    }
    void OnGet(GameObject go)
    {
        go.SetActive(true);
    }
    void OnRelease(GameObject go)
    {

    }
}
public class PoolManager : MonoBehaviour
{
    Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();
}
