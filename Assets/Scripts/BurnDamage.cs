using System.Collections;
using UnityEngine;

public class BurnDamage : MonoBehaviour
{
    private GameObject target;
    private float burnDamage;
    private float burnDuration;

    public void Initialize(GameObject target, float damage, float duration)
    {
        this.target = target;
        this.burnDamage = damage;
        this.burnDuration = duration;

        StartCoroutine(ApplyBurn());
    }

    private IEnumerator ApplyBurn()
    {
        float timer = 0f;
        EnemyTakeDamage enemy = target?.GetComponentInParent<EnemyTakeDamage>();

        while (timer < burnDuration && enemy != null)
        {
            yield return new WaitForSeconds(1f);

            if (target != null)
            {
                enemy.TakeDamage((int)burnDamage);
                Debug.Log($"{target.name} yanma hasarý aldý: {burnDamage}");
            }

            timer += 1f;
        }

        Destroy(gameObject); // Yanma hasarý tamamlandýktan sonra kendini yok et
    }
}
