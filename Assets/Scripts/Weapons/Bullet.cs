using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IAddPoints, IBullet
{
   private Rigidbody _rigidbody;
    private IBulletPool pool;
    [SerializeField] private int _normal = 10, _black = 20, _goldenn = 20;
   [SerializeField] private float _force = 100f;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _rigidbody.AddForce(_force * transform.forward, ForceMode.Impulse);
      
      Destroy(gameObject, 6);
   }

    public void Initialize(IBulletPool bulletPool)
    {
        pool = bulletPool;
    }

    public void Shoot(Vector3 direction)
    {
        gameObject.SetActive(true);
        GetComponent<Rigidbody>().velocity = direction * _force;
    }

    public void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out Targets target))
      {
         switch (target.currentMode)
         {
            case Mode.Normal:
               target.Hit(_normal);
               break;
            
            case Mode.Black:
               target.Hit(_black);
               break;
            
            case Mode.Goldenn:
               target.Hit(_goldenn);
               break;
         }
      }
      Destroy(gameObject);
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
