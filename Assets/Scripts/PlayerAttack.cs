using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackRate = 1.4f;
    public int attackDamage = 30;

    private float _nextAttackTime = 0f;

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _attackLayer;
    //[SerializeField] private CharacterState _characterState;

    public void AttackFrequency()
    {
        if (Time.time >= _nextAttackTime)
        {
            Attack();
            _nextAttackTime = Time.time + 1 / attackRate;
        }
    }
    private void Attack()
    {
        //_characterState.isAttacking = true;

        Collider[] hitEnemies = Physics.OverlapSphere(_attackPoint.position, attackRange, _attackLayer);

        foreach (var enemy in hitEnemies)
        {
            if (enemy != null)
            {
                enemy.GetComponent<EnemyTakeDamage>().TakeDamage(attackDamage);
            }
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
        yield return new WaitForSeconds(1f);
        //_characterState.isAttacking = false;
    }
}
