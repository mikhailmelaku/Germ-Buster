using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(Rigidbody2D))]

// note : gonna break if player is named anything other than "Player"


public class AttackMovement : MonoBehaviour
{

    public GameObject player;

    
    public static float attackDuration = 1.0f;

   
    public static float attackSpeed = 10.0f;

    private Rigidbody2D rb;
    
    private Vector2 direction;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        //FIXME: trying to use trig
        //direction = new Vector2(1, transform.rotation.z) * attackSpeed;

        float playerAngle = player.transform.eulerAngles.z;
        playerAngle *= Mathf.PI / 180;     //conversion into radians
        direction = new Vector2(Mathf.Cos(playerAngle), Mathf.Sin(playerAngle))
                    * attackSpeed;

        rb.velocity = direction;
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
}
