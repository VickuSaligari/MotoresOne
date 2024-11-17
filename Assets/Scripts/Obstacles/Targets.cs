using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Targets : MonoBehaviour
{
    /*() time limit -> 200 or more pts to win
     * buttons starts timer

    flash 6 secs pts < 120 / 4 secs pts > 120 - cyan up / magenta down
    if: hit -> up: 20 pts / down: 10 pts
    color reset -> none

    chance -> 1:20 when pts < 120 / 1:12 when pts > 120
    if: hit -> (blue up / pink down): -20 pts when pts < 120 / -40 when pts > 120

    chance 1:40 -> golden: +60 pts

    when time�s up: =>200 pts -> door opens / <200 points: try again
    */


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

        // StartCoroutine(ChangeColor());
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