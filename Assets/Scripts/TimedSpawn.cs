using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    // public Transform enemy;
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnDelay;
    public float spawnTime;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        GameObject clone = Instantiate(spawnee, new Vector3(10.0f, 0.12f, 622.28f), transform.rotation);
        
        clone.active = true;
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }



}
