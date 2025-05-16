using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractuable
{
    [SerializeField] private TargetsManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (PointsManager.Instance.Points <= 200)
        {
            Interact(true);
        }
    }

    public void Interact(bool interacting)
    {
        manager.StartGame();
    }
}