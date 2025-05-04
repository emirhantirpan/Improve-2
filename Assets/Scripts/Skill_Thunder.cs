using UnityEngine;
using System.Collections;

public class Skill_Thunder : SkillBase
{
    public GameObject cylinderPrefab;
    private float radius = 5f;
    private void Start()
    {
        lastUseTime = -cooldownTime;
    }

    public Skill_Thunder()
    {
        skillName = "Thunder";
        damage = 0;
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

    public override IEnumerator ActivateCoroutine(GameObject user)
    {
        Activate(user);
        yield return null;
    }
}
