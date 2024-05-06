using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData; //�� ������ ���� �������� ũ�� ����
    [SerializeField]
    private GameObject enemyPrefab; //Enemy Prefab
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private float spawnTime; //���� �ֱ�

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private void Update()
    {

    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //x��ġ�� �������� ũ�� ���� ������ ������ ���� ����
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            //�� ���� ��ġ
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            //�� ĳ���� ����
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            //�� ü���� ��Ÿ���� Slider UI ���� �� ����
            SpawnEnemyHPSlider(enemyClone);

            //spawnTime��ŭ ���
            yield return new WaitForSeconds(spawnTime);
        }
    }
    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        //�� ü���� ��Ÿ���� Slider UI ����
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        //Slider UI ������Ʈ�� parent("Canvas" ������Ʈ)�� �ڽ����� ����
        //Tip. UI�� ĵ������ �ڽ� ������Ʈ�� �����Ǿ� �־�� ȭ�鿡 ���δ�
        sliderClone.transform.SetParent(canvasTransform);
        //���� �������� �ٲ� ũ�⸦ �ٽ� (1, 1, 1)�� ����
        sliderClone.transform.localScale = Vector3.one;

        //Slider UI�� �Ѿƴٴ� ����� �������� ����
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        //Slider UI�� �ڽ��� ü�� ������ ǥ���ϵ��� ����
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());

    }
    
   
}
