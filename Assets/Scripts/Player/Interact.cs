using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject melee;  
    public GameObject gun; 
    public GameObject bug; 
    public GameObject bomboclat; 
    public float pickupRange = 2.0f;      
    public LayerMask pickupLayer;    
    
    [SerializeField] Inputs inputs;

    public void CheckForItemPickup()
    {
        Collider[] itemsInRange = Physics.OverlapSphere(transform.position, pickupRange, pickupLayer);

        foreach (Collider item in itemsInRange)
        {
            Item itemComponent = item.GetComponent<Item>();
            if (itemComponent != null)
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
                Destroy(item); 
                Debug.Log("stick.");
                break;
            case ItemType.Gun:
                gun.SetActive(true);
                inputs.secondWeapon = gun.GetComponent<Weapons>();
                Destroy(item); 
                Debug.Log("gun.");
                break;
        }
        Destroy(item.gameObject); 
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
