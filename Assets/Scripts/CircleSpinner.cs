using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpinner : MonoBehaviour
{
    public int Distance
    {
        get => distance;

        private set
        {
            if (value != distance)
            {
                distance = value;
                DistanceChanged.Invoke();
            }
        }
    }

    public event Action DistanceChanged;

    private float velocity;
    private float acceleration;
    private float angularDistance = 0;
    private int distance = 0;

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

    public void ResetCircle()
    {
        distance = 0;
        angularDistance = 0;
        transform.rotation = Quaternion.identity;
        velocity = 0;
    }
}
