using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    private float speed = 0.05f; // enemy's movement speed
    [SerializeField]
    private float knockback = 1.0f; // determines how far the enemy knocks the player back

    private bool touching; // prevents enemy from moving if its touching the player

    private Vector2 playerPosition;
    private Rigidbody2D rb;
    private Rigidbody2D playerRb;
    private Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
        touching = playerCollider.IsTouching(GetComponent<Collider2D>());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTrajectory();
        MoveIn();
        MeleeAttack();
    }

    private void MoveIn()
    {
        
        if (!touching)
        {
            // make vector point towards the player and apply that to position

            rb.position +=
                (playerPosition - rb.position).normalized * speed;
       
        }

    }

    private void UpdateTrajectory()
    {
        if (!touching) {
            playerPosition = playerRb.position;
        }
    }

    private void MeleeAttack() {
        if (touching) {
            playerRb.AddForce(Vector2.left);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        touching = coll.gameObject.name == "Player";
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        touching = false;
    }
}
