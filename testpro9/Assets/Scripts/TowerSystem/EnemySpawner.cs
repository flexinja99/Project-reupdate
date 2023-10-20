using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController[] enemiesToSpawn;

    public Transform spawPoint;

    public float timeBetweenSpawns;  // 스폰 <- 시간 -> 스폰
    public float spawnCounter; // 시간을 흐르게해서 스폰되는 시간 설정

    public int amountToSpawn = 15; // 스폰 그룹숫자

    private void Start()
    {
        spawnCounter = timeBetweenSpawns; // COUNTER에 시간을 입력
    }

    private void Update()
    {
        if(amountToSpawn > 0) // 소환할 몬스터 그룹이 남아있다면
        {
            spawnCounter -= Time.deltaTime; // timeBetweenSpawns설정한 시간에서 -> 0.0초로 간다
           if(spawnCounter <= 0)
           {
                spawnCounter = timeBetweenSpawns; // 0.0초 이하인 카운터에 다시 설정한 시간을 입력한다

                //enemytospawn을 통해 랜덤값으로 적 소환
                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawPoint.position, spawPoint.rotation);
                amountToSpawn -= 1; // 소환후 숫자를 1빼줌

           }
        }
    }
}
