using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public static PlayerTakeDamage instance;
    [SerializeField] private HealthController _healthController;
    public bool isDead = false;
    private void Awake()
    {
        instance = this;
    }
    public void TakeDamage(int damage)
    {
        _healthController.DecreaseHealth(damage);
        if (_healthController.health == 0)
        {
            isDead = true;
        }
    }
}
