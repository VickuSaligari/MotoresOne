using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaManager : MonoBehaviour, IBoxObserver
{
   public static CajaManager instance;

   [SerializeField] private PickUpBox[] _boxes;
   private HashSet<PickUpBox> placedBoxes = new();

   public Canvas canvas;

   private void Awake()
   {
      instance = this;
      foreach (var box in _boxes)
      {
         box.RegisterObserver(this);
      }
   }

   public void OnBoxPlaced(PickUpBox box)
   {
      if (box.IsCorrectlyPlaced())
      {
         placedBoxes.Add(box);
         if (placedBoxes.Count == _boxes.Length)
            WinWin();
      }
   }

   private void WinWin()
   {
      canvas.gameObject.SetActive(true);
      Debug.Log("Win");
   }
}
