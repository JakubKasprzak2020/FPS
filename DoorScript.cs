using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    GameObject player;
    GameObject gunAsPlayerFront;
    public GameObject handle;
    public string doorName;
    bool isClosed = true;
    bool isDuringOpening = false;
    bool isDuringClosing = false;
    public bool isLocked = false;
    KeysManager keysManager;
    public float closedValuEulerAnglesY;
    public float openedValuEulerAnglesY;
    float openingAngle = 90;
    public float currentAngleY;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerNeerDoor())
        {
            //Show description
        }
        if (IsPlayerNeerDoor() && isClosed && Input.GetKeyDown(KeyCode.U))
        {
            transform.rotation = Quaternion.AngleAxis(closedValuEulerAnglesY, Vector3.up);
            TryToOpen();
        }
        if (IsPlayerNeerDoor() && !isClosed && Input.GetKeyDown(KeyCode.U))
        {
            transform.rotation = Quaternion.AngleAxis(openedValuEulerAnglesY, Vector3.up);
            isDuringClosing = true;
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

    private bool IsPlayerNeerDoor()
    {
        float distance = Vector3.Distance(gunAsPlayerFront.transform.position, handle.transform.position);
        return distance < 1;
    }

    private void TryToOpen()
    {
        if (!isLocked || keysManager.IsThisKeyCollected(doorName))
        {
            isDuringOpening = true;
        }
    }

    private void Open()
    {
        float border = openedValuEulerAnglesY;
        border = border >= 360 ? border - 360 : border;
        if (transform.rotation.eulerAngles.y <= border)
        {
            transform.Rotate(new Vector3(0, 1, 0) * 100 * Time.deltaTime);
        } else
        {
            isClosed = false;
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
