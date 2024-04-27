using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : MonoBehaviour
{

    public GameObject nodeLeft;
    public GameObject nodeRight;
    public bool leftBreak = false;
    void Start()
    {
        SetRandom();
    }
    public void Update()
    {
     //   if (Input.GetKeyDown(KeyCode.Space)) IsTouch();
     //   if (Input.GetKeyDown(KeyCode.R)) ResetNode();
    }
    public void SetRandom()
    {
        int randVal = Random.Range(0, 2);
        if (randVal == 1)
        {
            leftBreak = false;
        }
        else
        {
            leftBreak = true;
        }
    }
    public void IsTouch()
    {
        if (leftBreak == true)
        {
            nodeLeft.SetActive(false);
        }
        else
        {
            nodeRight.SetActive(false);
        }
    }
    public void ResetNode()
    {
        nodeLeft.SetActive(true);
        nodeRight.SetActive(true);
        SetRandom();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Player")
        {
            print("랜덤블럭과 충돌함");
            IsTouch();
            ResetNode();
        }
    }
}
