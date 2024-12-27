using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;
    LifeManager lifeManager;
    // Start is called before the first frame update
    void Start()
    {
        lifeManager = player.GetComponent<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeManager.GetLifesNumber() <= 0)
        {
            TriggerDeath();
        }
    }
    void TriggerDeath()
    {
        if (player.transform.rotation.eulerAngles.z < 90)
        {
            player.transform.Rotate(new Vector3(0, 0, 1) * 100 * Time.deltaTime);
            player.transform.position += Vector3.up * -0.5f * Time.deltaTime;
        }
    }
}
