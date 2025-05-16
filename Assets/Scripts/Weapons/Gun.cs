using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapons
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] private BulletPool bulletPool;

    public override void Attack()
    {
        Debug.Log($"el metodo attack si empezo");
        IBullet bullet = bulletPool.GetBullet();

        if (bullet is MonoBehaviour monoBullet)
        {
            monoBullet.transform.position = bulletSpawn.position;
        }

        bullet.Shoot(bulletSpawn.forward);
    }
    
    
}