using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public ItemType itemType;
}

public enum ItemType
{
    Stick,
    Gun,
    Box
}