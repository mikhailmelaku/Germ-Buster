using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    public GameObject interfaceDisplay;

    public GameObject healthbar;
    public Image healthbarImage;
    public float health = 100f; // player health

    public GameObject transitionScreen;
    public Image transitionScreenImage;
    private float transitionSeconds = 3f;
    private bool transitionCompleted;


    public void DamageAnimation() {
        // finds the objects it needs to act on (healthbar in this case)
        interfaceDisplay = GameObject.Find("GUI");
        healthbar = interfaceDisplay.transform.GetChild(0).gameObject;
        healthbarImage = healthbar.GetComponent<Image>();

        // this is code that updates gui to reflect current health.
        if (healthbarImage.color.a > 0.1) {
            Color tempColor = healthbarImage.color;
            tempColor -= new Color(0, 0.1f, 0.1f, 0);
            healthbarImage.color = tempColor;
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
