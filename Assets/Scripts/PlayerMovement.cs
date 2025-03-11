using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private float _lookRotationSpeed = 8f;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _clickableLayers;
    //[SerializeField] private ParticleSystem _clickEffect;
    [SerializeField] private Transform _target;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    private void Update()
    {
        FaceToTarget();
    }
    public void ClickToMove()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, _clickableLayers))
        {
            _agent.destination = hit.point;
            /*if (_clickEffect)
            {
                _clickEffect.Play();
            }*/
            
        }
    }
    public void MoveToTarget()
    {
        if (_target != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                _target = hit.transform;
            }
        }

        if (_target == null) return;

        float distance = Vector3.Distance(transform.position, _target.position);

        if (distance < PlayerAttack.instance.attackRange)
        {
            PlayerAttack.instance.isAttacking = false;
        }
        else
        {
            if (!PlayerAttack.instance.isAttacking)
            {
                PlayerAttack.instance.isAttacking = true;
                PlayerAttack.instance.Attack();
            }
            _agent.destination = _target.position; // Let NavMeshAgent handle movement
        }
    }
    private void FaceToTarget()
    {
        Vector3 direction = (_agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _lookRotationSpeed);
    }
}
