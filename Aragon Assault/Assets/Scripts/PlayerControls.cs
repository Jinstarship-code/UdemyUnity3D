using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [Header("Player Movement")]
    [SerializeField] float controlSpeed=40f;
    [SerializeField] float xRange=10f;
    [SerializeField] float yRange=10f;

    [SerializeField] float positionPitchFactor=-2f;
    [SerializeField] float positionYawFactor=2f;
  
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor=-20f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers; 


    float yThrow,xThrow;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition=transform.localPosition.y*positionPitchFactor;
        float pitchDueToControlThrow = yThrow*controlPitchFactor;

        float pitch=pitchDueToPosition + pitchDueToControlThrow;
        float yaw=transform.localPosition.x*positionYawFactor;
        float roll=xThrow*controlRollFactor;

        transform.localRotation=Quaternion.Euler(pitch,yaw,roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SetLaserActive(true);
        }
        else
        {
            SetLaserActive(false);
        }
  
    }

    void SetLaserActive(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

}



/*
    Mathf.Clamp(float value, float min, float max)
        -float The float result between the min and max values.
*/