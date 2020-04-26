using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(Rigidbody2D))]

public class AttackMovement : MonoBehaviour
{

    private GameObject player;
    
    
    public static float attackDuration = 1.0f;

    public static float attackSpeed = 10.0f;

    private Rigidbody2D rb;
    
    private Vector2 direction;

    // Start is called before the first frame update
    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");

        if (player.GetComponent<SpriteRenderer>().sprite.name == "PlayerSpriteSheet_0" ||
            player.GetComponent<SpriteRenderer>().sprite.name == "playerSpriteSheetCrouch_0") {
            direction = Vector2.left;
        }
        else {
            direction = Vector2.right;
        }

        rb.velocity = direction * attackSpeed;
        DestroyAttack(attackDuration);
    }

    private void DestroyAttack(float delay)
    {
        Destroy(gameObject, delay);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy")) {
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.CompareTag("MultiHit")) {
            coll.gameObject.GetComponent<SpawnerScript>().LoseLife();
        }

        if (!coll.gameObject.CompareTag("Player")) {
        Destroy(gameObject);
        }

    }

}
