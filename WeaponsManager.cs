using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public GameObject pistol;
    public GameObject rifle;
    GameObject currentWeapon;
    public bool hasPistol = false;
    public bool hasRifle = false;

    int ammo = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (pistol.activeSelf && hasPistol)
        {
            currentWeapon = pistol;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWeapon();
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasPistol)
        {
            SetThisWeaponAsCurrent(pistol);
        } else if (Input.GetKeyDown(KeyCode.Alpha2) && hasRifle)
        { 
            SetThisWeaponAsCurrent(rifle);
        }
    }

    public void SetThisWeaponAsCurrent(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false);
        }
        currentWeapon = weapon;
        currentWeapon.SetActive(true);
    }

    public bool IsAmmo()
    {
        return ammo > 0;
    }

    public int GetAmmoNumber()
    {
        return ammo;
    }

    public void UseAmmo()
    {
        ammo--;
    }

    public void AddAmmo(int ammoNumber)
    {
        ammo += ammoNumber;
    }

    public GameObject GetCurrentWeapon()
    {
        return currentWeapon;
    }

}
