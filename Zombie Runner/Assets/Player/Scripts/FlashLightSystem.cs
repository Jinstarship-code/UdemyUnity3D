﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
   [SerializeField] float lightDecay = .1f;
   [SerializeField] float angleDecay = 1f;
   [SerializeField] float minimunAngle = 40f;

    Light myLight;

    private void Start() 
    {
        myLight = GetComponent<Light>();
    }

    private void Update() 
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
        ToggleLight();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void RestroeLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount; 
    }

    private void DecreaseLightAngle()
    {
        if(myLight.spotAngle <= minimunAngle)
            return;
        else
        {
            myLight.spotAngle -= angleDecay*Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {

        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void ToggleLight()
    {
        if(Input.GetKeyDown(KeyCode.F))
            myLight.enabled = !myLight.enabled;
    }

}
