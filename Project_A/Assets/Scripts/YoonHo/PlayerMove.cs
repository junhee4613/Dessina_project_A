using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;

    bool jump_anim;

    Vector3 moveVec;

    Rigidbody rb; // �ɸ��͸� �����̱� ���� ����
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

    }
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
  
    }


    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump() // ����
    {
        if (Input.GetButtonDown("Jump")) // ! ������ bool ���� ����
        {
            anim.SetTrigger("isJump");
          
            StartCoroutine(Jump_anim());
        }
        
    }
    IEnumerator Jump_anim()
    {
        yield return null;
        while (!jump_anim) 
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.2f)
            {
                jump_anim = true;
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
            yield return null;
        }
        yield return null;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Game field")
        {
            jump_anim = false;
        }
        if (collision.gameObject.tag == "Finish Box")
        {
            gameObject.SetActive(false);
            GameManager1 gameManager = FindAnyObjectByType<GameManager1>();
            gameManager.Clear();
            gameObject.SetActive(false);
            print("�������� Ŭ����");
        }
        if (collision.gameObject.tag == "Plane")
        {
            GameManager1 gameManager = FindAnyObjectByType<GameManager1>();
            gameManager.GameOver();
            gameObject.SetActive(false);
            print("Game Over");
        }
        if(collision.gameObject.tag == "Nonobox")
        {
            print("���� ť�� �Դϴ�.");
            Destroy(collision.gameObject);
        }
    }
}
