using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject LaserBeam;
    private float EnemyTimer;
    private bool isShooting = false;

    void Update()
    {
        if (EnemyTimer > 0)
        {
            EnemyTimer -= Time.deltaTime;
        }

        else if (EnemyTimer <= 0)
        {
            if (isShooting == false)
            {
                isShooting = true;
                LaserBeam.SetActive(true);
            }

            else if (isShooting == true)
            {
                isShooting = false;
                LaserBeam.SetActive(false);

            }
            EnemyTimer = 2f;
        }
    }
}
