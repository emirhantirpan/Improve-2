using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CameraManager : MonoBehaviour
{
    public Transform target;
 
    public float smoothSpeed = 0.125f;
    private float xRotation;
    private float yRotation;
    private bool isRotating;
    private float startYRotation;
    private float targetYRotation;
    private float rotationTimer;
    private float rotationDuration = 0.2f;
    private Vector2 delta;
    public Vector3 offset;
    private bool rotateToTarget = false;
    private Quaternion targetRotation;

    [SerializeField] private float rotationSpeed = 0.2f;

    private void Awake()
    {
        Vector3 angles = transform.rotation.eulerAngles;
        xRotation = angles.x;
        yRotation = angles.y;
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        delta = context.ReadValue<Vector2>();
        
    }
    public void OnRotate(InputAction.CallbackContext context)
    {
        if(context.started) { isRotating = true; }
        else if (context.canceled) { isRotating = false; }
    }
    private void Update()
    {
        if (target == null) return;
        if (Keyboard.current.zKey.wasPressedThisFrame && !rotateToTarget)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Transform closest = null;
            float minDistance = Mathf.Infinity;

            foreach (GameObject enemy in enemies)
            {
                float dist = Vector3.Distance(target.position, enemy.transform.position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closest = enemy.transform;
                }
            }

            if (closest != null)
            {
                Vector3 dirToEnemy = closest.position - target.position;
                dirToEnemy.y = 0;
                if (dirToEnemy.sqrMagnitude > 0.01f)
                {
                    startYRotation = yRotation;
                    targetYRotation = Quaternion.LookRotation(dirToEnemy).eulerAngles.y;
                    rotationTimer = 0f;
                    rotateToTarget = true;
                }
            }
        }
    }
    private void LateUpdate()
    {
        if (isRotating)
        {
            yRotation += delta.x * rotationSpeed;
            xRotation -= delta.y * rotationSpeed;
            xRotation = Mathf.Clamp(xRotation, 8.7f, 30f);
        }
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
        transform.position = target.position + offset;
        transform.rotation = rotation;

        if (rotateToTarget)
        {
            rotationTimer += Time.deltaTime;
            float t = Mathf.Clamp01(rotationTimer / rotationDuration);
            yRotation = Mathf.LerpAngle(startYRotation, targetYRotation, t);

            if (t >= 1f)
            {
                rotateToTarget = false;
            }
        }


    }
    public void RotateCameraToLookAtTarget(Vector3 lookDirection)
    {
        Vector3 flatLookDir = new Vector3(lookDirection.x, 0, lookDirection.z);
        if (flatLookDir == Vector3.zero) return;

        targetRotation = Quaternion.LookRotation(flatLookDir);
        yRotation = targetRotation.eulerAngles.y;
        rotateToTarget = true;
    }
  
}
