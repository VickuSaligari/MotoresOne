using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet 
{
    void Shoot(Vector3 direction);
    void ReturnToPool();
}
