using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
  public float senX, senY;

  public Transform orientation;

  float xRotation, yRotation;

  private void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    
    xRotation = 0f; 
    yRotation = 90f;
  }

  private void Update()
  {
    float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
    float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

    yRotation += mouseX;
    xRotation -= mouseY;

    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    orientation.rotation = Quaternion.Euler(0, yRotation, 0);
  }
}
