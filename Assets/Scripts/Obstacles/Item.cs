using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { Stick, Gun }
    public ItemType itemType;

    public int rangeM = 4;
    public int rangeG = 12;
    
}
