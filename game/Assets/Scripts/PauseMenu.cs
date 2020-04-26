using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool paused, gameOver;

    [SerializeField]
    private Image icon;
    [SerializeField]
    private Sprite pauseSprite;
    [SerializeField]
    private Sprite gameOverSprite;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject GUI;

    public void PauseGame() {
        if (!gameOver) {

            icon.sprite = pauseSprite;
            icon.enabled = !icon.enabled;

            if (!paused) {
                Time.timeScale = 0;
                paused = true;
            }
            else {
                Time.timeScale = 1;
                paused = false;
            } 
        }
    }

    public void GameOver() {
        gameOver = true;
        icon.sprite = gameOverSprite;
        icon.enabled = true;

        player.GetComponent<Rigidbody2D>().position = new Vector3(-13, -19);

    }

    void Update() {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.C)) {
                gameOver = false;
                player.GetComponent<Rigidbody2D>().position = new Vector3(-11, 0);
                GUI.GetComponent<GUIController>().LoseLife();
                icon.enabled = false;
            }
        }
    }
}
