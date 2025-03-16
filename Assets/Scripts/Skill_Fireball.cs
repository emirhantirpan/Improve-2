using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "Scriptable Objects/Skills/Fireball")]
public class Skill_Fireball : SkillBase
{
    public GameObject fireballPrefab;
    public float speed = 10f;

    public override void Activate(GameObject user)
    {
        if (fireballPrefab == null)
        {
            Debug.LogError("Fireball Prefab atanmamış!");
            return;
        }

        // Fireball'ı oyuncunun önüne instantiate et
        GameObject fireball = Instantiate(fireballPrefab, user.transform.position + user.transform.forward * 2f, Quaternion.identity);

        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = user.transform.forward * speed;
        }
        else
        {
            Debug.LogWarning("Fireball prefab'inde Rigidbody eksik!");
        }

        Debug.Log($"{skillName} kullanıldı! {damage} hasar verir.");
    }
}
