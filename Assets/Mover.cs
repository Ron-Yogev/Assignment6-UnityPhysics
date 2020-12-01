using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += new Vector3(0, 0, speed*Time.deltaTime);
        }
        else if (Input.GetKey("down"))
        {
            transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey("right"))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("left"))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

    }
}
