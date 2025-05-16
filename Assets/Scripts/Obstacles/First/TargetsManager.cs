using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetsManager : MonoBehaviour
{
    [SerializeField] private Targets[] targets;
    private bool isActive;
    private bool _canActivateTargets;
    [SerializeField] float _timeTillChange;

    public float TimeTillChange
    {
        get { return _timeTillChange; }
        set { _timeTillChange = value; }
    }

    public void StartGame()
    {
        isActive = true;
        _canActivateTargets = true;
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }
        if (_canActivateTargets)
        {
            StartCoroutine(ChangeTargets());
        }
    }

    IEnumerator ChangeTargets()
    {
        _canActivateTargets = false;
        int RandomTarget = Random.Range(0, targets.Length);
        int RandomIndex;

        for (int i = 0; i < RandomTarget; i++)
        {
            RandomIndex = Random.Range(0, targets.Length);
            if (!targets[RandomIndex].isActive)
            {
                targets[i].StartCoroutine(targets[i].ChangeColor());
            }
        }
        yield return new WaitForSeconds(TimeTillChange);
        _canActivateTargets = true;
    }

    public void StopGame()
    {
        StopAllCoroutines();
        _canActivateTargets = false;
        
        foreach (var target in targets)
        {
            target.StopGame();
        }  
    }
}