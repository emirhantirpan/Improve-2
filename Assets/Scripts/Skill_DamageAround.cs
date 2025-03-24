using UnityEngine;

public class Skill_DamageAround : SkillBase
{
    public float radius = 5f;  // Etki alaný (yarýçap)
    public float rotationSpeed = 360f;  // Dönerken dönme hýzý
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
            // Eðer düþman etiketi varsa
            if (enemy.CompareTag("Enemy"))
            {
                // Düþmana hasar ver
                ApplyDamage(enemy.gameObject);
            }
        }

        // Karakterin etrafýnda dönmesi için
        RotateAroundUser(user);
    }

    private void ApplyDamage(GameObject enemy)
    {
        // Burada zamanla hasar veriyoruz
        if (Time.time - lastDamageTime >= 1f)  // Her saniyede bir hasar veriyoruz
        {
            lastDamageTime = Time.time;
            Debug.Log($"{skillName} {enemy.name} düþmanýna {damageOverTime} hasar verdi!");
            // Hasar iþlemi burada yapýlýr. Örneðin:
            // enemy.GetComponent<EnemyHealth>().TakeDamage(damageOverTime);
        }
    }

    private void RotateAroundUser(GameObject user)
    {
        // Karakterin etrafýnda döndürmek için
        user.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
