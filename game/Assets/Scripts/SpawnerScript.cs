using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private int lives;
    [SerializeField]
    private int maxEnemies;
    [SerializeField]
    private float cooldown; // cooldown in seconds

    private int currEnemies;
    private float range = 15f;
    private float nextSpawn;
    

    [SerializeField]
    private GameObject enemy1;
    [SerializeField]
    private GameObject enemy2;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject wall;

    private Vector3 spawnPosition;

    private void Awake() {
        spawnPosition = new Vector3(transform.position.x - 6, transform.position.y);
    }

    public void LoseLife() {
        if (lives > 0) {
            lives--;
        }
        else {
            Destroy(gameObject);
            wall.GetComponent<WallScript>().DamageWall();
        }
    }

    private void Update() {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (currEnemies < maxEnemies) {
            if (distance < range) {
                if (Time.time > nextSpawn) {
                    Instantiate(enemy1).transform.position = spawnPosition;
                    Instantiate(enemy2).transform.position = spawnPosition;
                    currEnemies += 2;
                    nextSpawn = Time.time + cooldown;
                }
            }
        }
    }

}
