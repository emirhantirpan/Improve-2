using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerActions _input;
    private PlayerSkills _playerSkills;
    private PlayerHealth _playerHealth; // PlayerHealth bileþeni referansý

    private void Awake()
    {
        _input = new PlayerActions();
        _playerSkills = GetComponent<PlayerSkills>();
        _playerHealth = GetComponent<PlayerHealth>(); // PlayerHealth bileþenini al

        AssignInputs();
    }

    private void AssignInputs()
    {
        // Movement, Attack ve Skill giriþlerini baðla
        _input.Main.Movement.performed += ctx => PlayerMovement.instance.ClickToMove();
        _input.Main.Attack.performed += ctx => PlayerAttack.instance.AttakFrequancy();

        // Skill kullanýmlarý
        _input.Main.SkillFireball.performed += ctx => UseSkill("Skill_Fireball");
        _input.Main.SkillThunder.performed += ctx => UseSkill("Thunder");
        _input.Main.SkillHeal.performed += ctx => UseSkill("Heal");
    }

    private void UseSkill(string skillName)
    {
        // Yetenek adýný kullanarak ilgili skill'i çalýþtýr
        if (_playerSkills != null)
        {
            _playerSkills.UseSkill(skillName, gameObject); // Oyuncu nesnesini de gönder
        }
    }

    // Saðlýk al
    public void TakeDamage(int amount)
    {
        if (_playerHealth != null)
        {
            _playerHealth.TakeDamage(amount);
        }
    }

    // Saðlýk iyileþtir
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
