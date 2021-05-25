using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyEnemy))]
public class MyEnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;

    MyEnemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Start() {
        enemy = GetComponent<MyEnemy>();
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit(); 
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints +=difficultyRamp;
            enemy.RewardGold();
        }
    }

}

/*
    OnParticleCollision을 쓰기위해선, 
    ParticleSystem -> Collision 에 Send Collision Messages를 on 해야함.
*/