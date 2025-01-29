using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    GameObject player;
    GameObject gunAsPlayerFront;
    public GameObject bomb;
    public GameObject handle;
    public string doorName;
    bool isClosed = true;
    bool isDuringOpening = false;
    bool isDuringClosing = false;
    public bool isLocked = false;
    KeysManager keysManager;
    ScreenInfo screenInfo;
    public float closedValuEulerAnglesY;
    public float openedValuEulerAnglesY;
    float openingAngle = 90;
    public float currentAngleY;
    public string infoTextWhenClosed = "Press E to open the door.";
    public string infoTextWhenLocked = "The door is locked!";
    public string infoTextForBomb = "Press E to set the bomb.";
    bool wasPlayerNear = false;
    bool didTryToOpenLocked = false;
    public bool canBeOpenByBomb = false;
    bool wasBombSet = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").gameObject;
        currentAngleY = transform.rotation.eulerAngles.y;
        closedValuEulerAnglesY = transform.rotation.eulerAngles.y;
        openedValuEulerAnglesY = closedValuEulerAnglesY + openingAngle;
        keysManager = player.GetComponent<KeysManager>();
        gunAsPlayerFront = player.transform.Find("PlayerBody")
            .gameObject.transform.Find("Main Camera").gameObject
            .gameObject.transform.Find("Gun").gameObject;
        screenInfo = GameObject.FindWithTag("Canvas").gameObject.GetComponent<ScreenInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerNeerDoor())
        {
            ReactWhenPlaerIsNear();
            wasPlayerNear = true;
        } else if (wasPlayerNear && !wasBombSet)
        {
            ReactWhenPlayerIsNotNearAnymore();
        }
        if (isDuringOpening)
        {
            Open();
        }
        if (isDuringClosing)
        {
            Close();
        }
    }

    private void ReactWhenPlaerIsNear()
    {
        if (canBeOpenByBomb && !keysManager.IsThisKeyCollected(doorName))
        {
            screenInfo.setEventInfo(infoTextWhenLocked);
        }
        if (canBeOpenByBomb && !wasBombSet && keysManager.IsThisKeyCollected(doorName))
        {
            screenInfo.setEventInfo(infoTextForBomb);
        }
        if (canBeOpenByBomb && !wasBombSet && Input.GetKeyDown(KeyCode.E) && keysManager.IsThisKeyCollected(doorName))
        {
            bomb.SetActive(true);
            wasBombSet = true;
        }
        if (isClosed && !didTryToOpenLocked && !canBeOpenByBomb)
        {
            screenInfo.setEventInfo(infoTextWhenClosed);
        }
        if (isClosed && Input.GetKeyDown(KeyCode.E) && !canBeOpenByBomb)
        {
            transform.rotation = Quaternion.AngleAxis(closedValuEulerAnglesY, Vector3.up);
            TryToOpen();
        }
        if (!isClosed && Input.GetKeyDown(KeyCode.E) && !canBeOpenByBomb)
        {
            transform.rotation = Quaternion.AngleAxis(openedValuEulerAnglesY, Vector3.up);
            isDuringClosing = true;
        }
    }

    private void ReactWhenPlayerIsNotNearAnymore()
    {
        screenInfo.setEventInfo("");
        wasPlayerNear = false;
        didTryToOpenLocked = false;

    }

    private bool IsPlayerNeerDoor()
    {
        float distance = Vector3.Distance(gunAsPlayerFront.transform.position, handle.transform.position);
        return distance < 1;
    }

    private void TryToOpen()
    {
        bool isKeyPresent = keysManager.IsThisKeyCollected(doorName);
        if (!isLocked || isKeyPresent)
        {
            isDuringOpening = true;
            screenInfo.setEventInfo("");
        } else if (isLocked && !isKeyPresent)
        {
            didTryToOpenLocked = true;
            screenInfo.setEventInfo(infoTextWhenLocked);
        }
    }

    private void Open()
    {
        isClosed = false;
        float border = openedValuEulerAnglesY;
        border = border >= 360 ? border - 360 : border;
        if (transform.rotation.eulerAngles.y <= border)
        {
            transform.Rotate(new Vector3(0, 1, 0) * 100 * Time.deltaTime);
        } else
        {
            isLocked = false;
            isDuringOpening = false;
            currentAngleY = transform.rotation.eulerAngles.y;
        }
    }

    private void Close()
    {
        if (transform.rotation.eulerAngles.y <= openedValuEulerAnglesY && transform.rotation.eulerAngles.y >= closedValuEulerAnglesY)
        {
            transform.Rotate(new Vector3(0, 1, 0) * -100 * Time.deltaTime);
        }
        else
        {
            isDuringClosing = false;
            isClosed = true;
            currentAngleY = transform.rotation.eulerAngles.y;
        }
    }
}
