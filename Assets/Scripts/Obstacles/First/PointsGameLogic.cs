using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGameLogic : MonoBehaviour, IPointsObserver
{
    [SerializeField] private GameObject[] _puertitas;
    [SerializeField] private TargetsManager _targetsManager;
    [SerializeField] private Inputs _inputs;

    private void Start()
    {
        PointsManager.Instance.RegisterObserver(this);
    }

    public void OnPointsChanged(int newPoints)
    {
        if (newPoints >= 200)
        {
            foreach (var puertita in _puertitas)
                Destroy(puertita);

            _targetsManager.StopGame();

            DestroyWeapons();
        }
        else if (newPoints >= 120)
        {
            _targetsManager.TimeTillChange = 2f;
        }
    }

    private void DestroyWeapons()
    {
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
    }
}

