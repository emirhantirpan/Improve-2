using UnityEngine;
using UnityEngine.UI;

public class SkilllBarController : MonoBehaviour
{
    [Header ("Ability 1")]
    public Image skillImage1;
    public float cooldown = 5;
    bool isCooldown=false;
    [Header("Ability 2")]
    public Image skillImage2;
    public float cooldown2 = 5;
    bool isCooldown2 = false;
    [Header("Ability 3")]
    public Image skillImage3;
    public float cooldown3 = 5;
    bool isCooldown3 = false;


    void Update()
    {
        
        Ability1();
        Ability2();
        Ability3();
    }

    void Ability1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isCooldown==false)
        {
            isCooldown = true;
            skillImage1.fillAmount = 1;
        }
        if (isCooldown)
        {
            skillImage1.fillAmount -=1/cooldown*Time.deltaTime;
            if(skillImage1.fillAmount <= 0)
            { 
                skillImage1.fillAmount = 0;
                isCooldown=false;
            }
        }
    }
    void Ability2()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            skillImage2.fillAmount = 1;
        }
        if (isCooldown2)
        {
            skillImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (skillImage2.fillAmount <= 0)
            {
                skillImage2.fillAmount = 0;
                isCooldown2= false;
            }
        }
    }
    void Ability3()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            skillImage3.fillAmount = 1;
        }
        if (isCooldown3)
        {
            skillImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;
            if (skillImage3.fillAmount <= 0)
            {
                skillImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
}
