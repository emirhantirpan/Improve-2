using UnityEngine;

public class Skill_Thunder : SkillBase
{
   

    public GameObject cylinderPrefab; // Silindir (yýldýrým) prefabý
    private float radius = 5f;

    public Skill_Thunder()
    {
        skillName = "ThunderStrike";
        damage = 0; // Þimdilik hasar vermiyor, sadece efekt
    }

    public override void Activate(GameObject user)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(user.transform.position, radius);

        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Vector3 spawnPosition = enemy.transform.position + Vector3.up * 3f;

                if (cylinderPrefab != null)
                {
                    Instantiate(cylinderPrefab, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}


