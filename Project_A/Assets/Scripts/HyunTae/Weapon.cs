using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab; //Prefab Spawn
    [SerializeField]
    private float attackRate = 0.1f; //공격속도

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
            //발사체 오브젝트 생성
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            //attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }
}
