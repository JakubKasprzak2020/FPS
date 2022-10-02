using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenInfo : MonoBehaviour
{
    public GameObject weaponsManagerObject;
    WeaponsManager weaponsManager;
    public Text ammoInfo;
    // Start is called before the first frame update
    void Start()
    {
        weaponsManager = weaponsManagerObject.GetComponent<WeaponsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoInfo();
    }

    void UpdateAmmoInfo()
    {
        ammoInfo.text = "Ammo: " + weaponsManager.GetAmmoNumber();
    }
}
