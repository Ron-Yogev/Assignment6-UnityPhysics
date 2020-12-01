using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This componenet scaling the object in fixed speed (increase and decrease like heartbeat)
*/
public class HeartBeats : MonoBehaviour
{
    [Tooltip("scaling speed in pixle per second")]
    [SerializeField]
    public float speed = 1f;
    //Vector3 original_size;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //original_size = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {

        float size = oscillate(timer, speed, 0.5f); // calculate the scale of the object by oscillate function 
        transform.localScale = new Vector3(size,size,size); // setting the object current scale
        timer += Time.deltaTime; // increase the time by unit time
    }

    /**
     * Side function that calculate a scale by given time, speed and scale
     */
    float oscillate(float time, float speed, float scale)
    {
        return Mathf.Sin(time * speed/Mathf.PI) * scale;
    }
}
