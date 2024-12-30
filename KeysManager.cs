using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysManager : MonoBehaviour
{
    private List<string> doorsWithKeysCollected = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKey(string doorName)
    {
        doorsWithKeysCollected.Add(doorName);
    }

    public bool IsThisKeyCollected(string doorName)
    {
        return doorsWithKeysCollected.Contains(doorName);
    }
}
