using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
     public int health;
   
    public void Hit(int damageValue)
    {
        health -= damageValue;
        if (health <= 0)
        {
            StartCoroutine(Destroy());
        }
    }    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);

    }
}
