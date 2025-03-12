using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;

    public float attackDamage;
    public float attackRange;
    public float attackRate;
    public bool isAttacking;

    private float _nextAttackTime = 0f;

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _attackLayer;
    private void Awake()
    {
        instance = this;
    }
    public void AttakFrequancy()
    {
        if (Time.time >= _nextAttackTime)
        {
            Attack();
            _nextAttackTime = Time.time + 1 / attackRate;
        }
    }
    private void Attack()
    {
        isAttacking = true;

        Collider[] hitEnemies = Physics.OverlapSphere(_attackPoint.position, attackRange, _attackLayer);

        foreach (Collider enemy in hitEnemies)
        {
            //enemy.GetComponent<EnemyTakeDamage>().TakeDamage(attackDamage);
        }
        StartCoroutine(ResetAttack());
    }
    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(_attackPoint.position, attackRange);
    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(attackRate);
        isAttacking = false;
    }
}
