using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject insideObject;
    WeaponsManager weaponManager;
    public bool isItPistol = false;
    public bool isItRifle = false;
    public int ammo = 0;
    public float rotationSpeed = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        weaponManager = GameObject.FindWithTag("Gun").GetComponent<WeaponsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateInsideObject();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (isItPistol)
        {
            weaponManager.hasPistol = true;
            weaponManager.SetThisWeaponAsCurrent(weaponManager.pistol);
        }
        if (isItRifle)
        {
            weaponManager.hasRifle = true;
            weaponManager.SetThisWeaponAsCurrent(weaponManager.rifle);
        }
        if (ammo > 0)
        {
            weaponManager.AddAmmo(ammo);
        }
        gameObject.SetActive(false);
    }

    private void rotateInsideObject()
    {
        if (insideObject != null)
        {
            insideObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
