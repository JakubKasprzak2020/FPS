using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenInfo : MonoBehaviour
{
    public GameObject weaponsManagerObject;
    public GameObject player;
    WeaponsManager weaponsManager;
    LifeManager lifeManager;
    Shooting shootingScript;
    public Text ammoInfo;
    public Text lifeInfo;
    public Text eventInfo;
    //public bool isNearDoor;
    string textForEventInfo;
    // Start is called before the first frame update
    void Start()
    {
        weaponsManager = weaponsManagerObject.GetComponent<WeaponsManager>();
        shootingScript = weaponsManagerObject.GetComponent<Shooting>();
        lifeManager = player.GetComponent<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoInfo();
        UpdateLifesInfo();
        UpdateEventInfo();
    }

    void UpdateAmmoInfo()
    {
        ammoInfo.text = "Ammo: " + weaponsManager.GetAmmoNumber();
        if (shootingScript.GetCanAlreadyShoot())
        {
            ammoInfo.color = Color.black;
        }
        else
        {
            ammoInfo.color = Color.red;
        }
    }

    void UpdateLifesInfo()
    {
        lifeInfo.text = "Health: " + lifeManager.GetLifesNumber();
    }

    void UpdateEventInfo()
    {
        eventInfo.text = textForEventInfo;
    }

    public void setEventInfo(string text)
    {
        textForEventInfo = text;
    }

    public void setEventInfoForSeconds(string text, float seconds)
    {
        textForEventInfo = text;
        StartCoroutine(WaitAndHideEventInfo(seconds));
    }

    private IEnumerator WaitAndHideEventInfo(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        textForEventInfo = "";
    }
}
