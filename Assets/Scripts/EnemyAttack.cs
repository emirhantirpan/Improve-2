using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackSpeed = 1.5f;
    public bool isAttacking = false;
    public int damage = 10;

    public CharacterState CharacterState;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private HealthController _healthController;

    private Coroutine _attackCoroutine;

    public void Setup(PlayerAttack playerAttack)
    {
        _playerAttack = playerAttack;
    }
    private void Update()
    {
        SetScript();
    }
    public void StartAttack()
    {
        if (_attackCoroutine == null && this != null)
        {
            _attackCoroutine = StartCoroutine(Attack());
        }
    }
    public void StopAttack()
    {
        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
            CharacterState.isAttacking = false;
            isAttacking = false;
        }
    }
    private IEnumerator Attack()
    {
        isAttacking = true;
        CharacterState.isAttacking = true;
        while (isAttacking && this != null)
        {
            if (_playerAttack != null && PlayerTakeDamage.instance != null)
            {
                PlayerTakeDamage.instance.TakeDamage(damage);
                yield return new WaitForSeconds(attackSpeed);
            }
            else
            {
                yield return null;
            }
        }
    }
    private void SetScript()
    {
        if (_healthController != null && _healthController.health == 0)
        {
            Destroy(this);
        }
    }
    private void OnDestroy()
    {
        StopAttack();
        _attackCoroutine = null;
    }
}
