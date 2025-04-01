using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log($"Oyuncu {amount} hasar ald�! G�ncel can: {currentHealth}");
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log($"Oyuncu {amount} iyile�ti! G�ncel can: {currentHealth}");
        healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        Debug.Log("Oyuncu �ld�!");
    }
}
