using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log($"Oyuncu {amount} hasar aldý! Güncel can: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log($"Oyuncu {amount} iyileþti! Güncel can: {currentHealth}");
    }

    private void Die()
    {
        Debug.Log("Oyuncu öldü!");
    }
}
