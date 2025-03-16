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
            Debug.Log($"{skillName} kullan�ld�! Oyuncu {healAmount} can iyile�ti.");
        }
        else
        {
            Debug.LogWarning("PlayerHealth bile�eni bulunamad�!");
        }
    }
}
