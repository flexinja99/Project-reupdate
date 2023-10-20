using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    private EnemyPath thePath;  // 몬스터가 가지고있는 Path값
    private int currentPoint;
    private bool reachEnd;

    private void Start()
    {
        if(thePath == null)
        {
            thePath = FindObjectOfType<EnemyPath>(); // 모든 오브젝트를 검사해 ENEMY PATH를 찾아온다
        }
    }

    private void Update()
    {
        if(reachEnd == false) // if(!reachEnd0 도달 이전
        {
            transform.LookAt(thePath.points[currentPoint]); // 몬스터는 지금 방향을 향해서 본다 (look at)

            // moveTowerd 함수 (내 위치,타겟 속도,속도값)
            transform.position =
                Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < 0.01f)
            {
                currentPoint += 1; //다음 포인트로 변경
                if(currentPoint >= thePath.points.Length) // 포인트 배열수보다 높을 경우에는 도착완료
                {
                    reachEnd = true;
                }
            }
        }
        
    }

}
