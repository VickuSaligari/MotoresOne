using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour, IBulletFactory
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform poolParent;

    public IBullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, poolParent);
        return bullet;
    }
}
