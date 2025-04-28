using System.Collections;
using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public static HealthController instance;

    public int health;
    public TMP_Text healthText;

    private float _healthPercentage;

    public SliderController SliderController;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        HealthBar();
    }
    private void Update()
    {
        HealthBar();
        DisplayTexts();
        Die();
    }
    private void HealthBar()
    {
        SliderController._slider.value = health;

        SliderController._fillImage.enabled = SliderController._slider.value > SliderController.minValue;

        _healthPercentage = (float)SliderController._slider.value / SliderController.maxValue;

        if (_healthPercentage > 0.7f)
        {
            SliderController._fillImage.color = Color.green;
        }
        else if (_healthPercentage > 0.35f)
        {
            SliderController._fillImage.color = Color.yellow;
        }
        else
        {
            SliderController._fillImage.color = Color.red;
        }
    }
    public void DecreaseHealth(int value)
    {
        health -= value;
        if (health <= 0)
        {
            health = 0;
        }
    }
    public void DisplayTexts()
    {
        healthText.text = health.ToString();
    }
    public void Die()
    {
        if (health == 0)
        {
            Destroy(gameObject, 1f);
        }
    }
}
