using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrage : MonoBehaviour
{
    public float bullet_speed;
    float time;
    public Rigidbody rb;
    private void Update()
    {
        rb.velocity = transform.forward * bullet_speed;
        if (time > 3)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject temp = Managers.Pool.Pop(Managers.Resource.Load<GameObject>("Base_bullet"));
                temp.transform.position = transform.position;
                temp.transform.rotation = Quaternion.Euler(45 * i, 90, 0);
            }
            Managers.Pool.Push(gameObject);
        }
        else
        {
            time += Time.deltaTime;
        }
    }
    private void OnDisable()
    {
        time = 0;
    }

}
