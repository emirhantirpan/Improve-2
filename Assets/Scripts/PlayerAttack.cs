using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;

    public int attackDamage;
    public int attackRange = 10;
    public bool isAttacking;
    private void Awake()
    {
        instance = this;
    }
    public void Attack()
    {

    }

}
