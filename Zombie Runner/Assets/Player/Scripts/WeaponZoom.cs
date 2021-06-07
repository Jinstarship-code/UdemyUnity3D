using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController firstPersonController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutSensitivity =2f;
    [SerializeField] float zoomInSensitivity = .5f;

    bool zoomedInToggle = false;

    private void OnDisable() 
    {
        ZoomOut();
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }    
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        firstPersonController.mouseLook.XSensitivity = zoomInSensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomInSensitivity;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        firstPersonController.mouseLook.XSensitivity = zoomOutSensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomOutSensitivity;
    }
}
