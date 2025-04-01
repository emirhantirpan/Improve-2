using UnityEngine;

public class Enemy_First : EnemyController
{
    public override void Initialize()
    {
        enemyName = "FirstEnemy";
        enemyHealth = healthController.health;
        //enemyLevel = levelController.level;
    }
}
