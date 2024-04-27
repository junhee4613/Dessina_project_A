using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed = 10f; //탄알 이동 속력
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject bullet = Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            Destroy(bullet, 5f);
        }
    }

}
