using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Rigidbody2D>().position =
                new Vector3(17, -2);
        }

        GameObject.Find("GUI").GetComponent<GUIController>().DamageAnimation(10f);

    }
}
