using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_bullet : MonoBehaviour
{
    public float bullet_speed;
    float time;
    public float set_time;
    public Rigidbody rb;
    public bool guide_option;
    bool guided_start;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Bullet_move();
        Set_disappear();
    }
    public void Set_disappear()
    {
        if(set_time < time)
        {
            Managers.Pool.Push(gameObject);
        }
        else
        {
            time += Time.deltaTime;
        }
    }
    public void Bullet_move()
    {
        rb.velocity = transform.forward * bullet_speed;
        if(guide_option && time > 4 && !guided_start)
        {
            transform.rotation = Quaternion.LookRotation(Managers.GameManager.Player.transform.position - transform.position, Vector3.up);

            guided_start = true;
        }
    }
    private void OnDisable()
    {
        guided_start = false;
        time = 0;
    }
}
