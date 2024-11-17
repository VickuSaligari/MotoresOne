using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaManager : MonoBehaviour
{
   public static CajaManager instance;
   
   [SerializeField] private PickUpBox[] _boxes;
   private bool _completed;

   private void Awake()
   {
      instance = this;
   }

   public void CheckIfPlaced()
   {
      foreach (var box in _boxes)
      {
         if (!box.placed)
         {
          _completed = false;
          return;
         }
         
         _completed = true;
      }

      if (_completed) WinWin();
   }

   void WinWin()
   {
      Debug.Log("Win");
   }
}
