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
            Heal(healAmount); // Heal fonksiyonu çaðrýlýyor
            Debug.Log($"{skillName} kullanýldý! Oyuncu {healAmount} can iyileþti.");
        }
        else
        {
            Debug.LogWarning("PlayerHealth bileþeni bulunamadý!");
        }
    }
    public void Heal(int heal)
    {
        HealthController.instance.health += heal;
    }
}
