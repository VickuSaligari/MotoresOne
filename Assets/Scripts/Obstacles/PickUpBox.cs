using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PickUpBox : Item
{
    public GameObject correctBoxPos;
    public Transform Parent;
    
    public bool placed = false;
}