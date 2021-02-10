using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSpawner : MonoBehaviour
{
    public GameObject[] flying;
    public bool wave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wave)
        {
            for(int i = 0; i < flying.Length; i++)
            {
                GameObject fly = (GameObject)Instantiate(flying[i], transform.position, transform.rotation);
            }
        }
    }
}
