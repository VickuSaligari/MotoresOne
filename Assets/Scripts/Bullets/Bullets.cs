using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullets : MonoBehaviour, IBullet
{
    private float speed = 20f;
    private IBulletPool pool;

    public void Initialize(IBulletPool bulletPool)
    {
        pool = bulletPool;
    }

    public void Shoot(Vector3 direction)
    {
        gameObject.SetActive(true);
        GetComponent<Rigidbody>().velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.SetActive(false);
        pool.ReturnBullet(this);
    }
}

