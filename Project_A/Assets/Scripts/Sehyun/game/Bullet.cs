using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Boss")
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Left")
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Right")
        {
            gameObject.SetActive(false);
        }
    }
}
