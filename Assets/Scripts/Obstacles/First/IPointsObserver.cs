using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPointsObserver
{
    void OnPointsChanged(int newPoints);
}
