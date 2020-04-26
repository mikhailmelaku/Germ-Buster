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
    private const int JUMPS_MAX = 2;

    private int jumpsLeft;
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

        jumpsLeft = JUMPS_MAX;

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
    /*TODO TODO TODO this cant be most efficient way of doing this
     * changes sprite to standing sprite then changes to crouch sprite. the whole time
     * player is pressing S to crouch, sprite is changing back an forth
     * TODO if game is lagging suspect this
     */
    private void GetMovementInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (direction.x < 0)
        {
            //sr.sprite = crouching ? leftCrouchSprite : leftSprite;
            sr.sprite = leftSprite;
        }
        else if (direction.x > 0)
        {
            //sr.sprite = crouching ? rightCrouchSprite : rightSprite;
            sr.sprite = rightSprite;
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && jumpsLeft != 0) {
            //jumpInputted = true;
            --jumpsLeft;
            rb.velocity = Vector2.up * jumpHeight;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            Crouch();
        }

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !grounded) {
            rb.velocity = Physics2D.gravity;
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) {
            Stand();
        }
        
        
        
    }

    private void Move()
    {

        // moves left to right
        rb.position += direction * speed;

        // does a jump
        /*
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
        
        
        if (jumpInputted && jumpsLeft != 0) {
            jumpInputted = false;
            jumpsLeft--;
            rb.velocity = Vector2.up * jumpHeight;
        }
        
        */
    }

    private void Crouch() {
        if (grounded)
        {
            crouching = true;

            if (sr.sprite == leftSprite)
            {
                sr.sprite = leftCrouchSprite;
            }
            else if (sr.sprite == rightSprite)
            {
                sr.sprite = rightCrouchSprite;
            }

            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.28f, 0.72f);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.26f);
        }
    }

    private void Stand() {
        crouching = false;

        if (sr.sprite == leftCrouchSprite)
        {
            sr.sprite = leftSprite;
        }
        else if (sr.sprite == rightCrouchSprite)
        {
            sr.sprite = rightSprite;
        }

        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.28f, 1.28f);
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
    }

    void OnTriggerExit2D(Collider2D coll) {
        grounded = false;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Ground")) {
            grounded = true;
            jumpsLeft = JUMPS_MAX;
        }
    }

}
