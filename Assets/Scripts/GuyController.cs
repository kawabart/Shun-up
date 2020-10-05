using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class GuyController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private new Collider2D collider;
    private bool isGrounded = true;
    private Vector3 startPosition;
    private Quaternion startRotation;

    [SerializeField]
    private GameObject levelChangeTrigger;
    private bool levelChange = false;

    [SerializeField]
    private GameObject deathTrigger;
    private bool dead = false;

    public event Action Death;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");

        if ((vertical > 0 && isGrounded) || (Input.GetButton("Jump") && isGrounded))
            Jump();
    }

    private void Jump()
    {
        isGrounded = false;
        rigidbody.AddForce(Vector2.up * 225);
    }

    public void OnObstacleCollision()
    {
        Death.Invoke();
    }

    public IEnumerator PlayDeathSequence()
    {
        levelChangeTrigger.SetActive(false);
        collider.isTrigger = true;

        yield return new WaitUntil(() => dead);

        dead = !dead;
        ResetGuy();
        collider.isTrigger = false;
        levelChangeTrigger.SetActive(true);
    }

    public IEnumerator PlayLevelChangeSequence()
    {
        Jump();
        collider.isTrigger = true;

        yield return new WaitUntil(() => levelChange);

        levelChange = !levelChange;
        ResetGuy();
        collider.isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == levelChangeTrigger)
            levelChange = true;
        else if (collision.gameObject == deathTrigger)
        {
            dead = true;
            Death.Invoke(); //Hotfix death without collision
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void ResetGuy()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
    }
}
