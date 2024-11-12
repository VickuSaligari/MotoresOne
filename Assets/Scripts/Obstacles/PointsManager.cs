using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
   [SerializeField] private int _points; 
   public int Points{ get { return _points; } set { _points = value; } }
   
   public event Action<int> OnPointsChanged;
   
   [SerializeField] TextMeshProUGUI pointsText;

   [SerializeField] private GameObject[] _puertitas;
   
   [SerializeField] TargetsManager _targetsManager;
   private void Start()
   {
      OnPointsChanged += UpdateSign;
      OnPointsChanged += CheckPoints;
   }

   public void UpdateSign(int newPoints)
   {
      Points += newPoints;
      //:D
      pointsText.text = $"Points: <br>{Points.ToString()}";
   }

   void CheckPoints(int newPoints)
   {
      if (Points >= 200)
      {
         foreach (var puertita in _puertitas)
         {
            Destroy(puertita);
         }

         return;
      }

      if (Points >= 120)
      {
         _targetsManager.TimeTillChange = 0.6f;
      }
   }
}
