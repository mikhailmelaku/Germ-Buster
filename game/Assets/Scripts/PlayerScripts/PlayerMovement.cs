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

    private bool canDoubleJump;
    private bool grounded = true;
    private bool jumpInputted;
    private bool crouching;
    private Vector2 direction;

    [SerializeField]
    private Sprite leftSprite;
    [SerializeField]
    private Sprite rightSprite;

    [SerializeField]
    private Sprite leftCrouchSprite;
    [SerializeField]
    private Sprite rightCrouchSprite;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }
    
    // Update is called once per frame
    void Update() {
        GetMovementInput();
        //Move();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void GetMovementInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (Input.GetKeyDown(KeyCode.W)) {
            jumpInputted = true;
        }

        
        if (Input.GetKey(KeyCode.S) && grounded) {
            crouching = true;

            if (sr.sprite == leftSprite) {
                sr.sprite = leftCrouchSprite;
            }
            else if (sr.sprite == rightSprite) {
                sr.sprite = rightCrouchSprite;
            }

            gameObject.GetComponent<BoxCollider2D>().size.Set(1.28f, 0.72f);
        }
        else {
            crouching = false;

            if (sr.sprite == leftCrouchSprite) {
                sr.sprite = leftSprite;
            }
            else if (sr.sprite == rightCrouchSprite) {
                sr.sprite = rightSprite;
            }

            gameObject.GetComponent<BoxCollider2D>().size.Set(1.28f, 1.28f);

        }
        

        if (direction.x < 0) {
            sr.sprite = crouching ? leftCrouchSprite : leftSprite;
        }
        else if (direction.x > 0) {
            sr.sprite = crouching ? rightCrouchSprite : rightSprite;
        }
    }

    private void Move()
    {
        if (grounded) {
            canDoubleJump = true;
        }

        // moves left to right
        rb.position += direction * speed;

        // does a jump
        if (jumpInputted) {
            jumpInputted = false;
            if (grounded) {
                rb.velocity = Vector2.up * jumpHeight;
            }
            else if (canDoubleJump) {
                canDoubleJump = false;
                rb.velocity = Vector2.up * jumpHeight;
            }
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


    void OnTriggerExit2D(Collider2D coll) {
        grounded = false;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        grounded = true;
    }
}
