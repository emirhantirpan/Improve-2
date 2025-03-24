using UnityEngine;
using System.Collections.Generic;

public class PlayerSkills : MonoBehaviour
{
    private Skill_Heal healSkill;
    private Skill_DamageAround damageAround;
    private Skill_Thunder _Thunder;
    private void Start()
    {
        


        healSkill = gameObject.AddComponent<Skill_Heal>();
       damageAround = gameObject.AddComponent<Skill_DamageAround>();
        _Thunder = gameObject.AddComponent<Skill_Thunder>();
    }






    public void UseSkill(string skillName, GameObject user)
    {
        if (skillName == "Heal")
        {
            healSkill.Activate(user);
        }
        if(skillName == "Thunder")
        {
            _Thunder.Activate(user);
        }
        if(skillName == "DamageAround")
        {
            damageAround.Activate(user);
        }
    }
}
