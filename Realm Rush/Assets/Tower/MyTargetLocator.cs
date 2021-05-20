using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;

    void Start()
    {
        target = FindObjectOfType<MyEnemyMover>().transform;
    }

    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
