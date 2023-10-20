using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float range = 3.0f;
    public float fireRate = 1.0f;
    public LayerMask IsEnemy; // 레이엉 시스템으로 감지

    public Collider[] colliderInRange;

    public List<EnemyController> enemiesInRange = new List<EnemyController>(); // 사거리 안에 있는 적들 컴포넌트 리스트

    public float checkCounter;
    public float checkTime = 0.2f;

    public bool enemiesUpdate; // flag 값으로 체크 완료했는지 검추출

    // Start is called before the first frame update
    void Start()
    {
        checkCounter = checkTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdate = false;

        checkCounter -= Time.deltaTime;

        if(checkCounter <= 0)
        {
            checkCounter = checkTime;

            colliderInRange = Physics.OverlapSphere(transform.position, range, IsEnemy);

            enemiesInRange.Clear();

            foreach(Collider col in colliderInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }
            enemiesUpdate = true;
        }
    }
}
