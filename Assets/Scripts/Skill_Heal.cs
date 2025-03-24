using UnityEngine;

public class Skill_Heal : SkillBase
{
    private int healAmount = 25;

    public Skill_Heal()
    {
        skillName = "Heal";
    }

    public override void Activate(GameObject user)
    {
        PlayerHealth playerHealth = user.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount); // Heal fonksiyonu �a�r�l�yor
            Debug.Log($"{skillName} kullan�ld�! Oyuncu {healAmount} can iyile�ti.");
        }
        else
        {
            Debug.LogWarning("PlayerHealth bile�eni bulunamad�!");
        }
    }
}
