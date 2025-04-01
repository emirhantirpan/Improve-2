using UnityEngine;

public class Enemy_Second : EnemyController
{
    public override void Initialize()
    {
        enemyName = "SecondEnemy";
        enemyHealth = healthController.health;
        //enemyLevel = levelController.level;
    }
}
