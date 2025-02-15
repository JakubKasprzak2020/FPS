using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingHit : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public GameObject body;
    public int healthPoints = 4; // 10 - quite durable
    public bool isImmortal = false;
    AudioSource audioSource;
    public AudioClip gettingHitSound;


    // Start is called before the first frame update
    void Start()
    {
       explosionParticle.Stop();
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        reactWhenKilled();
        moveExplosionParticle();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            explosionParticle.Play();
            healthPoints--;
            audioSource.PlayOneShot(gettingHitSound, 1);
            if (!isImmortal)
            {
                this.gameObject.transform.GetChild(0).GetComponent<EnemyMovement>().isActivate = true;
            }
        }
    }

    void reactWhenKilled()
    {
        if (!isImmortal && healthPoints < 1)
        {
            body.SetActive(false);
        }
    }

    void moveExplosionParticle()
    {
        explosionParticle.transform.position = body.transform.position;
    }
}
