using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    private EnemyPath thePath;  // ���Ͱ� �������ִ� Path��
    private int currentPoint;
    private bool reachEnd;

    private void Start()
    {
        if(thePath == null)
        {
            thePath = FindObjectOfType<EnemyPath>(); // ��� ������Ʈ�� �˻��� ENEMY PATH�� ã�ƿ´�
        }
    }

    private void Update()
    {
        if(reachEnd == false) // if(!reachEnd0 ���� ����
        {
            transform.LookAt(thePath.points[currentPoint]); // ���ʹ� ���� ������ ���ؼ� ���� (look at)

            // moveTowerd �Լ� (�� ��ġ,Ÿ�� �ӵ�,�ӵ���)
            transform.position =
                Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < 0.01f)
            {
                currentPoint += 1; //���� ����Ʈ�� ����
                if(currentPoint >= thePath.points.Length) // ����Ʈ �迭������ ���� ��쿡�� �����Ϸ�
                {
                    reachEnd = true;
                }
            }
        }
        
    }

}
