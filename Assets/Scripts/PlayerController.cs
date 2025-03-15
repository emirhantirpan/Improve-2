using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    private PlayerActions _input;
    private PlayerSkills _playerSkills;

    private void Awake()
    {
        _input = new PlayerActions();
        _playerSkills = GetComponent<PlayerSkills>();

        AssignInputs();
    }

    private void AssignInputs()
    {
        _input.Main.Movement.performed += ctx => PlayerMovement.instance.ClickToMove();
        _input.Main.Attack.performed += ctx =>
        _input.Main.SkillFireball.performed += ctx => UseSkill(0);
        _input.Main.SkillThunder.performed += ctx => UseSkill(1);
        _input.Main.SkillHeal.performed += ctx => UseSkill(2);
    }

    private void UseSkill(int index)
    {
        if (_playerSkills != null)
        {
            _playerSkills.UseSkill(index);
        }
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
}
