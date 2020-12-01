
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This componenet rotate the object in fixed speed
*/
public class Rotator : MonoBehaviour
{
    [Tooltip("Rotation speed in degree per second")]
    [SerializeField] 
    public float speed = 1f;
    Vector3 progress = new Vector3();

    // Start is called before the first frame update
    void Start()
    {   
        transform.rotation = Quaternion.Euler(0,0,0);;
    }

    // Update is called once per frame
    void Update()
    {   
        progress += new Vector3(0,0,speed*Time.deltaTime); //set's a new vector that represnt the rotation of the object (around z axis)
        transform.rotation = Quaternion.Euler(0,0,progress.z); //set the coordinates to the object
    }
}
