using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject attack;

    private float nextFire;
    private float fireRate = 2f;
    private float x, y;
    private Vector3 spawnOffset;

    public Vector2 direction;
    

    void Awake() {
        x = Mathf.Cos(gameObject.transform.localEulerAngles.z * Mathf.PI / 180);
        y = Mathf.Sin(gameObject.transform.localEulerAngles.z * Mathf.PI / 180);
        
        direction = new Vector2(x, y);
        spawnOffset = direction.normalized * 4;
    }

    private void OnTriggerStay2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Player")) {
            if (Time.time > nextFire) {
                FireProjectile();
                nextFire = Time.time + fireRate;
            }
        }
    }

    private void FireProjectile() {
        Instantiate(attack, gameObject.transform.position + spawnOffset, gameObject.transform.rotation);
    }
    
}
