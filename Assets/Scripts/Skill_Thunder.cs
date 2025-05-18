using System.Collections;
using UnityEngine;

public class Skill_Thunder : SkillBase
{
    public GameObject thunderStrikePrefab;
    public float radius = 5f;

    public override void Activate(GameObject user)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(user.transform.position, radius);

        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // Enemy pozisyonunun üstünde efekt spawn
                Vector3 spawnPosition = enemy.transform.position + Vector3.up * 3f;

                if (thunderStrikePrefab != null)
                {
                    // enemy'nin child'ý olarak instantiate
                    GameObject strike = Instantiate(thunderStrikePrefab, spawnPosition, Quaternion.identity, enemy.transform);

                    // hasar verme scriptini tetikle
                    SkillThunderDamage damageScript = strike.GetComponent<SkillThunderDamage>();
                    if (damageScript != null)
                    {
                        damageScript.SetTarget(enemy.gameObject);
                    }
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
