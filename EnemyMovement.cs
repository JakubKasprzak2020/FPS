using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;
    public bool isActivate = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivate)
        {
            turnToObject(player);
            goToObject(player);
        }
    }

    void turnToObject(Transform targetObject)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(targetObject.position - transform.position), rotationSpeed * Time.deltaTime);
    }

    void goToObject(Transform targetObject)
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

}
