using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField]
    private Sprite sp0;
    [SerializeField]
    private Sprite sp1;
    [SerializeField]
    private Sprite sp2;
    [SerializeField]
    private Sprite sp3;
    [SerializeField]
    private Sprite spLastWallOpen;

    private SpriteRenderer sr;

    [SerializeField]
    private GameObject lastWall;
    
    void Awake() {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void DamageWall() {
        gameObject.GetComponent<CompositeCollider2D>().offset += new Vector2(2, 0);

        switch (sr.sprite.name) {
            case "WallSpriteSheet_0":
                sr.sprite = sp1;
                break;
            case "WallSpriteSheet_1":
                sr.sprite = sp2;
                break;
            case "WallSpriteSheet_2":
                sr.sprite = sp3;
                gameObject.GetComponent<CompositeCollider2D>().enabled = false;
                break;
            case "WallSpriteSheet_3":
                lastWall.GetComponent<SpriteRenderer>().sprite = spLastWallOpen;
                lastWall.GetComponent<CompositeCollider2D>().enabled = false;
                break;
        }
    }
}
