using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpModifier : MonoBehaviour
{
    [SerializeField]
    private float fallMultiplier = 1f;

    [SerializeField]
    private float lowJumpMultiplier = 1f;

    [SerializeField]
    private float fastFallSpeed = 1f;

    private Rigidbody2D rb;
    
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update() {

        // tapping jump gives you a smaller jump, holding gives you a bigger one
        /*
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W)) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }
        */

        // does a fast fall
        if (Input.GetKeyDown(KeyCode.S)) {
            rb.velocity = Physics2D.gravity;
        }

    }
}
