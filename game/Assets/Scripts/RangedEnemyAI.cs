using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    

    [SerializeField]
    private const float fireRate = 1.0f;
    private float nextFire = 3.0f; // dictates how long an enemy will wait between shots
    // TODO: dont know how to do this yet

    [SerializeField]
    private int numShots = 1; // determines how many shots enemy fires in one go
    //TODO for now numshots is 1 until i figure out the cooldown Timer

    [SerializeField]
    private float speed = 0.05f; // enemy's movement speed

    [SerializeField]
    private float proximityRadius = 5.0f; // how close enemy needs to get until
    //it decides to stop moving towards player
    private bool withinFiringRange;
    // stores calculation to see if player is within proximityRadius of enemy


    private bool canFire = true; // dicatates whether enemy can fire or not
    private float distance; // stores distance between enemy and player

    private Rigidbody2D playerRb;
    private Vector2 playerPosition;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject attack;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTrajectory();
        MoveIn();
        if (Time.time > nextFire) {
            FireShots();
            nextFire = Time.time + fireRate;
        }

    }


    private void MoveIn() {
        
        if (!withinFiringRange) {
            // make vector point towards the player and apply that to position
            rb.position +=
                (playerPosition - rb.position).normalized * speed;
        }
        
    }

   
    private void FireShots() {
        if (withinFiringRange) { // && canFire) 
            for (int i = 0; i < numShots; i++) {
                Instantiate(attack, rb.position, Quaternion.identity);
            }
        }
    }

   
    

    private void UpdateTrajectory() {

        playerPosition = playerRb.position;
        distance = Distance(playerPosition, rb.position);
        withinFiringRange = proximityRadius > distance;

        
    }

    //just the distance formula
    private float Distance(Vector2 point1, Vector2 point2) {

        float xDist = point1.x - point2.x;
        float yDist = point1.y - point2.y;
        xDist *= xDist;
        yDist *= yDist;
        
        return Mathf.Sqrt(xDist + yDist);
    }


}
