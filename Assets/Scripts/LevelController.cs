using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int level;

    public TMP_Text levelText;
    public HealthController HealthController;
    public SliderController SliderController;
    public EnemyAttack EnemyAttack;

    private void Start()
    {
        DisplayTexts();
    }
    public void DisplayTexts()
    {
        levelText.text = level.ToString();
    }
    public void SetLevel(int newLevel)
    {
        level = newLevel;
        UpdateHealthByLevel(level);
        DisplayTexts();
    }
    private void UpdateHealthByLevel(int Level)
    {
        switch (Level)
        {
            case 1:
                HealthController.health *= 1;
                if (EnemyAttack != null)
                {
                    EnemyAttack.damage *= 1;
                }
                break;
            case 2:
                HealthController.health *= 2;
                if (EnemyAttack != null)
                {
                    EnemyAttack.damage *= 2;
                }
                break;
            case 3:
                HealthController.health *= 3;
                if (EnemyAttack != null)
                {
                    EnemyAttack.damage *= 3;
                }
                break;
        }
        SliderController.maxValue = HealthController.health;
        SliderController._slider.maxValue = SliderController.maxValue;
        SliderController._slider.value = HealthController.health;
        Debug.Log("Level atladý can deðeri deðiþti");
    }
}
