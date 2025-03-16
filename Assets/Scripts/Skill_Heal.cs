using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Scriptable Objects/Skills/Heal")]
public class Skill_Heal : SkillBase
{
    public int healAmount = 50;

    public override void Activate(GameObject user)
    {
        PlayerHealth playerHealth = user.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount);
            Debug.Log($"{skillName} kullanýldý! Oyuncu {healAmount} can iyileþti.");
        }
        else
        {
            Debug.LogWarning("PlayerHealth bileþeni bulunamadý!");
        }
    }
}
