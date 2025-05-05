using UnityEngine;

public class UIController : MonoBehaviour
{
    private UIManager _input;

    private void Awake()
    {
        _input = new UIManager();
        AssignInputs();
    }
    private void AssignInputs()
    {
        _input.UI.Pause.performed += ctx => PauseMenu.instance.PauseButtonInput();
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
