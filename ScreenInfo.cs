using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenInfo : MonoBehaviour
{
    public GameObject weaponsManagerObject;
    WeaponsManager weaponsManager;
    Shooting shootingScript;
    public Text ammoInfo;
    // Start is called before the first frame update
    void Start()
    {
        weaponsManager = weaponsManagerObject.GetComponent<WeaponsManager>();
        shootingScript = weaponsManagerObject.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoInfo();
    }

    void UpdateAmmoInfo()
    {
        ammoInfo.text = "Ammo: " + weaponsManager.GetAmmoNumber();
        if (shootingScript.GetCanAlreadyShoot())
        {
            ammoInfo.color = Color.black;
        }
        else
        {
            ammoInfo.color = Color.red;
        }
    }
}
