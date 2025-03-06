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

    private void Awake()
    {
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
    private void FaceToTarget()
    {
        Vector3 direction = (_agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _lookRotationSpeed);
    }
}
