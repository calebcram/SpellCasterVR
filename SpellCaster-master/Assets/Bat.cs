using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public int health;
    public int delay;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;

        InvokeRepeating("HeadToPlayer", 0, delay);
        
    }

    // The target marker.
    public GameObject target;

    // Angular speed in radians per sec.
    float speed;

    public void HeadToPlayer()
    {
        Vector3 targetDir = GameObject.Find("Player").transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);

        GetComponent<Rigidbody>().AddForce((GameObject.Find("Player").transform.position - transform.position) * 5);
    }

    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collided with enemy");
        if (collider.gameObject.CompareTag("Particle")
            || collider.gameObject.CompareTag("Player")
            || collider.gameObject.CompareTag("Storm"))
        {
            Debug.Log("Collided with particle or player");
            if (--health <= 0)
            {
                GameObject.Find("Player").GetComponent<Player>().score++;
                Destroy(gameObject);
            }

            if (collider.gameObject.CompareTag("Particle"))
            {
                Destroy(collider.gameObject);
            }
            if (collider.gameObject.CompareTag("Storm"))
            {
                Destroy(gameObject);
            }
            if(collider.gameObject.CompareTag("Player"))
            {
                collider.GetComponent<Player>().hp--;
            }
        }




    }

}
