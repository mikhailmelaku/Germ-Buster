using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerAttack : MonoBehaviour
{



    public GameObject attack;

    private bool cooldown; // implicit initializiation to false


    public static float cooldownTimer = 0.5f;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetAttackInput();
    }

    private void GetAttackInput()
    {

        if (Input.GetButtonDown("Fire3") && !cooldown) // Press Left Shift
        {
            cooldown = true;
            Instantiate(attack, transform.position, transform.rotation);

            Invoke("ResetCooldown", cooldownTimer);
        }
   
    }

    private void ResetCooldown()
    {
        cooldown = false;
    }

}


