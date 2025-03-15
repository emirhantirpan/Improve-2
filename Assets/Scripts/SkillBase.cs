using UnityEngine;

[CreateAssetMenu(fileName = "SkillBase", menuName = "Scriptable Objects/SkillBase")]
public abstract class SkillBase : ScriptableObject
{
    public string skillName;
    public int damage;
    public int manaCost;
    public float cooldownTime; // Bekleme süresi
    private float lastUseTime; // Son kullaným zamaný

    public abstract void Activate(GameObject user);

    public bool CanUse()
    {
        return Time.time >= lastUseTime + cooldownTime;
    }

    // **Eksik olan UseSkill metodu eklendi!**
    public void UseSkill(GameObject user)
    {
        if (CanUse())
        {
            Activate(user);
            lastUseTime = Time.time; // Cooldown sýfýrlanýr
        }
        else
        {
            Debug.Log($"{skillName} yeteneði cooldown süresinde!");
        }
    }
}
