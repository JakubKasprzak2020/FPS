using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public GameObject pistol;
    public GameObject rifle;
    GameObject currentWeapon;
    public GameObject player;
    LifeManager lifeManager;
    public bool hasPistol = false;
    public bool hasRifle = false;
    public float pistolShootDelay = 0.5f;
    public float rifleShootDelay = 0.1f;
    private float shootDelay;

    AmmoMagazine ammo;
    AmmoMagazine pistolAmmo;
    AmmoMagazine rifleAmmo;
    // Start is called before the first frame update
    void Start()
    {
        lifeManager = player.GetComponent<LifeManager>();
        if (pistol.activeSelf && hasPistol)
        {
            currentWeapon = pistol;
        }
        pistolAmmo = new AmmoMagazine();
        rifleAmmo = new AmmoMagazine();
        ammo = pistolAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeManager.GetLifesNumber() > 0)
        {
            ChangeWeapon();
        }
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasPistol)
        {
            SetThisWeaponAsCurrent(pistol);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2) && hasRifle)
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
        SetWeaponProperties();
    }

    private void SetWeaponProperties()
    {
        if(currentWeapon == pistol)
        {
            ammo = pistolAmmo;
            shootDelay = pistolShootDelay;
        } 
        else if(currentWeapon == rifle)
        {
            ammo = rifleAmmo;
            shootDelay = rifleShootDelay;
        }
    }

    public bool IsAmmo()
    {
        return ammo.IsAmmo();
    }

    public int GetAmmoNumber()
    {
        return ammo.GetAmmoNumber();
    }

    public void UseAmmo()
    {
        ammo.UseAmmo();
    }

    public void AddPistolAmmo(int ammoNumber)
    {
        pistolAmmo.AddAmmo(ammoNumber);
    }

    public void AddRifleAmmo(int ammoNumber)
    {
        rifleAmmo.AddAmmo(ammoNumber);
    }

    public GameObject GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public float GetShootDelay()
    {
        return shootDelay;
    }
}
