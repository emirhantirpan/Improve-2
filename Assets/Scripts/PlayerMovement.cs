using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private float _lookRotationSpeed = 8f;

    private NavMeshAgent _agent;
    [SerializeField] private LayerMask _clickableLayers;
    [SerializeField] private ParticleSystem _clickEffect;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        
        _agent = GetComponent<NavMeshAgent>();
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
    private void FaceToTarget()
    {
        if (_agent.velocity != Vector3.zero)
        {
            Vector3 direction = (_agent.destination - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _lookRotationSpeed);
        }
    }
}
