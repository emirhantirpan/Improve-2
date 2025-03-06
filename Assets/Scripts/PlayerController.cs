using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerActions _input;

    private void Awake()
    {
        _input = new PlayerActions();
    }
    private void AssignInputs()
    {
        _input.Main.Movement.performed += ctx => PlayerMovement.instance.ClickToMove();
    }
}
