using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed = 8; //탄알 이동 속력
    private Rigidbody bulletRigidbody;
    public GameObject Bullet;
    public Transform FirePos;
    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 오브젝트의 기준으로 앞쪽 방향 * 이동속력
        bulletRigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            Destroy(bullet, 5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            gameObject.SetActive(false);
            //상대방 게임 오브젝트에서 Player_controller 컴포넌트 가져오기
            EnemyController enemyController = other.GetComponent<EnemyController>();

            //상대방으로부터 Player_controller 컴포넌트를 가져오는 데 성공했다면
            if (enemyController != null)
            {
                //상대방 Player_controller 컴포넌트의 Die() 메서드 실행
                enemyController.Die();
            }
        }
    }
}
