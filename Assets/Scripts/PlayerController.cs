using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerActions _input;
    private PlayerSkills _playerSkills;
    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _input = new PlayerActions();
        _playerSkills = GetComponent<PlayerSkills>();
        _playerAttack = GetComponent<PlayerAttack>();

        AssignInputs();
    }

    private void AssignInputs()
    {
        // Movement, Attack ve Skill giriþlerini baðla
        _input.Main.Movement.performed += ctx => PlayerMovement.instance.ClickToMove();
        _input.Main.Attack.performed += ctx => _playerAttack.AttackFrequency();
        _input.Main.SetToClosestEnemy.performed += ctx => PlayerChooseNearestEnemy.instance.FindNearestEnemy();
    }

    private void Update()
    {
        // Sadece skiller için 1, 2, 3 tuþlarýna basýldýðýnda ilgili skiller çalýþtýrýlýr
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnemySpawner.instance.SpawnEnemy();
        }
    }

    private void UseSkill(string skillName)
    {
        // Yetenek adýný kullanarak ilgili skill'i çalýþtýr
        if (_playerSkills != null)
        {
            _playerSkills.UseSkill(skillName, gameObject); // Oyuncu nesnesini de gönder
        }
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
}
