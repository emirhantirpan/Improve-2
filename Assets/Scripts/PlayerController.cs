using UnityEngine;
using UnityEngine.InputSystem;

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
        // Movement, Attack ve Skill giri�lerini ba�la
        _input.Main.Movement.performed += ctx => PlayerMovement.instance.ClickToMove();
        _input.Main.Attack.performed += ctx => PlayerAttack.instance.AttakFrequancy();
        _input.Main.SetToClosestEnemy.performed += ctx => PlayerChooseNearestEnemy.instance.FindNearestEnemy();
    }

    private void Update()
    {
        // Sadece skiller i�in 1, 2, 3 tu�lar�na bas�ld���nda ilgili skiller �al��t�r�l�r
        if (Input.GetKeyDown(KeyCode.Alpha1)) // DamageAround skill
        {
            UseSkill("DamageAround");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // Thunder skill
        {
            UseSkill("Thunder");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) // Heal skill
        {
            UseSkill("Heal");
        }
    }

    private void UseSkill(string skillName)
    {
        // Yetenek ad�n� kullanarak ilgili skill'i �al��t�r
        if (_playerSkills != null)
        {
            _playerSkills.UseSkill(skillName, gameObject); // Oyuncu nesnesini de g�nder
        }
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
}
