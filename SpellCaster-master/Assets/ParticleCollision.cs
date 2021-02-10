using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private int col = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(start, direction, out hit))
        {

            if (hit.collider.gameObject.CompareTag("Enemy") 
                && col >= 20)
            {
                col = 0;
                Debug.Log("Raycast hit");
                
                hit.collider.gameObject.GetComponent<Bat>().GetComponent<Rigidbody>().AddForce(transform.forward*100);
            }
        }
        col++;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collided with particle");
    }
}
