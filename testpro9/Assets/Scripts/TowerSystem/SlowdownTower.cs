using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownTower : MonoBehaviour
{
    private Tower thisTower;

    private void Start()
    {
        thisTower = GetComponent<Tower>();
    }

    private void Update()
    {
        if (thisTower.enemiesUpdate)
        {
            if (thisTower.enemiesInRange.Count > 0)
            {

                foreach (EnemyController enemy in thisTower.enemiesInRange)
                {
                    enemy.SetMode(thisTower.fireRate);
                }
            }
        }
    }
}
