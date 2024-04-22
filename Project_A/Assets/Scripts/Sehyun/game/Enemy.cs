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
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Right")
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        else if (other.gameObject.tag == "Left")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            FixedUpdate();
        }
    }
}
