using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    private float speed = 0.05f; // enemy's movement speed
    private float vision = 5f;  // how close you need to be for enemy to see you
    private float knockback = 5f; // how hard the enemy hits

    private Rigidbody2D playerRb;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveIn();
    }

    private void MoveIn() {
        if (!rb.IsTouching(playerRb.GetComponent<BoxCollider2D>())) {
            if (Mathf.Abs(rb.position.x - playerRb.position.x) <= vision) {
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

            // deals damage FIXME: dont allow it to go into negatives
            GameObject.Find("GUI").GetComponent<GUIController>().health -= 10f;
            GameObject.Find("GUI").GetComponent<GUIController>().DamageAnimation();
        }

        
    }

}
