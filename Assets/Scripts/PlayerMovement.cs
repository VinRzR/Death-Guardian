using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    public GameObject ap;

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x < 0)
        {
            ap.transform.localPosition = new Vector3(-0.257f, 0.001f, ap.transform.localPosition.z);
        }
        else if (movement.x > 0)
        {
            ap.transform.localPosition = new Vector3(0.257f, 0.001f, ap.transform.localPosition.z);
        }

        if (movement.y < 0)
        {
            ap.transform.localPosition = new Vector3(0.001f, -0.257f, ap.transform.localPosition.z);
        }
        else if (movement.y > 0)
        {
            ap.transform.localPosition = new Vector3(0.001f, 0.257f, ap.transform.localPosition.z);
        }

    }

    void FixedUpdate()
    {
        //movimento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
