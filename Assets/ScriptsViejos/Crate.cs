using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour,IDamagable
{
    public float GetLife { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Health(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void ReciveDamage(float damage)
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
