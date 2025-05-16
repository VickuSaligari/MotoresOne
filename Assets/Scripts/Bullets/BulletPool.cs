using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletPool : MonoBehaviour, IBulletPool
{
    [SerializeField] private Bullets bulletPrefab;
    [SerializeField] private int poolSize = 10;

    private Queue<IBullet> bullets;

    private void Awake()
    {
        bullets = new Queue<IBullet>();
        for (int i = 0; i < poolSize; i++)
        {
            Bullets newBullet = Instantiate(bulletPrefab, transform);
            newBullet.Initialize(this);
            newBullet.gameObject.SetActive(false);
            bullets.Enqueue(newBullet);
        }
    }

    public IBullet GetBullet()
    {
        if (bullets.Count > 0)
        {
            return bullets.Dequeue();
        }

        Bullets extraBullet = Instantiate(bulletPrefab, transform);
        extraBullet.Initialize(this);
        extraBullet.gameObject.SetActive(false);
        return extraBullet;
    }

    public void ReturnBullet(IBullet bullet)
    {
        bullets.Enqueue(bullet);
    }
}

