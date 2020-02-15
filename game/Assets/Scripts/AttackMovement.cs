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

        switch (player.GetComponent<SpriteRenderer>().sprite.name) {
            case "PlayerSpriteSheet_0":
                direction = Vector2.left;
                break;
            default:
                direction = Vector2.right;
                break;
        }

        rb.velocity = direction * attackSpeed;
        DestroyAttack(attackDuration);
    }

    // Update is called once per frame
    void Update()
    {

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
