using UnityEngine;
using System.Collections;

public abstract class SkillBase : MonoBehaviour
{
    public string skillName;
    public int damage;
    public int manaCost;
    public string description;
    public float cooldownTime;

    
    public float lastUseTime;

    private void Start()
    {
        lastUseTime = -cooldownTime;
    }


    public abstract void Activate(GameObject user);

    // Coroutine tabanlý aktivasyon
    public virtual IEnumerator ActivateCoroutine(GameObject user)
    {
        Activate(user);
        yield break;
    }

    public bool CanUse()
    {
        return Time.time >= lastUseTime + cooldownTime;
    }

    public void UseSkill(GameObject user)
    {
        if (CanUse())
        {
            user.GetComponent<MonoBehaviour>().StartCoroutine(ActivateCoroutine(user));
            lastUseTime = Time.time;
        }
        else
        {
            Debug.Log($"{skillName} yeteneði cooldown süresinde!");
        }
    }
}