using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingPlatformController : MonoBehaviour
{
    public float highLim = 190;
    public float lowLim = 170;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angles = transform.eulerAngles;
        if (transform.eulerAngles.z > highLim)
        {
            angles.z = highLim;
            transform.eulerAngles = angles;
        } 
        else if (transform.eulerAngles.z < lowLim)
        {
            angles.z = lowLim;
            transform.eulerAngles = angles;
        }
    }
}
