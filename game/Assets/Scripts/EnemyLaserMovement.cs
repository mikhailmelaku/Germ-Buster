using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private GameObject player;

    [SerializeField]
    private float attackSpeed = 1.25f;
    [SerializeField]
    private float attackDuration = 1.5f; // attack duartion in seconds

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        AnimateAttack();
        Destroy(gameObject, attackDuration);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, attackDuration);
    }

    private void AnimateAttack() {
        rb.velocity =
            (player.GetComponent<Rigidbody2D>().position - rb.position) * attackSpeed;
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.name == "Player") {
            Destroy(gameObject);
            //FIXME: add damage system here

            //

            //following line prevents player from getting knocked back way too far
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }
    }
    
}
