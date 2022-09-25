using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Vector3 bulletVector;
    Rigidbody rb;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        bulletVector.z = speed;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(bulletVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }

}
