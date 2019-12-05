using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    readonly private int numJumps = 2;

    private int jumpsLeft;
    private Vector2 direction;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = numJumps;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        GetMovementInput();
        Move();
    }

    private void GetMovementInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        
    }

    private void Move()
    {
        // moves left to right
        rb.position += direction * speed;
        direction = Vector2.zero;

        // does a jump
        if (Input.GetKeyDown(KeyCode.W) && jumpsLeft != 0) {
            jumpsLeft--;
            rb.velocity = new Vector2(0, jumpHeight);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Ground")) {
            jumpsLeft = numJumps;
        }
    }
}
