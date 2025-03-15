using UnityEngine;
using System.Collections.Generic;

public class PlayerSkills : MonoBehaviour
{
    public List<SkillBase> skills = new List<SkillBase>(); // Yetenek listesi

    public void UseSkill(int index)
    {
        if (index < skills.Count && skills[index] != null)
        {
            skills[index].UseSkill(gameObject);
        }
        else
        {
            Debug.Log("Bu yetenek boþ veya tanýmlý deðil!");
        }
    }
}
