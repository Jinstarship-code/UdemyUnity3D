using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit(); 
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
            gameObject.SetActive(false);
    }

}

/*
    OnParticleCollision을 쓰기위해선, 
    ParticleSystem -> Collision 에 Send Collision Messages를 on 해야함.
*/