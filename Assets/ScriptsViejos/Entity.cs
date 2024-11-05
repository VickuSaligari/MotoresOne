using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected float life;
    [SerializeField] protected float maxLife;
    [SerializeField] protected float speed;

    protected void Move(Vector3 target)
    {
        transform.position += (target - transform.position).normalized * Time.deltaTime * speed;
    }

    public virtual void Move()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    public abstract void Attack();
}
