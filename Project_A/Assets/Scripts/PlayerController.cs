using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float moveSpeed = 5f;
    public float jumpForce = 5f;

    public int Hp = 100;

    public LayerMask isGround;
    public LayerMask monsterLayer;

    public bool isPlayerWatchingRight;
    public bool isJump = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if(transform.position.y <= -5 || Hp <= 0)
        {
            Die();
        }
        rb.velocity = new Vector3(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.UpArrow) && isJump)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            isJump = false;
        }
        if (Input.GetAxis("Horizontal") > 0)
        // 축이 양수 일때 (오른쪽을 바라보고 있을때)
        {
            isPlayerWatchingRight = true;
        }

        if (Input.GetAxis("Horizontal") < 0)
        // 축이 음수일때 (왼쪽을 바라보고 있을때)
        {
            isPlayerWatchingRight = false;
        }
        Debug.DrawRay(transform.position, Vector2.down * 1.38f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = true;
        }
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            Hp -= 10;
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
