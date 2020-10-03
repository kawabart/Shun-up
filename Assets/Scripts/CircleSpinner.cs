using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpinner : MonoBehaviour
{
    float velocity;
    float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Time.fixedDeltaTime;
        acceleration = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, velocity);
        velocity += acceleration;
    }
}
