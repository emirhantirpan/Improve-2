using UnityEngine;

[CreateAssetMenu(fileName = "SkillBase", menuName = "Scriptable Objects/SkillBase")]
public abstract class SkillBase : ScriptableObject
{
    public string skillName;
    public int damage;
    public int manaCost;
    public float cooldownTime; // Bekleme s�resi
    private float lastUseTime; // Son kullan�m zaman�

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
            lastUseTime = Time.time; // Cooldown s�f�rlan�r
        }
        else
        {
            Debug.Log($"{skillName} yetene�i cooldown s�resinde!");
        }
    }
}
