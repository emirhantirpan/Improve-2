using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "Scriptable Objects/Skills/Fireball")]
public class Skill_Fireball : SkillBase
{
    
    public GameObject fireballPrefab;
    public float speed = 10f;

    public override void Activate(GameObject user)
    {
        if (fireballPrefab == null) return;

        GameObject fireball = Instantiate(fireballPrefab, user.transform.position + user.transform.forward, Quaternion.identity);
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = user.transform.forward * speed;
        }

        Debug.Log($"{skillName} kullanıldı! {damage} hasar verir.");
    }
}
