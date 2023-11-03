using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speedMod = 1.0f;
    public float timeSinceStart = 0.0f;
    public bool modeEnd = true; // state ���� ���� bool


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

        if(modeEnd == false)
        {
            timeSinceStart -= Time.deltaTime;
            if (timeSinceStart <= 0.01)
            {
                speedMod = 1.0f;
                modeEnd = true;
            }

        }
        if(reachEnd == false) // if(!reachEnd0 ���� ����
        {
            transform.LookAt(thePath.points[currentPoint]); // ���ʹ� ���� ������ ���ؼ� ���� (look at)

            // moveTowerd �Լ� (�� ��ġ,Ÿ�� �ӵ�,�ӵ���)
            transform.position =
                Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime * speedMod);

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
    public void SetMode(float Value)
    {
        modeEnd = false;
        speedMod = Value;
        timeSinceStart = 2.0f;
    }

}
