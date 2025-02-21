﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{

    private int lifes;
    public int beginingNumberOfLifes = 100;
    private int enemyAttackPower = 5; //10 a bit too much
    public GameObject harmSphere;
    AudioSource audioSource;
    public AudioClip hurtSound;
    bool isPlayingHurtSound = false;
    // Start is called before the first frame update
    void Start()
    {
        lifes = beginingNumberOfLifes;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        limitLifes();
    }

    private void limitLifes()
    {
        if (lifes < 0)
        {
            lifes = 0;
        } else if (lifes > 100)
        {
            lifes = 100;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (lifes > 0)
            {
                lifes = lifes - enemyAttackPower;
            }
            ShowHarmSphere();
            if (!isPlayingHurtSound)
            {
                StartCoroutine(PlayHurtSound());
            }
        }
    }

    private void ShowHarmSphere()
    {
        if (!harmSphere.activeSelf && lifes > 0)
        {
            harmSphere.SetActive(true);
            StartCoroutine(WaitAndHideHarmSphere(2.0f));
        } else if (lifes == 0)
        {
            harmSphere.SetActive(true);
        }
    }

    private IEnumerator WaitAndHideHarmSphere(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        harmSphere.SetActive(false);
    }

    public int GetLifesNumber()
    {
        return lifes;
    }

    public void AddLifes(int lifePoints)
    {
        lifes += lifePoints;
    }
    IEnumerator PlayHurtSound()
    {
        isPlayingHurtSound = true;
        //audioSource.time = 00.45f;
        //audioSource.PlayOneShot(hurtSound, 1);
        audioSource.clip = hurtSound;
        audioSource.time = 0.45f;
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        isPlayingHurtSound = false;
    }
}
