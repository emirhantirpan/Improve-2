using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Gradient gradient;
    
    public void SetMaxHealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    }

    public void SetHealth(int health)
    {
        Slider.value=health;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
