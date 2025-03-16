using UnityEngine;

[CreateAssetMenu(fileName = "SkillBase", menuName = "Scriptable Objects/SkillBase")]
public abstract class SkillBase : ScriptableObject
{
    public string skillName;
    public int damage;
    public int manaCost;
    public string description;
    public float cooldownTime;

    private float lastUseTime;

    public abstract void Activate(GameObject user);

    public bool CanUse()
    {
        return Time.time >= lastUseTime + cooldownTime;
    }


    public void UseSkill(GameObject user)
    {
        if (CanUse())
        {
            Activate(user);
            lastUseTime = Time.time;
        }
        else
        {
            Debug.Log($"{skillName} yeteneði cooldown süresinde!");
        }
    }
}
