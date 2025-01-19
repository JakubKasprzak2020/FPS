using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    ScreenInfo screenInfo;
    GateScript gateScript;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        explosionParticle.Stop();
        screenInfo = GameObject.FindWithTag("Canvas").gameObject.GetComponent<ScreenInfo>();
        gateScript = transform.parent.gameObject.transform.parent.gameObject.GetComponent<GateScript>();
        StartCoroutine(ExplodeAfterSeconds(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator ExplodeAfterSeconds(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            //screenInfo.setEventInfoForSeconds(i.ToString(), 1);
            yield return StartCoroutine(ShowTextForSecond(i.ToString()));
            //ShowTextForSecond(i.ToString());
        }
        screenInfo.setEventInfo("");
        explosionParticle.Play();
        gateScript.isFallingDown = true;
        gameObject.SetActive(false);
    }

    IEnumerator ShowTextForSecond(string text)
    {
        screenInfo.setEventInfo(text); 
        yield return new WaitForSeconds(1);
    }
}
