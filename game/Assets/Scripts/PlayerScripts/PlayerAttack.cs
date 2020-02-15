using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerAttack : MonoBehaviour
{



    public GameObject attack;

    private bool cooldown; // implicit initializiation to false

    private Vector3 spawnOffset = Vector3.right;

    public static float cooldownTimer = 0.5f;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GetAttackInput();
    }

    private void GetAttackInput()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !cooldown) // Press Left Shift
        {
            cooldown = true;

            switch (sr.sprite.name) {
                case "PlayerSpriteSheet_0":
                    spawnOffset = Vector3.left;
                    break;
                default:
                    spawnOffset = Vector3.right;
                    break;
            }

            Instantiate(attack, transform.position + spawnOffset, transform.rotation);

            Invoke("ResetCooldown", cooldownTimer);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject.Find("PauseGUI").GetComponent<PauseMenu>().PauseGame();
        }

    }

    private void ResetCooldown()
    {
        cooldown = false;
    }

}


