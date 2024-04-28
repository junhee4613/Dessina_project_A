using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller_junhee : MonoBehaviour
{
    public Rigidbody rb;
    float boost_force;
    public float max_speed;
    Vector3 nomalize_speed;
    public float min_speed;
    public Animator an;
    GameManager_junhee GameManager => GameManager_junhee.instance;

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
        if (GameManager.player_hp <= 0 && !GameManager.game_over)
        {
            GameManager.game_over = true;
            Die();
        }
        Boost(ref boost_force);
    }
    public void Boost(ref float boost)
    {
        nomalize_speed = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        if (nomalize_speed != Vector3.zero)
        {
            rb.velocity = new Vector3(nomalize_speed.x, nomalize_speed.y, 0) * boost;
            if(transform.rotation.y != 90 * nomalize_speed.x && Input.GetAxisRaw("Horizontal") != 0)
            {
                transform.rotation = Quaternion.Euler(0, 90 * Input.GetAxisRaw("Horizontal"), 0);
            }
            boost = Mathf.Clamp(boost + Time.deltaTime, min_speed, max_speed);
            an.SetInteger("Action", 1);
            an.speed = (boost * 3) / max_speed;

        }
        else
        {
            an.SetInteger("Action", 0);
            an.speed = 1;
            rb.velocity = Vector3.zero;
            boost = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "junhee_interaction")
        {
            //게이지 차는 로직
            if(collision.gameObject.TryGetComponent<IScore_obj>(out IScore_obj score))
            {
                score.Interaction();
            }
            else
            {
                GameManager.player_hp -= 1;
            }
        }
    }
    public void Die()
    {
        //게임 오버 UI 띄우기
    }
}
