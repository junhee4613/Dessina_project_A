using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed = 10f; //ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody;
    public GameObject Bullet;
    public Transform FirePos;
    // Start is called before the first frame update
    void Start()
    {
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        // ������ٵ��� �ӵ� = ������Ʈ�� �������� ���� ���� * �̵��ӷ�
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
