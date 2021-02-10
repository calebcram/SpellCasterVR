using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private ParticleSystem.EmissionModule ps;
    public GameObject bullet;
    public GameObject fire;
    //public AudioSource source;
    public AudioClip water;

    void Start()
    {
        //source = GetComponent<AudioSource>();
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    void Update()
    {
        if (Mathf.Abs((fire.transform.position.x - transform.position.x)) < .05
            && Mathf.Abs((fire.transform.position.y - transform.position.y)) < .05
            && Mathf.Abs((fire.transform.position.z - transform.position.z)) < 0.5
           )
        {
            //Too lazy to invert;
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                //source.PlayOneShot(water, 0.5f);
                GetComponent<AudioSource>().Play();


            }
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                print("spawned");
                GetComponentInChildren<ParticleSystem>().Play();
                OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponentInChildren<ParticleSystem>().Stop();
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collided with particle");
    }
}
