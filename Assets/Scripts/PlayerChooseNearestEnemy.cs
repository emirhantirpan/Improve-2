using UnityEngine;

public class PlayerChooseNearestEnemy : MonoBehaviour
{
    public static PlayerChooseNearestEnemy instance;

    public float detectionRange = 10f; 
    public float attackRange = 2f; 
    public float moveSpeed = 5f; 
    public float attackCooldown = 1f; 

    private Transform target; 
    private float lastAttackTime = 0f;
    [SerializeField] private LayerMask enemyLayer;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        enemyLayer = LayerMask.GetMask("Enemy");
    }
    private void FindNearestEnemy()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRange, enemyLayer);
        float closestSqrDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider enemy  in closestEnemy)
        {
            float sqrDistance = (enemy.transform.position - transform.position).sqrMagnitude;
            if (sqrDistance < closestSqrDistance)
            {
                closestSqrDistance = sqrDistance;
                closestEnemy = enemy.transform;
            }
        }
        target = closestEnemy;
    }
}
