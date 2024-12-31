using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivatorScript : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyMovement>().isActivate = true;
            }
        }
    }
}
