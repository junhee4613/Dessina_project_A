using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed = 8; //ź�� �̵� �ӷ�
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
            //���� ���� ������Ʈ���� Player_controller ������Ʈ ��������
            EnemyController enemyController = other.GetComponent<EnemyController>();

            //�������κ��� Player_controller ������Ʈ�� �������� �� �����ߴٸ�
            if (enemyController != null)
            {
                //���� Player_controller ������Ʈ�� Die() �޼��� ����
                enemyController.Die();
            }
        }
    }
}
