using UnityEngine;
using System.Collections.Generic;

public class PlayerSkills : MonoBehaviour
{
    public List<SkillBase> skills = new List<SkillBase>(); // Yetenek listesi

    public void UseSkill(string skillName, GameObject user)
    {
        SkillBase skill = skills.Find(s => s.skillName == skillName);
        if (skill != null)
        {
            skill.UseSkill(user);
        }
        else
        {
            Debug.Log($"{skillName} yeteneði bulunamadý!");
        }
    }
}
