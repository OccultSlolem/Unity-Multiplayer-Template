using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 movementVector;
    private bool held = false;
    public float speed = 3.5f;
    public float boundY = 2.5f; // Maximum vertical position of the paddle

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Called when the Move action is triggered from the input system
    void OnMove(InputValue movementValue) {
        movementVector = movementValue.Get<Vector2>();
        movementVector = movementVector.normalized * speed;
        held = movementValue.Get<Vector2>().normalized.y != 0;
        if (!held) { rb2d.velocity = Vector2.zero; }
    }

    void UpdatePosition() {
        // If paddle is above or below boundY, stop it from moving in that direction
        if (
            (transform.position.y > boundY && movementVector.y > 0) ||
            (transform.position.y < -boundY && movementVector.y < 0)
        ) { 
            movementVector = new Vector2 { x = 0, y = 0 };
        }
        
        movementVector.x = 0;
        rb2d.velocity = movementVector;
    }

    void Update() {
        if (held) {
            UpdatePosition();
        }
    }
}
