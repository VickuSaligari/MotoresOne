using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float dmg;
    public float attackSpeed;
    public float range;

    public virtual void Attack()
    {
        Debug.Log("Pow!");
    }
}
