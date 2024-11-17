using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapons
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn;

    public override void Attack()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }
    
    
}