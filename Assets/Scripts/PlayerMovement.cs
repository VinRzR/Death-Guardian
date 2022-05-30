using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Animator transformado;
    public playervida playervida;
    Vector2 movement;

    public GameObject ap;

    // Update is called once per frame
    void Update()
    {
        //if (playervida.playercurrentHealth <= playervida.maxHealth / 2)
        //{
        //    animator = transformado;
        //}
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (movement.x != 0 | movement.y != 0)
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }

        

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
    public void LockAttack()
    {
        animator.SetFloat("AttackH", movement.x);
        animator.SetFloat("AttackV", movement.y);
    }
    void FixedUpdate()
    {
        //movimento

        //trava o personagem
        //if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        //{
        //    rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        //}

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
