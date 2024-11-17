using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
   private Rigidbody _rigidbody;
   [SerializeField] private int _normal = 20, _black = 10, _goldenn = 20;
   [SerializeField] private float _force = 100f;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _rigidbody.AddForce(_force * transform.forward, ForceMode.Impulse);
      
      Destroy(gameObject, 6);
   }

   private void OnTriggerEnter(Collider other)
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
}
