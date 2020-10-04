using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GuyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.AddForce(Vector2.up * 200);
        Debug.Log("Jump!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
