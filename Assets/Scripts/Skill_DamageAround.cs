using UnityEngine;

public class Skill_DamageAround : SkillBase
{
    public float radius = 5f;  // Etki alan� (yar��ap)
    public float rotationSpeed = 360f;  // D�nerken d�nme h�z�
    public float damageOverTime = 10f;  // Zamanla hasar

    private float lastDamageTime;

    public Skill_DamageAround()
    {
        skillName = "Damage Around";
        damage = 0; // Bu skill sabit hasar vermiyor, zamanla hasar veriyor.
    }

    public override void Activate(GameObject user)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(user.transform.position, radius);

        foreach (Collider enemy in hitEnemies)
        {
            // E�er d��man etiketi varsa
            if (enemy.CompareTag("Enemy"))
            {
                // D��mana hasar ver
                ApplyDamage(enemy.gameObject);
            }
        }

        // Karakterin etraf�nda d�nmesi i�in
        RotateAroundUser(user);
    }

    private void ApplyDamage(GameObject enemy)
    {
        // Burada zamanla hasar veriyoruz
        if (Time.time - lastDamageTime >= 1f)  // Her saniyede bir hasar veriyoruz
        {
            lastDamageTime = Time.time;
            Debug.Log($"{skillName} {enemy.name} d��man�na {damageOverTime} hasar verdi!");
            // Hasar i�lemi burada yap�l�r. �rne�in:
            // enemy.GetComponent<EnemyHealth>().TakeDamage(damageOverTime);
        }
    }

    private void RotateAroundUser(GameObject user)
    {
        // Karakterin etraf�nda d�nd�rmek i�in
        user.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
