using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inputs : MonoBehaviour
{
    [SerializeField] Interact interact;
    [SerializeField] Movement movement;
    public Weapons firstWeapon, secondWeapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact.CheckForItemPickup();

            Debug.Log("pressed E");
        }

        movement.MyInput();

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