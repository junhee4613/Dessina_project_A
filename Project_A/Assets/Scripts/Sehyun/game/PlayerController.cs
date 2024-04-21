using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody Player_rigidbody;
    float Speed = 5f;
    public float jump_force = 8f;
    public int Player_Hp = 100;
    public GameObject PauseScene;

    public LayerMask isGround;
    public LayerMask monsterLayer;

    public bool jump = false;
    public Animator anim;




    void Start()
    {
        Player_rigidbody = GetComponent<Rigidbody>();
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScene.GetComponent<PauseScene>().Pause();
        }
        if (transform.position.y <= -5 || Player_Hp <= 0)
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
        if (collision.gameObject.tag == "Right")
        {
            if (jump)
            {
                anim.SetBool("jump", false);
                jump = false;
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Player_Hp -= 20;
        }
        if (collision.gameObject.tag == "Boss")
        {
            Player_Hp -= 50;
        }
        if (collision.gameObject.tag == "Flag")
        {
            SceneManager.LoadScene("BossScene");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Player_Hp -= 50;
        }
    }

    void Player_Die()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("FailScene");
    }
}
