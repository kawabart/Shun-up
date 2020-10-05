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

    [SerializeField]
    private GameObject levelChangeTrigger;
    private bool levelChange = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");

        if ((vertical > 0 && isGrounded) || (Input.GetButton("Jump") && isGrounded))
            Jump();
    }

    void Jump()
    {
        isGrounded = false;
        rigidbody.AddForce(Vector2.up * 225);
    }

    public IEnumerator PlayLevelChangeSequence()
    {
        Jump();
        collider.isTrigger = true;

        yield return new WaitUntil(() => levelChange);

        levelChange = !levelChange;
        transform.position = startPosition;
        collider.isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == levelChangeTrigger)
            levelChange = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
