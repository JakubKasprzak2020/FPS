using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool
{
    public List<GameObject> bullets = new List<GameObject>();
    public GameObject bullet;
    public int maxNumberOfBullets = 200;

    public BulletsPool(GameObject bullet, int maxNumberOfBullets)
    {
        this.bullet = bullet;
        this.maxNumberOfBullets = maxNumberOfBullets;
        InitPool();
    }

    private void InitPool()
    {
        for (int i = 0; i < maxNumberOfBullets; i++)
        {
            GameObject bulletClone = Object.Instantiate(bullet);
            bulletClone.SetActive(false);
            bullets.Add(bulletClone);
        }
    }

    public GameObject GetBullet()
    {
        GameObject nextBullet = null;
        for (int i = 0; i < maxNumberOfBullets; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                nextBullet = bullets[i];
            }
        }
        return nextBullet;
    }
}
