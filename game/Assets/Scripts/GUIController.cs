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
    public GameObject interfaceDisplay;

    public GameObject healthbar;
    public Image healthbarImage;
    public float health = 100f; // player health
    
    public GameObject transitionScreen;
    public Image transitionScreenImage;
    private float transitionSeconds = 3f;

    private RectTransform rectangle;
    private float maxHealth, minHealth;

    void Awake() {
        rectangle = healthbar.GetComponent<RectTransform>();

        maxHealth = healthbar.GetComponent<RectTransform>().rect.xMax;
        minHealth = healthbar.GetComponent<RectTransform>().rect.xMin;

        // finds the objects it needs to act on (healthbar in this case)
        interfaceDisplay = GameObject.Find("GUI");
        healthbar = interfaceDisplay.transform.GetChild(1).gameObject;
        healthbarImage = healthbar.GetComponent<Image>();
    }

    public void DamageAnimation() {

        health = health < 0 ? 0 : health;

        float width = Mathf.Abs(maxHealth - minHealth);

        // this is code that updates gui to reflect current health.
        if (health >= 0) {
            rectangle.sizeDelta = new Vector2(width * health / 100, rectangle.sizeDelta.y);
        }
        else {
            Debug.Log("game over");
            //TODO: make a game over / restart screen.
        }
        
        Debug.Log("health is: " + health);
        
    }

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
}
