using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    WeaponsManager weaponsManager;
    public GameObject player;
    LifeManager lifeManager;
    public BulletsPool bulletsPool;
    public BulletsPool rifleBulletsPool;
    public GameObject bullet;
    public GameObject rifleBullet;
    public int maxNumberOfBullets = 50;
    public GameObject endOfPistolBarrel;
    public GameObject endOfRifleBarrel;
    public List<GameObject> endOfBarrels;
    public float secondsBeforeBulletDeactivation = 3f;
    bool canAlreadyShoot = true;


    // Start is called before the first frame update
    void Start()
    {
        weaponsManager = GetComponent<WeaponsManager>();
        lifeManager = player.GetComponent<LifeManager>();
        endOfBarrels = new List<GameObject> { endOfPistolBarrel, endOfRifleBarrel };
        bulletsPool = new BulletsPool(bullet, maxNumberOfBullets);
        rifleBulletsPool = new BulletsPool(rifleBullet, maxNumberOfBullets);
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeManager.GetLifesNumber() > 0)
        {
            shoot();
        }
    }

    void shoot()
    {
        BulletsPool specificBP = GetSpecificBulletPool();
        if (CheckIsShootPosible())
        {
            GameObject bullet = specificBP.GetBullet();
            GameObject endOfBarrel = GetEndOfBarrel();
            if (bullet != null && endOfBarrel != null)
            {
                bullet.transform.position = endOfBarrel.transform.position;
                bullet.transform.rotation = endOfBarrel.transform.rotation;
                bullet.SetActive(true);
                weaponsManager.UseAmmo();
                StartCoroutine(DeactivateObjectAfterSeconds(bullet, secondsBeforeBulletDeactivation));
                //canAlreadyShoot = false;
                StartCoroutine(DelayNextShoot());
            }
        }
    }

    private bool CheckIsShootPosible()
    {
        bool result = Input.GetMouseButtonDown(0)
            && weaponsManager.GetCurrentWeapon() != null
            && weaponsManager.IsAmmo()
            && canAlreadyShoot;
        return result;
    }

    BulletsPool GetSpecificBulletPool()
    {
        BulletsPool specificBP = bulletsPool;
       if(weaponsManager.GetCurrentWeapon() == weaponsManager.rifle)
        {
            specificBP = rifleBulletsPool;
        }
        return specificBP;
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
    IEnumerator DelayNextShoot()
    {
        canAlreadyShoot = false;
        yield return new WaitForSeconds(weaponsManager.GetShootDelay());
        canAlreadyShoot = true;
    }

    public bool GetCanAlreadyShoot()
    {
        return canAlreadyShoot;
    }

}
