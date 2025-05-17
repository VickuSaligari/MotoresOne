using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour, IBulletPool
{
    [SerializeField] private int poolSize = 10;
    [SerializeField] private BulletFactory bulletFactory;

    private Queue<IBullet> bullets;

    private void Awake()
    {
        bullets = new Queue<IBullet>();

        for (int i = 0; i < poolSize; i++)
        {
            IBullet bullet = bulletFactory.CreateBullet();
            InitializeBullet(bullet);
            bullets.Enqueue(bullet);
        }
    }

    private void InitializeBullet(IBullet bullet)
    {
        if (bullet is Bullet concreteBullet)
        {
            concreteBullet.Initialize(this);
            concreteBullet.gameObject.SetActive(false);
        }
    }

    public IBullet GetBullet()
    {
        IBullet bullet = bullets.Count > 0 ? bullets.Dequeue() : bulletFactory.CreateBullet();

        if (bullet is Bullet concreteBullet && concreteBullet.gameObject.activeSelf == false)
        {
            concreteBullet.Initialize(this);
        }

        return bullet;
    }

    public void ReturnBullet(IBullet bullet)
    {
        if (bullet is Bullet concreteBullet)
        {
            concreteBullet.gameObject.SetActive(false);
        }

        bullets.Enqueue(bullet);
    }
}