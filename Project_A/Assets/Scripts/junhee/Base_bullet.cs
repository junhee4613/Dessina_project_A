using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_bullet : MonoBehaviour,IInterection_obj
{
    public float bullet_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bullet_move();
    }
    public void Bullet_move()
    {
        transform.Translate(transform.forward * bullet_speed * Time.deltaTime);
    }
    private void OnEnable()
    {
        transform.LookAt(Managers.GameManager.Player.transform);
    }

    public void Interaction()
    {
        Managers.Pool.Push(gameObject);
    }
}
