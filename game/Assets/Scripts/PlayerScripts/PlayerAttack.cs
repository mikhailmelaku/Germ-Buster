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

            if (sr.sprite.name == "playerSpriteSheetCrouch_0" || sr.sprite.name == "PlayerSpriteSheet_0") {
                spawnOffset = Vector2.left;
            }
            else {
                spawnOffset = Vector2.right;
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


