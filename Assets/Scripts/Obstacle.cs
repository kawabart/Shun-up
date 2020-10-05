using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform target;
    private bool isMounted = false;
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target);
        transform.Rotate(Vector3.forward, -90);
        transform.Rotate(Vector3.right, -90);
        var collider = gameObject.AddComponent<PolygonCollider2D>();
        collider.isTrigger = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isMounted)
        {
            float step = speed * Time.fixedDeltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<GuyController>();

        if (player)
            player.OnObstacleCollision();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isMounted && collision.gameObject == target.gameObject)
        {
            transform.parent = target;
            isMounted = true;
            GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
