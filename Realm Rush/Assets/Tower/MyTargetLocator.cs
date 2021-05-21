using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;

    void Update()
    {
        FindClosestTarget();

        AimWeapon();
    }

    void FindClosestTarget()
    {
        MyEnemy[] enemies = FindObjectsOfType<MyEnemy>();
        Transform cloesetTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(MyEnemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position,enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                cloesetTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
 
        target = cloesetTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if(targetDistance < range)
        {
            Attack(true);
        }
        else
            Attack(false);
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled=isActive;      
    }
}
