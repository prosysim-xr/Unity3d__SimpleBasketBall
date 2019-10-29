using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Reference to attach in the unity editor
    public Transform playerTarget;
    public float mouseSensitivity = 100f;
    float xAxisRotation = 0f;
    
    void Start()
    {
        
    }
    void Update()
    {
        PlayerYaxisRotation();
        PlayerXaxisRotation();
    }

    private void PlayerYaxisRotation()
    {
        float inputMouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        playerTarget.Rotate(Vector3.up * inputMouseX);
    }
    private void PlayerXaxisRotation()
    {
        float inputMouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xAxisRotation += inputMouseY;
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(-xAxisRotation, 0f, 0f);
    }
    
}
