using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    private float xRotation;
    private float yRotation;
    private bool isRotating;
    private Vector2 delta;
    public Vector3 offset;
        
    [SerializeField] private float rotationSpeed = 0.5f;

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
    }
}
