using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    readonly private int numJumps = 2;

    private int jumpsLeft;
    private Vector2 direction;

    [SerializeField]
    private Sprite leftSprite;
    [SerializeField]
    private Sprite rightSprite;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        jumpsLeft = numJumps;
    }
    
    // Update is called once per frame
    void Update() {
        GetMovementInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void GetMovementInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (direction.x < 0) {
            sr.sprite = leftSprite;
        }
        else if (direction.x > 0) {
            sr.sprite = rightSprite;
        }
    }

    private void Move()
    {
        // moves left to right
        rb.position += direction * speed;

        // does a jump
        if (Input.GetKeyDown(KeyCode.W) && jumpsLeft > 0) {
            rb.velocity = Vector2.up * jumpHeight;
            jumpsLeft--;
        }

        /*
        if (Input.GetKeyDown(KeyCode.W) && jumpsLeft != 0) {
            jumpsLeft--;
            rb.velocity = new Vector2(0, jumpHeight);
        }
        
        if (Input.GetKeyDown(KeyCode.D) && jumpsLeft < 2) {
            rb.velocity = new Vector2(0, fastFallSpeed);
        }
        */


    }

    void OnTriggerEnter2D(Collider2D coll) {
        jumpsLeft = numJumps;
    }
}
