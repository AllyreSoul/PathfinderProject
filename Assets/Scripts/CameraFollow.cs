using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform camera;
    public Rigidbody2D player;
    Vector2 movement;
    void LateUpdate(){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            Vector2 offset = new Vector2();
            offset = new Vector2(0, 0);
            offset.x += movement.x * 0.07f;
            offset.y += movement.y * 0.07f;
            camMovement(offset);
        }

        void camMovement(Vector2 offset)
        {
            Vector2 desPos = Vector2.Lerp(camera.position, player.position, 0.1f);
            Rigidbody2D rig = camera.gameObject.GetComponent<Rigidbody2D>();
            rig.MovePosition(desPos);
        }
}