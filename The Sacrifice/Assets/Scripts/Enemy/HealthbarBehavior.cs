using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehavior : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;
    public bool fadeIfFull;
    public bool followEnemy;
    //public Color healthColorLow;
    //public Color healthColorHigh;

    public void SetHealth(float health, float healthMax) {
        if (fadeIfFull == true) {
            slider.gameObject.SetActive(health < healthMax);
        }
        slider.value = health;
        slider.maxValue = healthMax;

        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(healthColorLow, healthColorHigh, slider.normalizedValue);
    }
    // Start is called before the first frame update
    void Start()
    {
    }
        

    // Update is called once per frame
    void Update()
    {
        if (followEnemy == true) {
            slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        }
    }
}
