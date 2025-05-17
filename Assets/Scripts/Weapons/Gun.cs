using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapons
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private BulletPool bulletPool;

    public override void Attack()
    {
        IBullet bullet = bulletPool.GetBullet();

        if (bullet is MonoBehaviour monoBullet)
        {
            monoBullet.transform.position = bulletSpawn.position;
        }
    
        bullet.Shoot(bulletSpawn.forward);
    }
}