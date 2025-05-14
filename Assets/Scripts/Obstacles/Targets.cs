using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Targets : MonoBehaviour //IInteractuable
{
    private Renderer objRenderer;
    public Color pressMe;
    public Color doNotPressMe;
    public Color goldenn;
    public float changeDuration = 2.0f;

    private bool _isActive;

    public bool isActive
    {
        get { return _isActive; }
        set { _isActive = value; }
    }

    public Mode currentMode = Mode.Normal;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }
    public IEnumerator ChangeColor()
    {
        isActive = true;
        int random = Random.Range(0, 3);
        currentMode = (Mode)random;

        switch (currentMode)
        {
            case Mode.Normal: 
                objRenderer.material.color = pressMe;
                break;
            
            case Mode.Black: 
                objRenderer.material.color = doNotPressMe;
                break;
            
            case Mode.Goldenn: 
                objRenderer.material.color = goldenn;
                break;
            
        }

        yield return new WaitForSeconds(3f);
        isActive = false;
        objRenderer.material.color = Color.white;
    }

    public void Hit(int pointsToAdd)
    {
        if (!isActive)
        {
            return;
        }
        
        switch (currentMode)
        {
            case Mode.Normal:
                PointsManager.Instance.Points += pointsToAdd;
                break;
            
            case Mode.Black:
                PointsManager.Instance.Points -= pointsToAdd;
                break;
            
            case Mode.Goldenn:
                PointsManager.Instance.Points += 2 * pointsToAdd;
                break;
        }

        isActive = false;
        objRenderer.material.color = Color.white;
    }
    
    public void StopGame()
    {
        isActive = false;
        
        objRenderer.material.color = Color.white;
    }
}

public enum Mode
{
    Black,
    Goldenn,
    Normal
}