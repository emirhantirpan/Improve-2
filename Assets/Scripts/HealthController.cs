using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
     public int health;
   
    public void DecreaseHealth(int damageValue)
    {
        health -= damageValue;
        if (health <= 0)
        {
            StartCoroutine(Destroy());
            health = 0;
        }
    }    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);

    }
}
