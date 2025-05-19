using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent _agent;
    public Transform _target;
    public EnemyAttack enemyAttack;

    private float distance;

    public void Setup(Transform target)
    {
        _target = target;
    }
    private void Update()
    {
        if (_target == null) return;

        Movement();
        StoppingDistance();
    }
    public void Movement()
    {
        if (_target != null)
        {
            distance = Vector3.Distance(transform.position, _target.position);
            _agent.SetDestination(_target.position);
            Vector3 relativePos = _target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(relativePos);
            Quaternion lookAtRotationY = Quaternion.Euler(transform.rotation.eulerAngles.x, lookRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = lookAtRotationY;
        }
    }
    public void StoppingDistance()
    {
        if (distance >= 25)
        {
            _agent.speed = 0;
        }
        else
        {
            _agent.speed = 3f;
        }

        if (distance <= AttackRange())
        {
            enemyAttack.StartAttack();
            _agent.velocity = Vector3.zero;
        }
        else
        {
            enemyAttack.StopAttack();
        }
    }
    public float AttackRange()
    {
        if (gameObject.name == "EnemyIskeletor") return 2f;
        if (gameObject.name == "EnemyWerewolf") return 5f;
        return 0f;
    }
}
