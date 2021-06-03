using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 0.5f;

    bool cnaShoot = true;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && cnaShoot == true)
        {
            StartCoroutine(Shoot());
        }        
    }

    IEnumerator Shoot()
    {
        cnaShoot = false;
        if(ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        cnaShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpack(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*hit.distance,Color.yellow);
            if (target == null)
                return;

            target.TakeDamage(damage);
        }
        else
            return;
    }

    private void CreateHitImpack(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
