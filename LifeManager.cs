using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{

    private int lifes;
    private int beginingNumberOfLifes = 20;
    public GameObject harmSphere;
    // Start is called before the first frame update
    void Start()
    {
        lifes = beginingNumberOfLifes;
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
            lifes = lifes - 10;
            ShowHarmSphere();
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
}
