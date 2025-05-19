using System.Collections;
using UnityEngine;

public class SkillThunderDamage : MonoBehaviour
{
    public float initialDamage = 15f;
    public float burnDamage = 5f;
    public float burnDuration = 2f;

    public GameObject burnEffectPrefab; // Yanma efekti prefab�

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
            // �lk y�ld�r�m hasar�
            enemy.TakeDamage((int)initialDamage);
            Debug.Log($"{target.name} y�ld�r�m �arpt�: {initialDamage}");

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

            // Burada y�ld�r�m efekti objesi zaten 'this.gameObject' (SkillThunderDamage objesi)
            // Ekranda kald��� s�re boyunca titre�im coroutine ba�lat
            shakeCoroutine = StartCoroutine(ShakeRotationCoroutine());

            float timer = 0f;
            while (timer < burnDuration)
            {
                yield return new WaitForSeconds(1f);

                if (target != null)
                {
                    enemy.TakeDamage((int)burnDamage);
                    Debug.Log($"{target.name} yanma hasar� ald�: {burnDamage}");
                }

                timer += 1f;
            }

            // �� bittikten sonra titre�im coroutine'ini durdur
            if (shakeCoroutine != null)
            {
                StopCoroutine(shakeCoroutine);
            }
        }

        Destroy(gameObject); // Y�ld�r�m efekti tamamland���nda kendini yok et
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
