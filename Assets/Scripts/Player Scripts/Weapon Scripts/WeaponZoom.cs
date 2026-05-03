using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] RigidbodyFirstPersonController playerController;
    [SerializeField] float zoomInFOV = 80f;
    float zoomOutFOV;
    [SerializeField] float zoomInSensitivity = 1.9f;
    float zoomOutSensitivity;
    bool isZoomedIn = false;

    private void OnDisable()
    {
        ZoomOut();
    }
    private void Awake()
    {
        zoomOutFOV = playerCamera.fieldOfView;
        zoomOutSensitivity = playerController.mouseLook.XSensitivity;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isZoomedIn)
            {
                ZoomOut();
            }
            else
            {
                ZoomIn();
            }
        }
    }

    private void ZoomIn()
    {
        isZoomedIn = true;
        playerCamera.fieldOfView = zoomInFOV;
        playerController.mouseLook.XSensitivity = zoomInSensitivity;
        playerController.mouseLook.YSensitivity = zoomInSensitivity;

    }

    private void ZoomOut()
    {
        isZoomedIn = false;
        playerCamera.fieldOfView = zoomOutFOV;
        playerController.mouseLook.XSensitivity = zoomOutSensitivity;
        playerController.mouseLook.YSensitivity = zoomOutSensitivity;
    }
}
