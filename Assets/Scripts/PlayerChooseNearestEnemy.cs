using UnityEngine;
using UnityEngine.AI;

public class PlayerChooseNearestEnemy : MonoBehaviour
{
    public static PlayerChooseNearestEnemy instance;

    public float searchRadius = 20f;  
    public float stopDistance = 1.5f; 

    private NavMeshAgent _agent;
    private Transform _target;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_target != null)
        {
            float distance = Vector3.Distance(transform.position, _target.position);
            if (distance <= stopDistance)
            {
                _agent.isStopped = true;
                _target = null;
            }
            if (_agent.isStopped)
            {
                _agent.isStopped = false;
            }
        }
    }
    public void FindNearestEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius);
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = col.transform;
                }
            }
        }

        if (closestEnemy != null)
        {
            _target = closestEnemy;
            _agent.isStopped = false;
            _agent.SetDestination(_target.position);
        }
    }
    public Transform GetTarget()
    {
        return _target;
    }

}
