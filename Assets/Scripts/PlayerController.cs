using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerActions _input;
    private PlayerSkills _playerSkills;
    private PlayerHealth _playerHealth; // PlayerHealth bile�eni referans�

    private void Awake()
    {
        _input = new PlayerActions();
        _playerSkills = GetComponent<PlayerSkills>();
        _playerHealth = GetComponent<PlayerHealth>(); // PlayerHealth bile�enini al

        AssignInputs();
    }

    private void AssignInputs()
    {
        // Movement, Attack ve Skill giri�lerini ba�la
        _input.Main.Movement.performed += ctx => PlayerMovement.instance.ClickToMove();
        _input.Main.Attack.performed += ctx => PlayerAttack.instance.AttakFrequancy();

        // Skill kullan�mlar�
        _input.Main.SkillFireball.performed += ctx => UseSkill("Skill_Fireball");
        _input.Main.SkillThunder.performed += ctx => UseSkill("Thunder");
        _input.Main.SkillHeal.performed += ctx => UseSkill("Heal");
    }

    private void UseSkill(string skillName)
    {
        // Yetenek ad�n� kullanarak ilgili skill'i �al��t�r
        if (_playerSkills != null)
        {
            _playerSkills.UseSkill(skillName, gameObject); // Oyuncu nesnesini de g�nder
        }
    }

    // Sa�l�k al
    public void TakeDamage(int amount)
    {
        if (_playerHealth != null)
        {
            _playerHealth.TakeDamage(amount);
        }
    }

    // Sa�l�k iyile�tir
    public void Heal(int amount)
    {
        if (_playerHealth != null)
        {
            _playerHealth.Heal(amount);
        }
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
}
