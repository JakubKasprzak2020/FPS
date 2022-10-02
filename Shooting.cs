using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    WeaponsManager weaponsManager;
    public BulletsPool bulletsPool;
    public GameObject bullet;
    public int maxNumberOfBullets = 50;
    public GameObject endOfPistolBarrel;
    public GameObject endOfRifleBarrel;
    public List<GameObject> endOfBarrels;
    public float secondsBeforeBulletDeactivation = 3f;


    // Start is called before the first frame update
    void Start()
    {
        weaponsManager = GetComponent<WeaponsManager>();
        endOfBarrels = new List<GameObject> { endOfPistolBarrel, endOfRifleBarrel };
        bulletsPool = new BulletsPool(bullet, maxNumberOfBullets);
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if (Input.GetMouseButtonDown(0) && weaponsManager.GetCurrentWeapon() != null && weaponsManager.IsAmmo())
        {
            GameObject bullet = bulletsPool.GetBullet();
            GameObject endOfBarrel = GetEndOfBarrel();
            if (bullet != null && endOfBarrel != null)
            {
                bullet.transform.position = endOfBarrel.transform.position;
                bullet.transform.rotation = endOfBarrel.transform.rotation;
                bullet.SetActive(true);
                weaponsManager.UseAmmo();
                StartCoroutine(DeactivateObjectAfterSeconds(bullet, secondsBeforeBulletDeactivation));
            }
        }

    }

    void shootBySpecificWeapon()
    {
        if (weaponsManager.GetCurrentWeapon() == weaponsManager.pistol && weaponsManager.IsAmmo())
        {

        } else if(weaponsManager.GetCurrentWeapon() == weaponsManager.rifle && weaponsManager.IsAmmo())
        {

        }
    }

    IEnumerator DeactivateObjectAfterSeconds(GameObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

    GameObject GetEndOfBarrel()
    {
        foreach (GameObject barrel in endOfBarrels)
        {
            if (barrel.activeSelf)
            {
                return barrel;
            }
        }
        return null;
    }

}
