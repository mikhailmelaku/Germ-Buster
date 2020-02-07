using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLaserMovement : MonoBehaviour
{
   
    private Rigidbody2D rb;
    private GameObject player;
    // TODO add reference to GUI element that controls health display
    private GameObject GUI;

    [SerializeField]
    private float attackSpeed = 1.25f;
    [SerializeField]
    private float attackDuration = 1.5f; // attack duartion in seconds
    [SerializeField]
    private float damage = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        GUI = GameObject.Find("GUI");

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
        if (coll.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            //FIXME: add damage system here
            GUI.GetComponent<GUIController>().DamageAnimation();

            //following line prevents player from getting knocked back way too far
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }
    }
    
}
