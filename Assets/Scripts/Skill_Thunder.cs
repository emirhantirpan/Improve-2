using UnityEngine;

public class Skill_Thunder : SkillBase
{
    private float radius = 5f;

    public Skill_Thunder()
    {
        skillName = "Thunder";
        damage = 20; // Hasar miktarý
    }

    public override void Activate(GameObject user)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(user.transform.position, radius);

        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Debug.Log($"{skillName} {enemy.name} düþmanýna {damage} hasar verdi!");
                // Burada düþmana zarar verme kodu eklenebilir.
            }
        }
    }
}
