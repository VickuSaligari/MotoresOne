using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private int _points;

    public int Points
    {
        get { return _points; }
        set
        {
            _points = value;
            OnPointsChanged(value);
        }
    }

    public event Action<int> OnPointsChanged;

    [SerializeField] TextMeshProUGUI pointsText;

    [SerializeField] private GameObject[] _puertitas;

    [SerializeField] TargetsManager _targetsManager;

    [SerializeField] Inputs _inputs;
    public static PointsManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnPointsChanged += UpdateSign;
        OnPointsChanged += CheckPoints;
    }

    public void UpdateSign(int newPoints)
    {
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

            _targetsManager.StopGame();

            if (_inputs.firstWeapon != null)
            {
                Destroy(_inputs.firstWeapon.gameObject);
                _inputs.firstWeapon = null;
            }
            if (_inputs.secondWeapon != null)
            {
                Destroy(_inputs.secondWeapon.gameObject);
                _inputs.secondWeapon = null;
            }
            

            return;
        }

        if (Points >= 120)
        {
            _targetsManager.TimeTillChange = 0.6f;
        }
    }
}