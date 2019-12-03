using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEAttackMovement : MonoBehaviour
{
    private GameObject player;
    private Sprite playerSprite;
    private Rigidbody2D rb;
    private Collider2D attackCollider;
    public string[] EnemyList = { "RangedEnemy", "Enemy" };

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackCollider = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player");
        playerSprite = player.GetComponent<SpriteRenderer>().sprite;

        AnimateAttack();
        DestroyAttack(AttackMovement.attackDuration);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AnimateAttack() {

        //player.GetComponent<SpriteRenderer>().sortingOrder = 2;

        switch (playerSprite.name)
        {
            case "PlayerSpriteSheet_0":
                direction = Vector2.left;
                break;
            case "PlayerSpriteSheet_1":
                direction = Vector2.right;
                break;
            case "PlayerSpriteSheet_2":
                direction = Vector2.down;
                gameObject.transform.eulerAngles = new Vector3(0f, 0f, 90.0f);
                break;
            default:
                direction = Vector2.up;
                gameObject.transform.eulerAngles = new Vector3(0f, 0f, 90.0f);
                break;
        }

        rb.velocity = direction * AttackMovement.attackSpeed;
    }

    private void DestroyAttack(float delay) {
        Destroy(gameObject, delay);
    }


    // when a collision happens, looks through EnemyList array to see if it hit an enemy
    // if it was, deletes enemy. laser is deleted upon any collision
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.gameObject.CompareTag("Player")) {
            foreach (string enemyName in EnemyList) {
                if (coll.gameObject.name == enemyName) {
                    Destroy(coll.gameObject);
                }
            }
            Destroy(gameObject);
        }
    }

}
