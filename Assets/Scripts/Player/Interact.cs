using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject melee;  
    public GameObject gun; 
    public float pickupRange = 2.0f;      
    public LayerMask pickupLayer;    

    private bool pickedUp = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            CheckForItemPickup();
        }
    }

    private void CheckForItemPickup()
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
            case Item.ItemType.Stick:
                melee.SetActive(true);
                Debug.Log("stick.");
                break;
            case Item.ItemType.Gun:
                gun.SetActive(true);
                Debug.Log("gun.");
                break;
        }
        Destroy(item.gameObject); 
    }
    

    private void PickupItem(GameObject item)
    {
        Debug.Log("Picked up Hat");
        Destroy(item); 
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
