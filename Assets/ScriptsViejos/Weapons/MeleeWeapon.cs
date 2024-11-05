using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public Collider attackCollider;


    public override void Attack()
    {
        base.Attack();
        attackCollider.enabled = true;
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(.5f);

        attackCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) return;

        IDamagable target = other.gameObject.GetComponent<IDamagable>();

        if (target != null)
        {
            target.ReciveDamage(dmg);
        }

        Enemy enemy = target as Enemy;

        if (enemy != null)
        {

        }
    }
}
