using UnityEngine;

public class Enemy_Second : EnemyController
{
    public override void Initialize()
    {
        enemyName = "SecondBandit";
        enemyHealth = healthController.health;
        enemyLevel = levelController.level;
    }
}
