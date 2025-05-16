using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PickUpBox : Item
{
    public GameObject correctBoxPos;
    public Transform Parent;
    private IBoxObserver observer;

    public void RegisterObserver(IBoxObserver obs)
    {
        observer = obs;
    }

    public bool IsCorrectlyPlaced()
    {
        return transform.position == correctBoxPos.transform.position && itemType == correctBoxPos.GetComponent<Item>().itemType && GetComponent<Renderer>().material.color == correctBoxPos.GetComponent<Renderer>().material.color;
    }

    public void Place()
    {
        observer?.OnBoxPlaced(this);
    }
}