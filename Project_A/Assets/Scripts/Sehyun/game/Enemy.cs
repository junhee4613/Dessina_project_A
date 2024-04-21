using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Hp = 30;
    public float speed = 10f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.y <= -5 || Hp <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Right")
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        else if (collision.gameObject.tag == "Left")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            FixedUpdate();
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Hp -= 15;
        }
    }
    public void Die()
    {
        if (Hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
