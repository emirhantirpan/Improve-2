using System.Collections;
using UnityEngine;

public class Skill_DamageAround : SkillBase
{
    public GameObject rotatingCirclePrefab;
    private GameObject circleEffect;

    public float rotationSpeed = 360f * 3f;
    public float duration = 3f;

    public override void Activate(GameObject user)
    {
        if (circleEffect == null)
        {
            // K�reyi instantiate et ve user objesinin child�� yap
            circleEffect = Instantiate(rotatingCirclePrefab, user.transform.position, Quaternion.identity, user.transform);
            circleEffect.SetActive(true);

            // DamageZone bile�enine de�erleri ver
            var damageZone = circleEffect.GetComponent<DamageZone>();
            if (damageZone != null)
            {
                damageZone.initialDamage = 10f;
                damageZone.damagePerSecond = 5f;
            }

            // Coroutine�i ba�lat
            StartCoroutine(DamageSpinRoutine(user));
        }
    }

    private IEnumerator DamageSpinRoutine(GameObject user)
    {
        float timer = 0f;

        while (timer < duration)
        {
            // user objesini d�nd�r
            user.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            timer += Time.deltaTime;
            yield return null;
        }

        // S�re dolunca k�reyi yok et ve referans� temizle
        if (circleEffect != null)
        {
            Destroy(circleEffect);
            circleEffect = null;
        }
    }
}
