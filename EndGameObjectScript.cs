using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameObjectScript : MonoBehaviour
{
    GameObject player;
    GameObject gunAsPlayerFront;
    ScreenInfo screenInfo;
    bool wasPlayerNear = false;
    public string infoText = "Lucky you can fly a helicopter! Press E to fly away.";
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").gameObject;
        gunAsPlayerFront = player.transform.Find("PlayerBody")
        .gameObject.transform.Find("Main Camera").gameObject
        .gameObject.transform.Find("Gun").gameObject;
        screenInfo = GameObject.FindWithTag("Canvas").gameObject.GetComponent<ScreenInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerNeer())
        {
            wasPlayerNear = true;
            screenInfo.setEventInfo(infoText);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Final Animation");
            }
        }
        else if (wasPlayerNear)
        {
            wasPlayerNear = false;
            screenInfo.setEventInfo("");
        }
    }

    private bool IsPlayerNeer()
    {
        float distance = Vector3.Distance(transform.position, gunAsPlayerFront.transform.position);
        return distance < 2;
    }
}
