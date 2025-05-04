using UnityEngine;
using System.Collections;

public class Skill_DamageAround : SkillBase
{
    public float radius = 5f;
    public float rotationSpeed = 360f * 3f;
    public float damagePerTick = 10f;
    public float duration = 3f;
    public GameObject rotatingCirclePrefab;
    private void Start()
    {
        lastUseTime = -cooldownTime;
    }

    public Skill_DamageAround()
    {
        skillName = "DamageAround";
        damage = 0;
    }

    public override void Activate(GameObject user)
    {
        user.GetComponent<MonoBehaviour>().StartCoroutine(DamageSpinRoutine(user));
    }

    private IEnumerator DamageSpinRoutine(GameObject user)
    {
        GameObject circleEffect = null;
        if (rotatingCirclePrefab != null)
        {
            circleEffect = GameObject.Instantiate(rotatingCirclePrefab, user.transform.position, Quaternion.identity);
            circleEffect.transform.SetParent(user.transform, true);
        }

        float timer = 0f;

        while (timer < duration)
        {
            user.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            Collider[] hitEnemies = Physics.OverlapSphere(user.transform.position, radius);
            foreach (Collider enemy in hitEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    Debug.Log($"{enemy.name} düþmanýna {damagePerTick} hasar verildi.");
                    // enemy.GetComponent<EnemyHealth>().TakeDamage(damagePerTick);
                }
            }

            yield return new WaitForSeconds(1f);
            timer += 1f;
        }

        if (circleEffect != null)
        {
            GameObject.Destroy(circleEffect);
        }
    }

    public override IEnumerator ActivateCoroutine(GameObject user)
    {
        yield return DamageSpinRoutine(user);
    }
}
