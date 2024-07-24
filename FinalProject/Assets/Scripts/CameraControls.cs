using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject target; // Asign IN editor 

    public Vector3 posOffset;

    // Start is called before the first frame update
    void Start()
    { 
        transform.position = target.transform.position + posOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {
            transform.position = target.transform.position + posOffset;   
        }
        
    }
}
