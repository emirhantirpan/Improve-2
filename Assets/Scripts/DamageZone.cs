using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float initialDamage = 10f;
    public float damagePerSecond = 5f;

    private HashSet<GameObject> damagedObjects = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponentInParent<EnemyTakeDamage>();
            if (enemy != null && !damagedObjects.Contains(other.gameObject))
            {
                enemy.TakeDamage((int)initialDamage);
                damagedObjects.Add(other.gameObject);
                StartCoroutine(DamageOverTime(enemy, other.gameObject));
                Debug.Log($"{other.name} ilk hasar aldý: {initialDamage}");
            }
        }
    }

    private IEnumerator DamageOverTime(EnemyTakeDamage enemy, GameObject obj)
    {
        while (obj != null && damagedObjects.Contains(obj))
        {
            yield return new WaitForSeconds(1f);
            if (obj != null)
            {
                enemy.TakeDamage((int)damagePerSecond);
                Debug.Log($"{obj.name} süreli hasar aldý: {damagePerSecond}");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (damagedObjects.Contains(other.gameObject))
            {
                damagedObjects.Remove(other.gameObject);
                Debug.Log($"{other.name} hasar bölgesinden çýktý.");
            }
        }
    }
}
