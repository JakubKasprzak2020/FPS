using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public bool isFallingDown = false;
    AudioSource audioSource;
    public AudioClip explosionSound;
    bool explosionSoundStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        explosionParticle.Stop();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFallingDown)
        {
            if (!explosionSoundStarted)
            {
                audioSource.clip = explosionSound;
                audioSource.volume = 1;
                audioSource.Play();
                explosionSoundStarted = false;
            }

            if (transform.rotation.eulerAngles.z <= 90)
            {
                transform.Rotate(new Vector3(0, 0, 3) * 100 * Time.deltaTime);
            } else
            {
                float x = gameObject.transform.eulerAngles.x;
                float y = gameObject.transform.eulerAngles.y;
                transform.eulerAngles = new Vector3(x, y, 90f);
                isFallingDown = false;
            }
        }
    }
}
