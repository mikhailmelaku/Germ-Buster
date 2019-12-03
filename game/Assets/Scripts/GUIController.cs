using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public GameObject interfaceDisplay;
    public GameObject healthbar;
    public Image healthbarImage;
    public float healthPercent = 100f;
    

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void DamageAnimation() {
        // finds the objects it needs to act on (healthbar in this case)
        interfaceDisplay = GameObject.Find("GUI");
        healthbar = interfaceDisplay.transform.GetChild(0).gameObject;
        healthbarImage = healthbar.GetComponent<Image>();

        // this is code that updates gui to reflect current health.
        if (healthbarImage.color.a > 0.1) {
            Color tempColor = healthbarImage.color;
            tempColor -= new Color(0, 0, 0, 0.1f);
            healthbarImage.color = tempColor;
        }
        
        healthbarImage.GetComponent<RectTransform>().position += new Vector3(0, 10f, 0);
        
    }

    
}
