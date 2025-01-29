using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicopterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject smallPropeller;
    public GameObject bigPropeller;
    public float rotationSpeed = 50;
    public float ascentSpeed = 1;
    public GameObject button;
    public GameObject theEndText;
    bool theEndIsVisible = false;
    Vector3 ascentVector = new Vector3();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpinThePropelers();
        GetUp();
        ShowButtonAndText();
    }

    void SpinThePropelers()
    {
        smallPropeller.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        bigPropeller.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (rotationSpeed < 700)
        {
            rotationSpeed++;
        }
    }

    void GetUp()
    {
        if (rotationSpeed > 300 && transform.position.y < 30)
        {
            ascentVector.y = ascentSpeed;
            transform.Translate(ascentVector * Time.deltaTime);
        }
    }

    void ShowButtonAndText()
    {
        if (!theEndIsVisible && transform.position.y > 12)
        {
            theEndIsVisible = true;
            button.SetActive(true);
            theEndText.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
