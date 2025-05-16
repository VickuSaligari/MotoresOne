using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletPool
{
    IBullet GetBullet();
    void ReturnBullet(IBullet bullet);
}
