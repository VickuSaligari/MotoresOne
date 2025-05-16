using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoxObserver
{
    void OnBoxPlaced(PickUpBox box);
}
