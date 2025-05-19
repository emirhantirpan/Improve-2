using System.Collections;
using UnityEngine;

public class SkillThunderDamage : MonoBehaviour
{
    public float initialDamage = 15f;
    public float burnDamage = 5f;
    public float burnDuration = 2f;

    public GameObject burnEffectPrefab; // Yanma efekti prefabý

    private GameObject target;
    private Coroutine shakeCoroutine;

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

            // Yanma efekti instantiate et
            GameObject burnEffect = null;
            if (burnEffectPrefab != null)
            {
                burnEffect = Instantiate(burnEffectPrefab, target.transform.position + Vector3.up * 1.5f, Quaternion.identity, target.transform);

                ParticleSystem ps = burnEffect.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    float totalDuration = ps.main.duration + ps.main.startLifetime.constantMax;
                    Destroy(burnEffect, totalDuration);
                }
                else
                {
                    Destroy(burnEffect, burnDuration);
                }
            }

            // Burada yýldýrým efekti objesi zaten 'this.gameObject' (SkillThunderDamage objesi)
            // Ekranda kaldýðý süre boyunca titreþim coroutine baþlat
            shakeCoroutine = StartCoroutine(ShakeRotationCoroutine());

            float timer = 0f;
            while (timer < burnDuration)
            {
                yield return new WaitForSeconds(1f);

                if (target != null)
                {
                    enemy.TakeDamage((int)burnDamage);
                    Debug.Log($"{target.name} yanma hasarý aldý: {burnDamage}");
                }

                timer += 1f;
            }

            // Ýþ bittikten sonra titreþim coroutine'ini durdur
            if (shakeCoroutine != null)
            {
                StopCoroutine(shakeCoroutine);
            }
        }

        Destroy(gameObject); // Yýldýrým efekti tamamlandýðýnda kendini yok et
    }

    private IEnumerator ShakeRotationCoroutine()
    {
        while (true)
        {
            float randomX = Random.Range(-15f, 15f);
            float randomZ = Random.Range(-15f, 15f);

            transform.rotation = Quaternion.Euler(randomX, transform.rotation.eulerAngles.y, randomZ);

            yield return new WaitForSeconds(0.10f);
        }
    }

}
