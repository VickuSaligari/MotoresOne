using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public Transform  rayPos;
    public float rayLength;
    
    [Header("Weapons")]
    public GameObject melee;
    public GameObject gun;
    public GameObject bug;
    public GameObject bomboclat;

    [Header("Interactions")]
    public float pickupRange = 1f;
    public LayerMask pickupLayer;

    [SerializeField] Transform _boxPosition;
    PickUpBox pickupBox;
    [SerializeField] private PickUpBox _currentBox;

    [SerializeField] Inputs inputs;

    [SerializeField] private int LayerNumber;

    private Ray ray;
    RaycastHit hit;
    private LayerMask mask;

    public void CheckForItemPickup()
    {
        Collider[] itemsInRange = Physics.OverlapSphere(transform.position, pickupRange, pickupLayer);

        foreach (Collider item in itemsInRange)
        {
            if (item.TryGetComponent(out PickUpBox box))
            {
                if (box == _currentBox) continue;
            }

            if (item.TryGetComponent(out Item itemComponent))
            {
                HandleItemPickup(itemComponent);
                break;
            }
        }
    }

    private void HandleItemPickup(Item item)
    {
        switch (item.itemType)
        {
            case ItemType.Stick:
                melee.SetActive(true);
                inputs.firstWeapon = melee.GetComponent<Weapons>();
                Destroy(item.gameObject);
                break;

            case ItemType.Gun:
                gun.SetActive(true);
                inputs.secondWeapon = gun.GetComponent<Weapons>();
                Destroy(item.gameObject);
                break;

            case ItemType.Box:
                if (_currentBox != null) return;
                item.transform.position = _boxPosition.position;
                item.transform.parent = _boxPosition;
                item.transform.rotation = Quaternion.Euler(Vector3.zero);
                _currentBox = item.GetComponent<PickUpBox>();
                Physics.IgnoreCollision(_currentBox.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
                break;
        }
    }


    public void CheckReff()
    {
        if (Physics.SphereCast(rayPos.position, 6, rayPos.forward, out hit, rayLength, LayerNumber))
        {
            ThrowObject();
        }
    }

    public void ThrowObject()
    {
        _currentBox.transform.position = _currentBox.correctBoxPos.transform.position;
        _currentBox.transform.rotation = _currentBox.correctBoxPos.transform.rotation;
        _currentBox.gameObject.layer = 7;
        
        Physics.IgnoreCollision(_currentBox.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        
        _currentBox.placed = true;
        CajaManager.instance.CheckIfPlaced();
        
        _currentBox.transform.parent = _currentBox.Parent;
        _currentBox = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}