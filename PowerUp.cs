using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject insideObject;
    WeaponsManager weaponManager;
    ScreenInfo screenInfo;
    public bool isItPistol = false;
    public bool isItRifle = false;
    public int pistolAmmo = 0;
    public int rifleAmmo = 0;
    public string keyDoorName;
    public float rotationSpeed = 200.0f;
    public string eventInfoText = "";
    // Start is called before the first frame update
    void Start()
    {
        weaponManager = GameObject.FindWithTag("Gun").GetComponent<WeaponsManager>();
        screenInfo = GameObject.FindWithTag("Canvas").gameObject.GetComponent<ScreenInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateInsideObject();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
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
            if (pistolAmmo > 0)
            {
                weaponManager.AddPistolAmmo(pistolAmmo);
            }
            if (rifleAmmo > 0)
            {
                weaponManager.AddRifleAmmo(rifleAmmo);
            }
            if (keyDoorName != null)
            {
                KeysManager keysManager = GameObject.FindWithTag("Player").GetComponent<KeysManager>();
                keysManager.AddKey(keyDoorName);
            }
            screenInfo.setEventInfoForSeconds(eventInfoText, 5);
            gameObject.SetActive(false);
        }
    }

    private void rotateInsideObject()
    {
        if (insideObject != null)
        {
            insideObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
