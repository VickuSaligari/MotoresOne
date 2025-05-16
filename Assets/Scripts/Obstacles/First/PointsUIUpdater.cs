using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUIUpdater : MonoBehaviour, IPointsObserver
{
    [SerializeField] private TextMeshProUGUI pointsText;

    private void Start()
    {
        PointsManager.Instance.RegisterObserver(this);
    }

    public void OnPointsChanged(int newPoints)
    {
        pointsText.text = $"Points: <br>{newPoints}";
    }
}
