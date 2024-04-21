using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
    }

}
