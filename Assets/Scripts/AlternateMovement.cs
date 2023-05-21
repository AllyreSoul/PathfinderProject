using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public SpriteRenderer entity;
	public Rigidbody2D body;
    public float maxMoveSpeed = 10f;
    private float previousX;
    private float previousY;
	Vector2 movement;

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (body.velocity.x < maxMoveSpeed && body.velocity.x > -maxMoveSpeed){
            body.AddForce(new Vector2(movement.x * moveSpeed, 0), ForceMode2D.Impulse);
        }
        if(body.velocity.y < maxMoveSpeed && body.velocity.y > -maxMoveSpeed){
            body.AddForce(new Vector2(0, movement.y * moveSpeed), ForceMode2D.Impulse);
        }
        if(previousX != movement.x){
            body.velocity = new Vector2(0, body.velocity.y);
        }
        if(previousY != movement.y){
            body.velocity = new Vector2(body.velocity.x, 0);
        }
        if (movement.x > 0)
            {
                entity.flipX = false;  
            }
            
        if (movement.x < 0)
            {
                entity.flipX = true;
            }
        previousX = movement.x;
        previousY = movement.y;
    }

}
