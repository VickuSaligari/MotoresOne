using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    int receiveHIT;
    int chance = Random.Range(1, 20);
    private Color _originalColor;
    private Renderer objRenderer;

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        if (chance > 10)
        {
            ChangeObjectColor(Color.cyan);
        }
    }

    public void GetHit(int dmg)
    {
        
    }
    public void ChangeObjectColor(Color newColor)
    {
        objRenderer.material.color = newColor;
    }
}
