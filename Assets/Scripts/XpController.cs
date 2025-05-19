using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpController : MonoBehaviour
{
    public Slider slider;

    public TMP_Text levelText;


    public int level = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 100;

    public void Update()
    {
        levelText.text = level.ToString();
    }
    public void GainXP(int amount)
    {
        currentXP += amount;

        while (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            LevelUp();
        }

        UpdateXP(currentXP, xpToNextLevel); // UI g�ncellemesi
    }

    void LevelUp()
    {
        level++;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.2f); // Zorluk art���
        Debug.Log("Seviye atlad�n! Yeni seviye: " + level);
    }
    public void UpdateXP(int currentXP, int xpToNextLevel)
    {
        slider.maxValue = xpToNextLevel;
        slider.value = currentXP;
    }
}
