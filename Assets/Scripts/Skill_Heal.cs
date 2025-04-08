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
        HealthController playerHealth = user.GetComponent<HealthController>();
        if (playerHealth != null)
        {
            Heal(healAmount); // Heal fonksiyonu �a�r�l�yor
            Debug.Log($"{skillName} kullan�ld�! Oyuncu {healAmount} can iyile�ti.");
        }
        else
        {
            Debug.LogWarning("PlayerHealth bile�eni bulunamad�!");
        }
    }
    public void Heal(int heal)
    {
        HealthController.instance.health += heal;
    }
}
