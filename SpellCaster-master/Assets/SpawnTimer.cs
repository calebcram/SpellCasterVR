using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        GameObject enemy = (GameObject) Instantiate(spawnee, transform.position, transform.rotation);
        enemy.transform.SetPositionAndRotation(transform.position + new Vector3(10,10,10), transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }

    }
}