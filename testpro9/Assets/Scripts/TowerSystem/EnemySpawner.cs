using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController[] enemiesToSpawn;

    public Transform spawPoint;

    public float timeBetweenSpawns;  // ���� <- �ð� -> ����
    public float spawnCounter; // �ð��� �帣���ؼ� �����Ǵ� �ð� ����

    public int amountToSpawn = 15; // ���� �׷����

    private void Start()
    {
        spawnCounter = timeBetweenSpawns; // COUNTER�� �ð��� �Է�
    }

    private void Update()
    {
        if(amountToSpawn > 0) // ��ȯ�� ���� �׷��� �����ִٸ�
        {
            spawnCounter -= Time.deltaTime; // timeBetweenSpawns������ �ð����� -> 0.0�ʷ� ����
           if(spawnCounter <= 0)
           {
                spawnCounter = timeBetweenSpawns; // 0.0�� ������ ī���Ϳ� �ٽ� ������ �ð��� �Է��Ѵ�

                //enemytospawn�� ���� ���������� �� ��ȯ
                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawPoint.position, spawPoint.rotation);
                amountToSpawn -= 1; // ��ȯ�� ���ڸ� 1����

           }
        }
    }
}
