using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlledMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public SpriteRenderer entity;
	public Rigidbody2D rb;
	Vector2 movement;

 	// Update is called once per fram

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        if (movement.x > 0)
            {
                entity.flipX = false;  
            }
            
        if (movement.x < 0)
            {
                entity.flipX = true;
            }
    }
}