using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIRDSEYEattack : MonoBehaviour
{
    [SerializeField]
    private GameObject attack;

    private SpriteRenderer playerSpriteRenderer;
    private Rigidbody2D rb;
    
    private Vector2 spawnOffset = Vector2.zero;
    //stores the distance infront of player that attack will spawn at

    /*
    [SerializeField]
    private Vector3 gunLength = new Vector3(1.0f, 0, 0);
    // this variable determines how far away the laser
    // is created from the player
    */
    
    private bool cooldown;

    
    // Start is called before the first frame update
    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetAttackInput();
    }


    private void GetAttackInput() {
        if (Input.GetButtonDown("Fire3") && !cooldown) {  // left shift
            cooldown = true;

            // determines what side player's facing, then spawns attack infront of player
            switch (playerSpriteRenderer.sprite.name)
            {
                case "PlayerSpriteSheet_0":
                    spawnOffset = Vector2.left;
                    break;
                case "PlayerSpriteSheet_1":
                    spawnOffset = Vector2.right;
                    break;
                case "PlayerSpriteSheet_2":
                    spawnOffset = Vector2.down;
                    break;
                default:
                    spawnOffset = Vector2.up;
                    break;
            }

            Instantiate(attack, rb.position + spawnOffset, transform.rotation);

            spawnOffset = Vector2.zero;

            Invoke("ResetCooldown", PlayerAttack.cooldownTimer);
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            GameObject.Find("PauseGUI").GetComponent<PauseMenu>().PauseGame();
        }

    }

    private void ResetCooldown() {
        cooldown = false;
    }
}
