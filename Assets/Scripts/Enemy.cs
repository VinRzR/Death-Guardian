using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 2.8f;
    public float knockTime = 0.3f;
    public Animator animatorenemy;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1* Mathf.Abs(transform.localScale.x), transform.localScale.y, 0);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y,0);
        }
  
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction.normalized;


    }
    private void FixedUpdate()
    {
        moveCharacter(movement);

    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));       
    }

}
