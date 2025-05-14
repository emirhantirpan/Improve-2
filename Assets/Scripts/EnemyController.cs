using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string enemyName;
    public int enemyHealth;
    public int enemyLevel;

    public TMP_Text enemyNameText;
    public SliderController sliderController;
    public HealthController healthController;
    public LevelController levelController;

    public void Update()
    {
        Initialize();
        DisplayTexts();
    }
    public virtual void Initialize()
    {
        
    }
    public virtual void DisplayTexts()
    {
        enemyNameText.text = enemyName;
    }
    public void OnMouseOver()
    {
        PanelController.instance.OpenPanel(sliderController._statPanel);
    }
    public void OnMouseExit()
    {
        PanelController.instance.ClosePanel(sliderController._statPanel);
    }
}
