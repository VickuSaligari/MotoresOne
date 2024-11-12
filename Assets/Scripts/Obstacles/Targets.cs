using System;
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
    public bool isActive{get{return _isActive;}set{_isActive = value;}}

    void Start()
    {
        objRenderer = GetComponent<Renderer>();

       // StartCoroutine(ChangeColor());
    }

    private void OnCollisionEnter(Collision collision)
    {
            StartCoroutine(ChangeColor());
    }
    
   public IEnumerator ChangeColor()
    {
        isActive = true;
        Color originalColor = objRenderer.material.color;
        float elapsedTime = 0f;

        while (elapsedTime < changeDuration)
        {
            objRenderer.material.color = Color.Lerp(originalColor, pressMe, elapsedTime / changeDuration);
            elapsedTime += Time.deltaTime;

            yield return null; 
        }

        objRenderer.material.color = pressMe;

        yield return new WaitForSeconds(1f);
        isActive = false;
        objRenderer.material.color = originalColor;
    }
}
