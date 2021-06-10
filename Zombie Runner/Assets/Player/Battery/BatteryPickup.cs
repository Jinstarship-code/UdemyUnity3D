using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 5f;

    FlashLightSystem playerLight;

    private void OnTriggerEnter(Collider otherCollider) 
    {
        if(otherCollider.gameObject.tag == "Player")
        {   
            playerLight = otherCollider.GetComponentInChildren<FlashLightSystem>();

            playerLight.RestoreLightAngle(restoreAngle);
            playerLight.RestroeLightIntensity(addIntensity);

            Destroy(gameObject);
        }
    }
}
