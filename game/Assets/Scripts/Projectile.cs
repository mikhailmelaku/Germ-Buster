using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;

    private float speed = 0.3f;
    private float x, y;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();

        x = Mathf.Cos(gameObject.transform.localEulerAngles.z * Mathf.PI / 180);
        y = Mathf.Sin(gameObject.transform.localEulerAngles.z * Mathf.PI / 180);
        direction = new Vector2(x, y);
    }

    void FixedUpdate()
    {
        rb.position += direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if (!coll.gameObject.CompareTag("Projectile") && !coll.gameObject.CompareTag("Attack"))
            Destroy(gameObject);
        if (coll.gameObject.CompareTag("Player"))
            GameObject.Find("GUI").GetComponent<GUIController>().DamageAnimation(15f);
    }
}
