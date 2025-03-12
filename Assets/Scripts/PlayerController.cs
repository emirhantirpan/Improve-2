using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerActions _input;

    private void Awake()
    {
        _input = new PlayerActions();
        AssignInputs();
    }
    private void AssignInputs()
    {
        _input.Main.Movement.performed += ctx => PlayerMovement.instance.ClickToMove();
        _input.Main.Attack.performed += ctx => PlayerAttack.instance.AttakFrequancy();
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
}
