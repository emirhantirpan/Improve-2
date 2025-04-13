using UnityEngine;
using System.Collections;

public class Skill_DamageAround : SkillBase
{
    public float radius = 5f;                   // Etki alaný
    public float rotationSpeed = 360f * 3f;     // Her saniye 3 tur
    public float damagePerTick = 10f;           // Her saniyede verilen hasar
    public float duration = 3f;                 // Toplam süre
    public GameObject rotatingCirclePrefab;     // Dönen çember prefabý

    public Skill_DamageAround()
    {
        skillName = "Damage Around";
        damage = 0; // Anlýk hasar deðil, zamanla hasar
    }

    public override void Activate(GameObject user)
    {
        user.GetComponent<MonoBehaviour>().StartCoroutine(DamageSpinRoutine(user));
    }

    private IEnumerator DamageSpinRoutine(GameObject user)
    {
        // Efekti oluþtur ve karaktere baðla
        GameObject circleEffect = null;
        if (rotatingCirclePrefab != null)
        {
            circleEffect = GameObject.Instantiate(rotatingCirclePrefab, user.transform.position, Quaternion.identity);
            circleEffect.transform.SetParent(user.transform, true);
        }

        float timer = 0f;

        while (timer < duration)
        {
            // Karakteri döndür
            user.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Hasar ver
            Collider[] hitEnemies = Physics.OverlapSphere(user.transform.position, radius);
            foreach (Collider enemy in hitEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    // Hasar verme
                    Debug.Log($"{enemy.name} düþmanýna {damagePerTick} hasar verildi.");
                    // enemy.GetComponent<EnemyHealth>().TakeDamage(damagePerTick);
                }
            }

            yield return new WaitForSeconds(1f); // Her saniye hasar
            timer += 1f;
        }

        if (circleEffect != null)
        {
            GameObject.Destroy(circleEffect);
        }
    }
}
