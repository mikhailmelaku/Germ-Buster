using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool paused;

    [SerializeField]
    private Image pauseSprite;

    /*void Awake() {
        pauseSprite = gameObject.GetComponent<Image>();
    }*/

    public void PauseGame() {
        if (!paused) {
            Time.timeScale = 0;
            paused = true;
        }
        else {
            Time.timeScale = 1;
            paused = false;
        } 
        pauseSprite.enabled = !pauseSprite.enabled;
    }
        
}
