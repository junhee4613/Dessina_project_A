using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int Hp = 1000;
    public Rigidbody rb;

    public bool jump;
    public float jump_force = 57f;

    public float JumpRateMin = 1f;
    public float JumpRateMax = 2f;

    public float JumpRate;
    public float jumpAfterGround;

    public GameObject Fire;
    public Transform FirePos;
    private Transform target;


    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3.0f;

    private float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        jump = false;
        rb = GetComponent<Rigidbody>();
        timeAfterSpawn = 0f;
        jumpAfterGround = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        JumpRate = Random.Range(JumpRateMin, JumpRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        jumpAfterGround += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject fire = Instantiate(Fire, FirePos.transform.position, FirePos.transform.rotation);
            fire.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
        if (Hp <= 0)
        {
            gameObject.SetActive(false);
            GameManager_SH.Instance.Clear();
        }
        if (jumpAfterGround >= JumpRate && !jump)
        {
            jump = true;
            rb.AddForce(0, jump_force, 0, ForceMode.Impulse);
            JumpRate = Random.Range(JumpRateMin, JumpRateMax);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Hp -= 30;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = false;
        }
    }
}
