using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public Skill_Heal healSkill;
    public Skill_DamageAround damageAround;
    public Skill_Thunder _Thunder;

    private void Start()
    {
        // Skilleri component olarak eklemiyorsan Inspector'dan referans ver.
    }

    public void UseSkill(string skillName, GameObject user)
    {
        if (skillName == "Heal")
            healSkill.UseSkill(user);
        else if (skillName == "Thunder")
            _Thunder.UseSkill(user);
        else if (skillName == "DamageAround")
            damageAround.UseSkill(user);
    }
}
