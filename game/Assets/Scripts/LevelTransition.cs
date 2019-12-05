using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public GameObject GUI;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Player")) {

            Debug.Log("Contact detected");
            GUI.GetComponent<GUIController>().Transition();
        }
    }
}