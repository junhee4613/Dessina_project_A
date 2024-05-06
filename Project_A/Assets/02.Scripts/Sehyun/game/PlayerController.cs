using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody Player_rigidbody;
    float Speed = 8f;
    public float jump_force = 10f;
    public int Player_Hp = 3;

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;

    public GameObject Boss;
    public GameObject Enemy;

    public bool jump = false;
    public Animator anim;

    public void Start()
    {
        Player_rigidbody = GetComponent<Rigidbody>();
        gameObject.SetActive(true);
        Life1.SetActive(true);
        Life2.SetActive(true);
        Life3.SetActive(true);
        Enemy.SetActive(true);
        Boss.SetActive(false);
        GameManager_SH.Instance.ReStart();
    }

    void Update()
    {
        Player_rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * Speed, Player_rigidbody.velocity.y, 0);
        
        if (!jump)
        {
            if (Player_rigidbody.velocity.x != 0 && !jump)
            {
                switch (Input.GetAxis("Horizontal"))
                {
                    case 1:
                        anim.SetInteger("anim", 1);
                        break;
                    case -1:
                        anim.SetInteger("anim", -1);
                        break;
                }
            }
            else
            {
                anim.SetInteger("anim", 0);
            } 
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && !jump)
        {
            jump = true;
            Player_rigidbody.velocity = new Vector3(Player_rigidbody.velocity.x, 0, 0);
            Player_rigidbody.AddForce(0, jump_force, 0, ForceMode.Impulse);
            anim.SetInteger("anim", 2);
            anim.SetBool("jump", true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager_SH.Instance.Pause();
        }

        switch (Player_Hp)
        {
            case 2:
                Life3.SetActive(false);
                break;
            case 1:
                Life2.SetActive(false);
                break;
            case 0:
                Life1.SetActive(false);
                break;
        }

        if (transform.position.y <= -15 || Player_Hp <= 0)
        {
            Player_Die();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if(jump)
            {
                anim.SetBool("jump", false);
                jump = false;
            }
        }
        if (collision.gameObject.tag == "Boss")
        {
            Player_Die();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Player_Hp -= 1;
        }
        if (other.gameObject.tag == "Enemy")
        {
            Player_Hp -= 1;
        }
        if (other.gameObject.tag == "Flag")
        {
            Boss.SetActive(true);
            gameObject.transform.position = new Vector3(280, 0.3f, 0);
        }
    }

    void Player_Die()
    {
        gameObject.SetActive(false);
        GameManager_SH.Instance.Fail();
    }
}
