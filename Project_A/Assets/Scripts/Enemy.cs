using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public int Hp = 30;
    public float speed = 5f;
    Rigidbody rb;

    float rightMax = 10.0f;
    float leftMax = -10.0f;
    float currentPosition;
    float direction = 3.0f;

    Sequence sequence;
    Tween tween;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPosition = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        currentPosition += Time.deltaTime * direction;

        if (currentPosition >= rightMax)
        {

            direction *= -1;

            currentPosition = rightMax;

        }
        else if (currentPosition <= leftMax)
        {

            direction *= -1;

            currentPosition = leftMax;

        }
        transform.position = new Vector3(currentPosition, 0, 0);
        if (transform.position.y <= -5 || Hp <= 0)
        {
            Die();
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
