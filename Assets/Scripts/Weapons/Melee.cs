using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapons
{
    Animator animator;
    [SerializeField] private string attackTrigger;
    [SerializeField] private int _normal = 20, _black = 10, _goldenn = 20;
    [SerializeField] Collider _collider;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
    }

    public void ToggleCollider(int value)
    {
        if (value >= 1) _collider.enabled = true;
        else _collider.enabled = false;
    }
    public override void Attack()
    {
      animator.SetTrigger(attackTrigger);
    }
}
