using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    float moveSpeed = 5f;
    public float jumpForce = 5f;

    public int Hp = 100;

    public LayerMask isGround;
    public LayerMask monsterLayer;

    public bool Jump = false;
    public Animator an;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, 0);
        if (!Jump)
        {
            if (rb.velocity.x != 0 && !Jump)
            {
                switch (Input.GetAxis("Horizontal"))
                {
                    case 1:
                        an.SetInteger("anim", 1);
                        break;
                    case -1:
                        an.SetInteger("anim", -1);
                        break;
                }
            }
            else
            {
                an.SetInteger("anim", 0);
            } 
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && !Jump)
        {
            Debug.Log("มกวม");
            Jump = true;
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            an.SetInteger("anim", 2);
            an.SetBool("Jump", true);
        }
        if (transform.position.y <= -5 || Hp <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if(Jump)
            {
                an.SetBool("Jump", false);
                Jump = false;
            }
        }
        
        if (collision.gameObject.tag == "Enemy")
        {
            Hp -= 10;
        }
        if (collision.gameObject.tag == "Boss")
        {
            Hp -= 50;
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
