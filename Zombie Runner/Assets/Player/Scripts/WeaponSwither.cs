using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwither : MonoBehaviour
{
    [SerializeField] int currentWeapon=0;

    void Start()
    {
        SetWeaponActive();
    }
    private void Update() 
    {
            int previousWeapon = currentWeapon;

            ProcessKeyInput();
            ProcessScrollWheel();

            if(previousWeapon != currentWeapon)
            {
                SetWeaponActive();
            }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if(currentWeapon >= transform.childCount -1)
                currentWeapon = 0;
            else
                currentWeapon++;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currentWeapon <= transform.childCount - transform.childCount)
                currentWeapon = transform.childCount-1;
            else
                currentWeapon--;
        }
    
        
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            currentWeapon = 0;
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            currentWeapon = 1;
        else if(Input.GetKeyDown(KeyCode.Alpha3))
            currentWeapon = 2;
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }

}
