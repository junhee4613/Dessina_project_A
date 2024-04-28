using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_controller : MonoBehaviour
{
    int dir = -1;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        if(Mathf.Abs(transform.position.x) >= 100)
        {
            dir = Random.Range(0, 2) == 1 ? -1 : 1;
            transform.rotation = Quaternion.Euler(0, 90 * dir, 0);
            transform.position = new Vector3(Random.Range(55, 85), 0, 0);
        }
    }
}
