using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private BulletPool bulletPool;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IBullet bullet = bulletPool.GetBullet();

            if (bullet is MonoBehaviour monoBullet)
            {
                monoBullet.transform.position = firePoint.position;
            }

            //bullet.Shoot(firePoint.forward);
        }
    }
}



