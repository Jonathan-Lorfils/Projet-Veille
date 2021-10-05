using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;
    public bool ennemy = true;

    // Update is called once per frame
    void Update()
    {
        if (ennemy)
        {
            slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        }
    }

    public void SetHealt(float healt, float maxHealt)
    {
        slider.gameObject.SetActive(healt < maxHealt);
        slider.value = healt;
        slider.maxValue = maxHealt;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
}
