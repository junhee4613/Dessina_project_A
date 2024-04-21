using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller_junhee : MonoBehaviour
{
    public Rigidbody rb;
    public float boost_force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Managers.GameManager.player_hp <= 0 && !Managers.GameManager.game_over)
        {
            Managers.GameManager.game_over = true;
            Die();
        }
        Boost(boost_force);
    }
    public void Boost(float boost)
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * boost, rb.velocity.y, 0);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, Input.GetAxis("Vertical") * boost, 0);
        }
    }
    public void Die()
    {

    }
}
