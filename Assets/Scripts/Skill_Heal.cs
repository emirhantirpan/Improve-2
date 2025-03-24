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
            playerHealth.Heal(healAmount); // Heal fonksiyonu çaðrýlýyor
            Debug.Log($"{skillName} kullanýldý! Oyuncu {healAmount} can iyileþti.");
        }
        else
        {
            Debug.LogWarning("PlayerHealth bileþeni bulunamadý!");
        }
    }
}
