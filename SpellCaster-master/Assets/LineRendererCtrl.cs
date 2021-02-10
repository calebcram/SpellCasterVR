using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.GetComponent<LineRenderer>().enabled = (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.0);
        
    }
}
