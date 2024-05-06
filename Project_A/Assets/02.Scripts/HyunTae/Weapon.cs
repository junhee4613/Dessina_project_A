using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab; //Prefab Spawn
    [SerializeField]
    private float attackRate = 0.1f; //���ݼӵ�

    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            //�߻�ü ������Ʈ ����
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            //attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }
}
