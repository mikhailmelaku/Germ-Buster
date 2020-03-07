using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* TODO: just a note
 * health bar is full when right = 542
 * empty when right = 1200
 */


public class GUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject lifeCount;
    [SerializeField]
    private Sprite[] lifeSprites;

    public GameObject interfaceDisplay;

    public GameObject healthbar;
    public Image healthbarImage;
    public float health = 100f; // player health
    private int lives = 3;

    public GameObject transitionScreen;
    public Image transitionScreenImage;
    private float transitionSeconds = 3f;

    private RectTransform rectangle;
    private float maxHealth, minHealth;
    private bool done = true;

    void Awake() {
        rectangle = healthbar.GetComponent<RectTransform>();

        maxHealth = healthbar.GetComponent<RectTransform>().rect.xMax;
        minHealth = healthbar.GetComponent<RectTransform>().rect.xMin;

        // finds the objects it needs to act on (healthbar in this case)
        interfaceDisplay = GameObject.Find("GUI");
        healthbar = interfaceDisplay.transform.GetChild(1).gameObject;
        healthbarImage = healthbar.GetComponent<Image>();
    }

    public void DamageAnimation(float damage) {

        health -= damage;
        health = health < 0 ? 0 : health;

        float width = Mathf.Abs(maxHealth - minHealth);

        // this is code that updates gui to reflect current health.
        if (health > 0) {
            rectangle.sizeDelta = new Vector2(width * health / 100, rectangle.sizeDelta.y);
            Debug.Log("health is: " + health);
        }
        else if (health - 0 < 0.001f) {
            Debug.Log("game over");
            GameObject.Find("PauseGUI").GetComponent<PauseMenu>().GameOver();
            rectangle.sizeDelta = new Vector2(width, rectangle.sizeDelta.y);
            health = 100f;
        }

    }

    // TODO: can use coroutine for transition to second part of level 1
   
    public void Transition() {
        StartCoroutine(AnimateTransition(transitionSeconds));
    }

    private IEnumerator AnimateTransition(float time) {

        float rate = 1 / time;
        Color tempColor = new Color(0, 0, 0, rate);

        for (int i = 1; i < 100; i++) {
            transitionScreenImage.color += tempColor;
            yield return new WaitForSeconds(time / 100);
        }
        SceneManager.LoadScene("Level1");
    }

    public void LoseLife() {
        if (lives != 0) {
            lives--;
            Debug.Log("you got " + lives + " lives left");
            lifeCount.GetComponent<Image>().sprite = lifeSprites[lives];
        }

        if (lives == 0) {
            Debug.Log("you lose.");
            lifeCount.GetComponent<Image>().sprite = lifeSprites[3]; 
        }
        // todo: what happens when you lose? title screen? level select?
        // todo: return to beginning of level and reset progress?
    }
}
