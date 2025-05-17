using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IAddPoints, IBullet
{
    private Rigidbody _rigidbody;
    private IBulletPool pool;

    [SerializeField] private float _force = 100f;
    [SerializeField] private int _normal = 10, _black = 20, _goldenn = 20;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if (_rigidbody != null)
            _rigidbody.velocity = Vector3.zero;
    }

    public void Initialize(IBulletPool bulletPool)
    {
        pool = bulletPool;
    }

    public void Shoot(Vector3 direction)
    {
        gameObject.SetActive(true);
        transform.forward = direction;
        _rigidbody.velocity = direction * _force;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Targets target))
        {
            switch (target.currentMode)
            {
                case Mode.Normal: target.Hit(_normal); break;
                case Mode.Black: target.Hit(_black); break;
                case Mode.Goldenn: target.Hit(_goldenn); break;
            }
        }

        ReturnToPool();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        _rigidbody.velocity = Vector3.zero;
        StartCoroutine(DeactivateAfterDelay(0.05f)); 
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
        pool.ReturnBullet(this);
    }
}
