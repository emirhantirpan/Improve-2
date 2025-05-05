using UnityEngine;
using System.Collections;

public class Skill_Heal : SkillBase
{
    private int healAmount = 25;
    public HealthController HealthController;
    private void Start()
    {
        lastUseTime = -cooldownTime;
    }

    public Skill_Heal()
    {
        skillName = "Heal";
    }

    public override void Activate(GameObject user)
    {
        HealthController playerHealth = user.GetComponent<HealthController>();
        if (playerHealth != null)
        {
            Heal(healAmount);
            Debug.Log($"{skillName} kullanýldý! Oyuncu {healAmount} can iyileþti.");
        }
        else
        {
            Debug.LogWarning("PlayerHealth bileþeni bulunamadý!");
        }
    }

    public void Heal(int heal)
    {
        HealthController.health += heal;
    }

    public override IEnumerator ActivateCoroutine(GameObject user)
    {
        Activate(user);
        yield return null;
    }
}