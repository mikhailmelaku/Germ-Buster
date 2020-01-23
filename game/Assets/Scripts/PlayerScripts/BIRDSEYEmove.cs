using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BIRDSEYEmove : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 0.1f;

    private Vector2 direction;

    private bool canMove = true;
    private int spriteNum = 2;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField]
    private Sprite upSprite;
    [SerializeField]
    private Sprite downSprite;
    [SerializeField]
    private Sprite leftSprite;
    [SerializeField]
    private Sprite rightSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetMovementInput();
        Move();
    }
    
    private void GetMovementInput()
    {
        float xPos = Input.GetAxisRaw("Horizontal");
        float yPos = Input.GetAxisRaw("Vertical");
        direction = new Vector2(xPos, yPos);


        if (Mathf.Abs(xPos - 0.0f) > 0.0001f) { // if xpos isnt 0, check left or right
            spriteNum = xPos < 0.0f ? 0 : 1;
        }
        if (Mathf.Abs(yPos - 0.0f) > 0.0001f) {
            spriteNum = yPos < 0.0f ? 2 : 3;
        }
    }

    private void Move() {
        
        switch (spriteNum) {

            case 0:
                sr.sprite = leftSprite;
                break;
            case 1:
                sr.sprite = rightSprite;
                break;
            case 2:
                sr.sprite = downSprite;
                break;

            case 3:
                sr.sprite = upSprite;
                break;
        }

        if (canMove) {
            rb.position += direction * playerSpeed;
            direction = Vector2.zero;
        }

        
    }

    
}
