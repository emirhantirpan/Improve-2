using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private float _lookRotationSpeed = 8f;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _clickableLayers;
    [SerializeField] private ParticleSystem _clickEffect;
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
            if (_clickEffect)
            {
                Instantiate(_clickEffect, hit.point += new Vector3(0f, 0.1f, 0f), _clickEffect.transform.rotation);
            }
            
        }
    }
    public void MoveTowardsTarget()
    {
        /*if (PlayerChooseNearestEnemy.instance.target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, PlayerChooseNearestEnemy.instance.moveSpeed * Time.deltaTime);
        transform.LookAt(target);*/
    }
    private void FaceToTarget()
    {
        /*Vector3 direction = (_agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _lookRotationSpeed);*/

        if (_agent.velocity != Vector3.zero)
        {
            Vector3 direction = (_agent.destination - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _lookRotationSpeed);
        }
    }
}
