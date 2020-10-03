using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpinner : MonoBehaviour
{
    float velocity;
    float acceleration;
    float angularDistance = 0;

    public int Distance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        velocity = Time.fixedDeltaTime;
        acceleration = Time.fixedDeltaTime / 2;
        Distance = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, velocity);
        angularDistance += velocity;
        Distance = (int)(angularDistance / 36);
        velocity += acceleration;
    }
}
