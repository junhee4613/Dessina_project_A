using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller_junhee : MonoBehaviour
{
    public Rigidbody rb;
    float boost_force;
    public float max_speed;
    Vector3 input_nomalize;
    public float min_speed;
    Collider[] sencer;
    public Animator an;
    public CapsuleCollider cc;
    public LayerMask interection_layer;

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
        input_nomalize = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        if (input_nomalize != Vector3.zero)
        {
            rb.velocity = new Vector3(input_nomalize.x, input_nomalize.y, 0) * boost;
            boost = Mathf.Clamp(boost + Time.deltaTime, min_speed, max_speed);
            if (Input.GetAxisRaw("Horizontal") != 0)
                transform.rotation = Quaternion.Euler(0, 90 * Input.GetAxisRaw("Horizontal"), 0);
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
   public void interection_obj()
    {
        sencer = Physics.OverlapCapsule(cc.bounds.min, cc.bounds.max, cc.radius, interection_layer);
        foreach (var item in sencer)
        {
            if(item.TryGetComponent<IInterection_obj>(out IInterection_obj obj))
            {
                obj.Interaction();
            }
            else
            {
                Die();
            }
            if(item.gameObject.layer == 6)
            {
                Managers.Pool.Push(item.gameObject);
            }
        }
    }
    public void Die()
    {
        Managers.GameManager.game_over = true;
    }
}
