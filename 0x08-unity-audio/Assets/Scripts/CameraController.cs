﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides third-person camera tracking.
/// </summary>
public class CameraController : MonoBehaviour
{
    public GameObject GameController;
    public Transform playerTransform;
    public GameObject WinCanvas;
    public bool isInverted = false;
    Transform camTransform;
    float mouseX, mouseY;
    float distance;

    /// <summary>
    /// Initializes variables and locks cursor.
    /// </summary>
    void Awake()
    {
        camTransform = GetComponent<Transform>();
        distance = Vector3.Distance(camTransform.position, playerTransform.position);
        if (PlayerPrefs.GetString("IsInverted") == "True")
        {
            isInverted = true;
        }
        else
        {
            isInverted = false;
        }
    }

    /// <summary>
    /// Updates the camera position based on mouse input.
    /// </summary>
    void LateUpdate()
    {
        if (GameController.GetComponent<PauseMenu>().isPaused || WinCanvas.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation; 
        if (isInverted)
        {
            rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else 
        {
            rotation = Quaternion.Euler(-mouseY, mouseX, 0);
        }
        camTransform.position = playerTransform.position + rotation * dir;
        
        transform.LookAt(playerTransform.position);
    }
}
