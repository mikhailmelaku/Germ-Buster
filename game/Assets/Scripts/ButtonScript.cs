using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private GameObject button;

    [SerializeField]
    private Sprite pressedSprite;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject;
    }

    void OnTriggerEnter2D (Collider2D coll) {
        gameObject.GetComponent<SpriteRenderer>().sprite = pressedSprite;
    }
}
