using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;

    public void TakeDamage(int damage)
    {
        _healthController.DecreaseHealth(damage);
    }
}
