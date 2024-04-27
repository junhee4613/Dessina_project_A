using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller_junhee : MonoBehaviour
{
    public Rigidbody rb;
    public float boost_force;
    public float max_speed;

    // Start is called before the first frame update
    void Start()
    {
        if(max_speed == 0)
        {
            Debug.LogError("최대 스피드 제한을 설정 안했음");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Managers.GameManager.player_hp <= 0 && !Managers.GameManager.game_over)
        {
            Managers.GameManager.game_over = true;
            Die();
        }
        Boost(ref boost_force);
    }
    public void Boost(ref float boost)
    {
        if (Input.GetAxis("Horizontal") != 0|| Input.GetAxis("Vertical") != 0)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized * boost;
            boost = Mathf.Clamp(boost + Time.deltaTime, 0, max_speed);
        }
        else
        {
            boost = 0;
        }
    }
    public void Die()
    {

    }
}
