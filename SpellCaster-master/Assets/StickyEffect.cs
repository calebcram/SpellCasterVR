using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StickyEffect : MonoBehaviour
{
    private int t = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(++t == 1000)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Hit terrain! {collision.collider.gameObject.name}");
        

        Debug.Log("Hit metal tagged object");

        Destroy(GetComponent<Rigidbody>());
       
        if(collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.gameObject.tag == "ExplosiveBarrel")
        {
            SceneManager.LoadScene("Forest");
        }

        GetComponentInChildren<ParticleSystem>().emissionRate = 175;
        GetComponentInChildren<ParticleSystem>().startSize = 3;
        var ps = GetComponentInChildren<ParticleSystem>();
        var sh = ps.shape;
        sh.radius = 3;

    }
}
