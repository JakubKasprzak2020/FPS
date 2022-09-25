using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingHit : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
       explosionParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            explosionParticle.Play();
        }
    }
}
