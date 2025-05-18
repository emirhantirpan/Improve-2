using System.Collections;
using UnityEngine;

public class SkillThunderDamage : MonoBehaviour
{
    public float initialDamage = 15f;
    public float burnDamage = 5f;
    public float burnDuration = 2f;

    public GameObject burnEffectPrefab; // Yanma efekti prefab� (yeni)

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
            // �lk y�ld�r�m hasar�
            enemy.TakeDamage((int)initialDamage);
            Debug.Log($"{target.name} y�ld�r�m �arpt�: {initialDamage}");

            // Yanma efekti instantiate et (yeni)
            GameObject burnEffect = null;
            if (burnEffectPrefab != null)
            {
                // Yanma efektini d��man�n �st�nde instantiate et ve �ocu�u yap (yeni)
                burnEffect = Instantiate(burnEffectPrefab, target.transform.position + Vector3.up * 1.5f, Quaternion.identity, target.transform);
            }

            float timer = 0f;
            while (timer < burnDuration)
            {
                yield return new WaitForSeconds(1f);

                if (target != null)
                {
                    // S�rekli yanma hasar� ver (yeni)
                    enemy.TakeDamage((int)burnDamage);
                    Debug.Log($"{target.name} yanma hasar� ald�: {burnDamage}");
                }

                timer += 1f;
            }

            // Yanma efekti s�resi dolunca yok et (yeni)
            if (burnEffect != null)
                Destroy(burnEffect);
        }

        Destroy(gameObject); // Y�ld�r�m efekti tamamland���nda kendini yok et (yeni)
    }
}
