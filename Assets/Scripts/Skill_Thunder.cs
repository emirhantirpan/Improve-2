using UnityEngine;

[CreateAssetMenu(fileName = "Thunder", menuName = "Scriptable Objects/Skills/Thunder")]
public class Skill_Thunder : SkillBase
{
    public float radius = 5f;

    public override void Activate(GameObject user)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(user.transform.position, radius);

        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Debug.Log($"{skillName} {enemy.name} düþmanýna {damage} hasar verdi!");
            }
        }
    }
}
