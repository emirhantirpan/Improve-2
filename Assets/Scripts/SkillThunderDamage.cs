using System.Collections;
using UnityEngine;

public class SkillThunderDamage : MonoBehaviour
{
    public float initialDamage = 15f;
    public float burnDamage = 5f;
    public float burnDuration = 2f;

    public GameObject burnEffectPrefab; // Yanma efekti prefabý (yeni)

    private GameObject target;

    public void SetTarget(GameObject enemy)
    {
        target = enemy;
        StartCoroutine(ApplyDamage());
    }

    private IEnumerator ApplyDamage()
    {
        if (target == null)
        {
            Destroy(gameObject);
            yield break;
        }

        EnemyTakeDamage enemy = target.GetComponentInParent<EnemyTakeDamage>();

        if (enemy != null)
        {
            // Ýlk yýldýrým hasarý
            enemy.TakeDamage((int)initialDamage);
            Debug.Log($"{target.name} yýldýrým çarptý: {initialDamage}");

            // Yanma efekti instantiate et (yeni)
            GameObject burnEffect = null;
            if (burnEffectPrefab != null)
            {
                // Yanma efektini düþmanýn üstünde instantiate et ve çocuðu yap (yeni)
                burnEffect = Instantiate(burnEffectPrefab, target.transform.position + Vector3.up * 1.5f, Quaternion.identity, target.transform);
            }

            float timer = 0f;
            while (timer < burnDuration)
            {
                yield return new WaitForSeconds(1f);

                if (target != null)
                {
                    // Sürekli yanma hasarý ver (yeni)
                    enemy.TakeDamage((int)burnDamage);
                    Debug.Log($"{target.name} yanma hasarý aldý: {burnDamage}");
                }

                timer += 1f;
            }

            // Yanma efekti süresi dolunca yok et (yeni)
            if (burnEffect != null)
                Destroy(burnEffect);
        }

        Destroy(gameObject); // Yýldýrým efekti tamamlandýðýnda kendini yok et (yeni)
    }
}
