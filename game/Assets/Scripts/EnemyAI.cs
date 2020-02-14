using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private const float DISTANCE_TO_CAMERA_EDGE = 14f;

    [SerializeField]
    private float speed = 0.05f; // enemy's movement speed
    private float vision = DISTANCE_TO_CAMERA_EDGE;
    private float knockback = 5f; // how hard the enemy hits
    private float distance;

    private Rigidbody2D playerRb;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField]
    private Sprite leftSprite;
    [SerializeField]
    private Sprite rightSprite;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveIn();
    }

    private void MoveIn() {
        if (!rb.IsTouching(playerRb.GetComponent<BoxCollider2D>())) {
            distance = Mathf.Abs(rb.position.x - playerRb.position.x);
            if (distance <= vision) {
                distance = rb.position.x - playerRb.position.x;
                // update sprite to look left/right
                if (distance < 0) {
                    sr.sprite = rightSprite;
                }
                else {
                    sr.sprite = leftSprite;
                }

                // move
                rb.position +=
                    (playerRb.position - rb.position).normalized * speed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        
        if (coll.gameObject.CompareTag("Player")) {
            // knockback effect
            Vector2 direction = rb.position.x > playerRb.position.x ? Vector2.left : Vector2.right;
            playerRb.AddForce(direction * knockback, ForceMode2D.Impulse);

            // deals damage
            GameObject.Find("GUI").GetComponent<GUIController>().DamageAnimation(10f);
        }

        
    }

  

}
