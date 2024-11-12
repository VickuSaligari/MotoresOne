using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour , IInteractuable
{
[SerializeField] TargetsManager manager;
 private void OnTriggerEnter(Collider other)
 {
  
  if (other.gameObject.TryGetComponent(out Movement player))
  {
   manager.StartGame();
  }
  
 }

 public void Interact(bool interacting)
 {
  throw new NotImplementedException();
 }
}
