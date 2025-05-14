using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inputs : MonoBehaviour
{
    [SerializeField] Interact interact;
    public Weapons firstWeapon, secondWeapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact.CheckForItemPickup();
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            interact.CheckReff();
            
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && firstWeapon != null)
        {
            firstWeapon.Attack();
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1) && secondWeapon != null)
        {
            secondWeapon.Attack();
        }
    }
}