using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public BulletsPool bulletsPool;
    public GameObject bullet;
    public int maxNumberOfBullets = 200;
    public GameObject endOfPistolBarrel;
    public float secondsBeforeBulletDeactivation = 3f;


    // Start is called before the first frame update
    void Start()
    {
        bulletsPool = new BulletsPool(bullet, maxNumberOfBullets);
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = bulletsPool.GetBullet();
            if (bullet != null)
            {
                bullet.transform.position = endOfPistolBarrel.transform.position;
                bullet.transform.rotation = endOfPistolBarrel.transform.rotation;
                bullet.SetActive(true);
                StartCoroutine(DeactivateObjectAfterSeconds(bullet, secondsBeforeBulletDeactivation));
            }
        }

    }

    IEnumerator DeactivateObjectAfterSeconds(GameObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);

    }

}
