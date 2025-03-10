using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    private float xRotation;
    private bool isRotating;
    private Vector2 delta;
    public Vector3 offset;
        
    [SerializeField] private float rotationSpeed = 0.5f;

    private void Awake()
    {
        xRotation = transform.rotation.eulerAngles.x;
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        delta = context.ReadValue<Vector2>();
        
    }
    public void OnRotate(InputAction.CallbackContext context)
    {
        isRotating = context.started || context.performed;
    }
    private void LateUpdate()
    {
        if (isRotating)
        {
            transform.Rotate(new Vector3(xRotation , -delta.x * rotationSpeed , 0.0f));
            transform.rotation = Quaternion.Euler(xRotation, transform.rotation.eulerAngles.y, 0.0f);
        }
        transform.position = target.position + offset;
    }
}
