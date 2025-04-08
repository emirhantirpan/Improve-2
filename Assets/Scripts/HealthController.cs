using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
     public static HealthController instance;

  //  public int maxHealth = 100;
     public int health;
    

   // public HealthBar healthBar;

    private void Awake()
    {
        instance = this;
    }
    /* void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }*/
    public void DecreaseHealth(int damageValue)
    {
        health -= damageValue;
        if (health <= 0)
        {
            StartCoroutine(Destroy());
            health = 0;
        }

       /* if(health<0)
            health = 0;
        healthBar.SetHealth(health);
        if(health <= 0)
        {
            StartCoroutine(Destroy());
        }*/
    }    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);

    }
    
}
