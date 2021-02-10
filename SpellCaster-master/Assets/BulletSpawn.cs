using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject bullet;
    public GameObject storm;
    public GameObject lightning;
    public AudioSource source;
    public AudioClip lightningSound;
    public AudioClip fireball;

    private int hit = 0;
    private float lightningZ;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject water = GameObject.Find("WaterSpawner");

        //Storm ball
        if (Mathf.Abs((water.transform.position.x - transform.position.x)) < .05
            && Mathf.Abs((water.transform.position.y - transform.position.y)) < .05
            && Mathf.Abs((water.transform.position.z - transform.position.z)) < 0.5
           )
        {
            if (hit > 20)
            {
                Debug.Log("Gary GILLESPIE");

                GameObject storming = (GameObject)Instantiate(storm, transform.position, new Quaternion(0, 0, 0, 0));
                storming.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
                OVRInput.SetControllerVibration(10, 10, OVRInput.Controller.RTouch);
                OVRInput.SetControllerVibration(10, 10, OVRInput.Controller.LTouch);
                hit = 0;

            }
            else
            {
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            }
        }
        //Fireball
        else if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
   

                print("spawned");
                GameObject bull = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
                bull.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);

                source.PlayOneShot(fireball, 0.5f);

                OVRInput.SetControllerVibration(10, 10, OVRInput.Controller.RTouch);


        }
        //Thunder
        else if (OVRInput.Get(OVRInput.Button.One))
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {

                lightningZ = transform.position.z;
                Debug.Log($"Z is {lightningZ}");


            }

            if (transform.position.z >= lightningZ + 0.5f && hit >= 40)
            {
                hit = 0;
                source.PlayOneShot(lightningSound, 0.5f);
                GameObject bull = (GameObject)Instantiate(lightning, transform.position + new Vector3(0, 0, 10), transform.rotation);
                bull.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);
                OVRInput.SetControllerVibration(10, 10, OVRInput.Controller.RTouch);
            }
        }
        else
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }

        
        hit++;
    }
}
